using PolicyManagementDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PolicyManagementSystem.Controllers.Models
{
    public class UserManagementViewModel : BaseViewModel
    {
        public List<TblUseraccount> tblUseraccounts { get; set; }

        public TblUseraccount tblUseraccount { get; set; }

        public Agent Agent { get; set; }
        public Addresses Address { get; set; }
        public IEnumerable<SelectListItem> Addresses { get; set; }
    }
}
