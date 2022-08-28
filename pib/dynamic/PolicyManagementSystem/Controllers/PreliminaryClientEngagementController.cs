using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolicyManagementDataAccess;
using PolicyManagementDataAccess.Context;
using PolicyManagementSystem.Controllers.Models;

namespace PolicyManagementSystem.Controllers
{
    [Authorize]
    public class PreliminaryClientEngagementController : Controller
    {
        private IClientEngagementRepository _clientEngagementRepository;

        public PreliminaryClientEngagementController(IClientEngagementRepository clientEngagementRepository)
        {
            _clientEngagementRepository = clientEngagementRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View("~/Pages/PreliminaryClientEngagement/Index.cshtml");
        }

        public IActionResult Update(ClientEngagementViewModel viewModel)
        {
            _clientEngagementRepository.UpdateCallMeBack(viewModel.CallMeBack.Id, viewModel.CallMeBack.Comment);

            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new ClientEngagementViewModel() { CallMeBackList = _clientEngagementRepository.GetCallMeBackList(), BrokerNotificationList = notificationList };

            return View("~/Pages/PreliminaryClientEngagement/ListEngagements.cshtml", model);
        }

        public IActionResult ListEngangements()
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new ClientEngagementViewModel() { CallMeBackList = _clientEngagementRepository.GetCallMeBackList(), BrokerNotificationList = notificationList };

            return View("~/Pages/PreliminaryClientEngagement/ListEngagements.cshtml", model);
        }

        public IActionResult ViewClient(Guid id)
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new ClientEngagementViewModel() { CallMeBack = _clientEngagementRepository.GetCallMeBackById(id), BrokerNotificationList = notificationList };

            return View("~/Pages/PreliminaryClientEngagement/ViewClient.cshtml", model);
        }

        [AllowAnonymous]
        public IActionResult Create(ClientEngagementViewModel model)
        {
            //Add client details
            var id = _clientEngagementRepository.AddCallMeBack(model.CallMeBack);

            //Add broker notification
            var notification = new BrokerNotification();

            notification.CallMeBackId = id;
            notification.AmendRef = model.CallMeBack.FullName + " submitted their Call Me Back details";

            _clientEngagementRepository.AddNotification(notification);

            return View("~/Pages/PreliminaryClientEngagement/CallMeSubmitted.cshtml");
        }
    }
}
