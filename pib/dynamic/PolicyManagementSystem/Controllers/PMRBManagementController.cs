using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using PolicyManagementDataAccess;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PolicyManagementSystem.Controllers.Models;
using Microsoft.AspNetCore.Authorization;

namespace PolicyManagementSystem.Controllers
{
    [Authorize]
    public class PMRBManagementController : Controller
    {
        private IClientEngagementRepository _clientEngagementRepository;

        public PMRBManagementController(IClientEngagementRepository clientEngagementRepository)
        {
            _clientEngagementRepository = clientEngagementRepository;
        }

        public IActionResult Index()
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();

            //Set the session
            var model = new PMRBManagementViewModel() { BrokerNotificationList = notificationList };

            return View("~/Pages/PMRBManagement/Index.cshtml", model);
        }
        
    }
}
