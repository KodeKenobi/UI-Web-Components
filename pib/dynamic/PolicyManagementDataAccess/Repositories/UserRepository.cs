using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolicyManagementDataAccess.Context;
using Microsoft.AspNetCore;
using System.Security.Claims;


namespace PolicyManagementDataAccess.Repositories
{
    class UserRepository: IUser
    {
        private BrkBaseContext context;
        public UserRepository(BrkBaseContext _context)
        {
            context = _context;
        }
        //public int GetUserId()
        //{
        //   // return Convert.ToInt16(context.AspNetRoles.FindFirstValue(ClaimTypes.NameIdentifier));
        //}
        //public string GetUserEmail()
        //{
        //    return context.HttpContext.User.Identity.Name;
        //}
    }
}
