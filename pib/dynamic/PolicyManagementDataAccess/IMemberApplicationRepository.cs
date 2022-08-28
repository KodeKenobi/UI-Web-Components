using PolicyManagementDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolicyManagementModels.Policy;
using PolicyManagementModels;
using PolicyManagementModels.Users;
using Microsoft.AspNetCore.Identity;


namespace PolicyManagementDataAccess
{
    public interface IMemberApplicationRepository
    {
        void Update(MemberApplication model);

        void Delete(int id);

        bool IdAlreadyRegistered(string idNum);

        IEnumerable<MemberApplication> GetMemberApplications();

        MemberApplication GetMemberApplication(int id);

        MemberApplication MemberApplicationGetByEmail(string email);
       // MemberApplication MemberApplicationGetByIdNumber(string idNum);

        void Add(MemberApplication model, string webRootPath, string confirmationLink);
        void CreateUserAddress(CreateAddressModel address);
        Task<IdentityResult> CreateUserAsync(RegisterModel userModel);

    }
}
