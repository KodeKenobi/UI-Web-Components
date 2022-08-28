using PolicyManagementDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PolicyManagementMailer.Models;


namespace PolicyManagementDataAccess
{
    public interface IUserAccountRepository
    {

        Task<IdentityUser> GetUserByEmailAsync(string email);
        Task GenerateForgotPasswordTokenAsync(IdentityUser user);
        //Task<IdentityResult> ResetPasswordAsync(ApplicationUser model);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        void Update(TblUseraccount model);

        //void Delete(string id);
       // public async Task Delete(string id);

        IEnumerable<TblUseraccount> GetUsers();

        TblUseraccount GetUser(int id);
        SecureUser GetSecureUser(string email);
        Agent GetAgentById(int id);

        List<Agent> GetAgentList();

        Agent AddAgent(Agent agent,int id);
        IList<Addresses> GetProvinces();
        Addresses GetCityByProvince(string province);
        Addresses GetBranchByCity(string city);
        Addresses GetAddressById(int id);
        Agent UpdateAgent(Agent agent);

        void CreateUserAccounts(TblUseraccount model);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public SecureUser Authenticate(string username, string password);
        public TblUseraccount FldAuthenticate(string username, string password);
       // Task SendForgotPasswordEmail(UserE)
       // void Authenticate(string username, string password);
    }
}
