using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PolicyManagementDataAccess;
using PolicyManagementSystem.Controllers.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyManagementSystem.Controllers
{
    [Authorize]
    public class HRManagementController : Controller
    {
        private IClientEngagementRepository _clientEngagementRepository;

        public HRManagementController(IClientEngagementRepository clientEngagementRepository)
        {
            _clientEngagementRepository = clientEngagementRepository;
        }

        public IActionResult Index()
        {
            return View("~/Pages/HRManagement/Index.cshtml");
        }

        public IActionResult Comission()
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();

            var metabaseUrl = "http://129.232.242.186:3035/";
            var token = getToken(7);

            var iFrameUrl = metabaseUrl + "embed/dashboard/" + token + "#bordered=true&titled=true";

            //Set the session
            var model = new HRManagementViewModel() { BrokerNotificationList = notificationList, ComissionIFrameUrl = iFrameUrl };

            return View("~/Pages/HRManagement/ComissionReport.cshtml", model);
        }

        public IActionResult Perfomance()
        {
            return View("~/Pages/HRManagement/BranchandPerformanceReport.cshtml");
        }

        private string getToken(Int16 dashboardId)
        {
            //key is the METABASE_SECRET_KEY shown in the sample. It’s the same for all dashboards on the server. Should really be in web.config. Put your value here.
            string key = "3378163d6226cdc84ff26d47e6b5ffeb5924339a0f3f02bccb86560dd3726781";

            //some gubbins to setup the credential generation
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            //the awkward bit. Looks simpler in the sample code, but .Net JWT needs dictionaries to pass the values as it doesn’t handle any complexity very well…
            //dash contains the information about the resource. It could be ‘question’ if that’s all you’re embedding.
            var dash = new Dictionary<string, Int16>();
            dash.Add("dashboard", dashboardId);

            //Empty dictionary for the params. Anything else gives odd results
            var pars = new Dictionary<string, string>();

            //create the payload
            JwtPayload payload = new JwtPayload
            {
            {"resource",dash } ,
            {"params",pars}
            };

            //Finally some more gubbins before the token string is passed back
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken);
            return tokenString;
        }
    }
}
