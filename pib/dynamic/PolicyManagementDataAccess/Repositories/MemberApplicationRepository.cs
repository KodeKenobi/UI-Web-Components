using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PolicyManagementDataAccess.Context;
using PolicyManagementMailer;
using PolicyManagementModels;
using PolicyManagementModels.Policy;
using PolicyManagementDataAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PolicyManagementModels.Users;
using PolicyManagementDataAccess.Service;
using PolicyManagementMailer.Models;

namespace PolicyManagementDataAccess.Repositories
{
    public class MemberApplicationRepository : IMemberApplicationRepository
    {
        private BrkBaseContext context;
        private DbSet<MemberApplication> memberApplicationEntity;
        private IHostingEnvironment _env;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
       

        public MemberApplicationRepository(BrkBaseContext context, IMapper mapper, UserManager<IdentityUser> userManager,
             IConfiguration configuration,
       IEmailService emailService)
        {
            this.context = context;
            memberApplicationEntity = context.Set<MemberApplication>();
           _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _emailService = emailService;

        }
        public void CreateUserAddress(CreateAddressModel model)
        {
            // var member   context.MemberApplications.Find(MemDetNum);
            // context.MemberApplications.ad
            var address = _mapper.Map<Addresses>(model);
            int newID = CreateNewId();
            if (newID != 0 )
            {
                address.MemDetNum = newID;
                address.AddressType = AddressType.User;
            }
            // context.Entry(address).State = EntityState.Added;
            context.Addresses.Add(address);
            context.SaveChanges();
           
            //context.SaveChanges();
           // return address;
        }
        //  Address CreateUserAddress(CreateAddressModel address);
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
                        string.Format(appDomain + confirmationLink, user.Id, token))
                }
            };

            await _emailService.SendEmailForEmailConfirmation(options);
        }

        public async Task GenerateEmailConfirmationTokenAsync(IdentityUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendEmailConfirmationEmail(user, token);
            }
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterModel userModel)
        {
            var user = new IdentityUser()
            {
                UserName = userModel.Email,
                NormalizedEmail = userModel.Email,
                Email = userModel.Email,
                NormalizedUserName = userModel.Email

            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (result.Succeeded)
            {
                await GenerateEmailConfirmationTokenAsync(user);
                await _userManager.AddToRoleAsync(user, "Applicant");
                await _userManager.UpdateAsync(user);

            }
           
            return result;
        }


        public void Add(MemberApplication model, string webRootPath, string confirmationLink)
        {
            try
            {
                //get the last ID

             int newID=  CreateNewId();
                //Send the applicant the notification
                var mailer = new Mailer(_env, _config);

                mailer.SendConfirmationRegistrationEmail(webRootPath, model.FirstName, model.Email, confirmationLink);

                //Assign Value
                model.Idnum = model.Idnum.TrimEnd();
                model.MemDetNum = newID;
                model.UserDateTime = DateTime.Now;

                context.Entry(model).State = EntityState.Added;

                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
       
        //Private helper method
        private int CreateNewId ()
        {
            // Create ID for whoever is the one inserting the Application (Agent/Broker/User)
            var newID = context.MemberApplications.OrderByDescending(x => x.MemDetNum).FirstOrDefault().MemDetNum + 1;
            return newID;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MemberApplication GetMemberApplication(int id)
        {
            try
            {
                return memberApplicationEntity.SingleOrDefault(s => s.MemDetNum == id);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public bool IdAlreadyRegistered(string idNum)
        {
            try
            {
                var cleanId = idNum.TrimEnd();

                var applicant = memberApplicationEntity.FirstOrDefault(s => s.Idnum == cleanId);

                if (applicant != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MemberApplication MemberApplicationGetByEmail(string email)
        {
            try
            {
                return memberApplicationEntity.FirstOrDefault(s => s.Email == email);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<MemberApplication> GetMemberApplications()
        {
            try
            {
                return memberApplicationEntity.AsEnumerable();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void Update(MemberApplication model)
        {
            throw new NotImplementedException();
        }
        //public void AddDetails (MemberGroup memberGroup)
        //{

        //}
    }
}
