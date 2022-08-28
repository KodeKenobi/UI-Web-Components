using PolicyManagementDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyManagementSystem.Controllers.Models
{
    public class BaseViewModel
    {
        public List<BrokerNotification> BrokerNotificationList { get; set; }

        public int ReviewCount { get; set; }
    }
}
