using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WhereWeLunch.Models;

namespace WhereWeLunch.Controllers
{
    public class LogoutController : ApiController
    {
        [System.Web.Http.HttpPost]
        public void Logout()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignOut();
        }
    }
}