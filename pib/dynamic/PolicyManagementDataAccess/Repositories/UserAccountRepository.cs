using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PolicyManagementDataAccess.Context;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using BCryptNet = BCrypt.Net.BCrypt;
using PolicyManagementMailer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PolicyManagementDataAccess.Service;





namespace PolicyManagementDataAccess.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private BrkBaseContext context;
        private DbSet<TblUseraccount> _userEntity;
        private DbSet <Agent> _agentEntity;
        private DbSet<SecureUser> secureUser;
       private DbSet <Addresses> _addresses;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;


        public UserAccountRepository(BrkBaseContext context, UserManager<IdentityUser> userManager, IConfiguration configuration, IEmailService emailService)
        {
            this.context = context;
           _userEntity = context.Set<TblUseraccount>(); 
            _agentEntity = context.Set<Agent>();
            _addresses = context.Set<Addresses>();
            secureUser = context.Set<SecureUser>();

            _userManager = userManager;
            _emailService = emailService;
            _configuration = configuration;
        }
        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            return await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, true);
        }
        public async Task<IdentityUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task GenerateForgotPasswordTokenAsync(IdentityUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPasswordEmail(user, token);
            }
        }

        private async Task SendForgotPasswordEmail(IdentityUser user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;

            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.UserName),
                    new KeyValuePair<string, string>("{{Link}}",
                        string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };
            //var emailoptions = options;

            //await _emailService.SendEmailForForgotPassword(options);
            await _emailService.SendEmailForEmailConfirmation(options);
        }
         public async Task<IdentityResult> ResetPasswordAsync(IdentityUser model)
        {
           // var token = GenerateEmailConfirmationTokenAsync(model);
            return await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.Email.ToString()),"", model.PasswordHash);
        }
        //public async Task GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        //{
        //    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        await SendEmailConfirmationEmail(user, token);
        //    }
        //   // return token;
        //}
        public void CreateUserAccounts(TblUseraccount model)
        {

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var agent = new Agent();
                    //get the last ID
                    var newID = context.TblUseraccounts.OrderByDescending(x => x.FldAccountId).FirstOrDefault().FldAccountId + 1;
                   // var newAccountId
                    //Assign Value
                    model.FldAccountId = newID;
                    model.FldCompanyId = 1001;
                    model.FldUserIsactiveflag = true;
                    
                    //  context.Entry(model).State = EntityState.Added;
                    byte[] passwordHash, passwordSalt;
                    // hash password
                    string password = Convert.ToString(BCryptNet.HashPassword(model.FldUserPassword));

                    CreatePasswordHash(password, out passwordHash, out passwordSalt);

                    model.FldUserPassword = password;

                    //  Set the secure user values.
                    var secureUser = new SecureUser()
                    {
                        UserNum = newID,
                        LogName = model.FldUsername,
                        Password = password,
                        UserEmail = model.FldUserEmail,
                        UserName = model.FldUsername,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt

                    };
                    //Create an Agent linked to the profile
                     var newagent = AddAgent(agent, newID);
                    model.FldAgentId = newagent.AgentKey;
                 //   model
             

                    //agent.UserNum = secureUser.UserNum;
                    agent.ContactEmail = model.FldUserEmail;
                    agent.AgentName = model.FldUsername;
                    //.Address1 =model.A
                    

                    context.Entry(model).State = EntityState.Added;
                    context.Entry(secureUser).State = EntityState.Added;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;

                }
            }

        }
        public SecureUser Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = context.SecureUsers.SingleOrDefault(x => x.UserEmail == email);
           

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }
        public TblUseraccount FldAuthenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = context.TblUseraccounts.SingleOrDefault(x => x.FldUserEmail == email);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.FldPasswordHash, user.FldPasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        // private helper method
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        
        private async Task SendEmailConfirmationEmail(IdentityUser user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationLink = _configuration.GetSection("Application:EmailConfirmation").Value;

            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email },
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.UserName),
                    new KeyValuePair<string, string>("{{Link}}",
                        string.Format(appDomain + confirmationLink, user.Email, token))
                }
            };

            await _emailService.SendEmailForEmailConfirmation(options);
        }

        public void Delete(int id)
        {
            try
            {
                //   //get user
                //   var entity = new TblUseraccount();
                //   TblUseraccount user = GetUser(id);
                //   context.Users.Remove(user);
                ////   _userEntity.co.Remove(user);
                //   context.SaveChanges();

                var user = context.Users.Find(id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SecureUser GetSecureUser(string email)
        {
            var user = context.SecureUsers.Find(email);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
        public TblUseraccount GetUser(int id)
        {
            try
            {
                return  context.TblUseraccounts.Find(id);
               // _userEntity.SingleOrDefault(s => s.FldAccountId == id);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public IEnumerable<TblUseraccount> GetUsers()
        {
            try
            {
                return context.TblUseraccounts ;
               // context.AsEnumerable();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public Agent GetAgentById(int id)
        {
            try
            {
                return context.Agents.SingleOrDefault(s => s.AgentKey == id);
                   // _userEntity.SingleOrDefault(s => s.AgentKey == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Agent> GetAgentList()
        {
            try
            {
                return context.Agents.ToList();
                    //_userEntity.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Addresses> GetAddressList()
        {
            try
            {
                return context.Addresses.ToList();
                   // addresses.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Addresses GetAddressById(int id)
        {
            try
            {
                return context.Addresses.SingleOrDefault(s => s.AddressID == id);
                   // Address.SingleOrDefault(s => s.AddressID == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Agent AddAgent(Agent agent, int userId)
        {
            try  
            {
                Addresses address = new Addresses();
                //get the last ID
                var newID = context.Agents.OrderByDescending(x => x.AgentKey).FirstOrDefault().AgentKey + 1;
                // var agentNum = context.Agents.OrderByDescending(x => x.AgentNum).FirstOrDefault().AgentNum + 1;
                var idSet = context.Addresses.Select(x => x.AddressID).ToHashSet();

                if (idSet != null)
                {
                    agent.Address.AddressID = Convert.ToInt32(idSet);
                    address.AddressType = AddressType.Branch;
                }
                
                //set the entity values
                agent.AgentKey = newID;
                agent.UserDateTime = DateTime.Now;
                agent.UserNum = userId;
                
                context.Agents.Add(agent);
                context.SaveChanges();
                return agent;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public Address CreateAddress( int id)
        //{
        //    var address = new Address()
        //    {
        //        AddressID = id,
        //        Province = GetProvinces().ToString(),
        //        City = GetCityByProvince(Province.to),
        //    }

        //}
        //public IEnumerable<SelectListItem> GetCountries()
        //{
        //    List<SelectListItem> countries = context.Provincr.AsNoTracking()
        //        .OrderBy(n => n.CountryNameEnglish)
        //        .Select(n =>
        //            new SelectListItem
        //            {
        //                Value = n.CountryId.ToString(),
        //                Text = n.CountryNameEnglish
        //            }).ToList();
        //    var countrytip = new SelectListItem()
        //    {
        //        Value = null,
        //        Text = "--- select country ---"
        //    };
        //    countries.Insert(0, countrytip);
        //    return new SelectList(countries, "Value", "Text");
        //}


        public IList<Addresses> GetProvinces()
        {
            //var results = (from ta in context.Address
            //               select ta.Province).Distinct();
            try
            {
                 IList<Addresses> distinctProvince = context.Addresses
           // IList<Addresses> distinctProvince = context.Address.Select(m => m.Province).Distinct();
           .GroupBy(p => p.Province)
           .Select(g => g.FirstOrDefault())
           .ToList();
                GetCityByProvince(distinctProvince.ToString());
                return distinctProvince;
                
            }
            catch (Exception)
            {

                throw;
            }
    //return results.AsEnumerable().;
}
        public Addresses GetProvincebyId(int id)
        {
            try

            {
              
                return context.Addresses.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Addresses GetCityByProvince(string province)
        {
            try

            {
                GetBranchByCity(province);
                return context.Addresses.Find(province);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public Addresses GetBranchByCity(string city)
        {
            try
            {
                return context.Addresses.Find(city);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Agent UpdateAgent(Agent agentModel)
        {
            try
            {
                var agent = GetAgentById(agentModel.AgentKey);

                if (agent == null)
                {
                    throw new Exception("Agent is not found");
                }

                agent.AgentName = agentModel.AgentName;
                agent.ContactPhone = agentModel.ContactPhone;
                agent.ContactEmail = agentModel.ContactEmail;
                agent.Address1 = agentModel.Address1;
                agent.Address2 = agentModel.Address2;

                //update agent
               
                context.SaveChanges();
                return agent;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(TblUseraccount model)
        {
            try
            {
                var user = GetUser(model.FldAccountId);

                if (user == null)
                {
                    throw new Exception("user is not found");
                }

                user.FldUsername = model.FldUsername;
                user.FldUserTitle = model.FldUserTitle;
                user.FldUserAccounttype = model.FldUserAccounttype;
                user.FldUserDepartment = model.FldUserDepartment;
                user.FldUserJobtitle = model.FldUserJobtitle;

                //update user
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        //Private helper Methods
        //private async Task SendForgotPasswordEmail(ApplicationUser user, string token)
        //{
        //    string appDomain = _configuration.GetSection("Application:AppDomain").Value;
        //    string confirmationLink = _configuration.GetSection("Application:ForgotPassword").Value;

        //    UserEmailOptions options = new UserEmailOptions
        //    {
        //        ToEmails = new List<string>() { user.Email },
        //        PlaceHolders = new List<KeyValuePair<string, string>>()
        //        {
        //            new KeyValuePair<string, string>("{{UserName}}", user.UserName),
        //            new KeyValuePair<string, string>("{{Link}}",
        //                string.Format(appDomain + confirmationLink, user.Id, token))
        //        }
        //    };

        //    await _emailService.SendEmailForForgotPassword(options);
        //}
    }
}
