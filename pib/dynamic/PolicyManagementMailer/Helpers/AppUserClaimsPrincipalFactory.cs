using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using PolicyManagementMailer.Models;
namespace PolicyManagementMailer.Helpers
{
  public class AppUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
    {
        public AppUserClaimsPrincipalFactory(UserManager<IdentityUser> userManager,
           RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
           : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserFirstName", user.UserName ?? ""));
            identity.AddClaim(new Claim("UserLastName", user.Email ?? ""));
            return identity;
        }
    }
}
