using PolicyManagementDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyManagementSystem.Controllers.Models
{
    public class ClientEngagementViewModel : BaseViewModel
    {
        public CallMeBack CallMeBack { get; set; }

        public List<CallMeBack> CallMeBackList { get; set; }
    }
}
