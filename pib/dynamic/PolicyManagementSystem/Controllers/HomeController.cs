using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolicyManagementDataAccess;
using PolicyManagementSystem.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IClientEngagementRepository _clientEngagementRepository;
        private IPolicyApplicationRepository _applicationRegistrationRepository;

        public HomeController(IClientEngagementRepository clientEngagementRepository, IPolicyApplicationRepository applicationRegistrationRepository)
        {
            _clientEngagementRepository = clientEngagementRepository;
            _applicationRegistrationRepository = applicationRegistrationRepository;
        }

        public IActionResult Index()
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();

            //Set the session
            var model = new BaseViewModel() { BrokerNotificationList = notificationList, ReviewCount = _applicationRegistrationRepository.GetReviewList().Count() };

            return View("~/Pages/Index.cshtml", model);
        }
    }
}
