using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Security.Claims;
using System.Web.Helpers;

namespace WhereWeLunch
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Home/Login")
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Email;
        }
    }
}