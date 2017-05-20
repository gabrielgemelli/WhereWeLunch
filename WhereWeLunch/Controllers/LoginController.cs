using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using WhereWeLunch.DAO;
using WhereWeLunch.Models;
using WhereWeLunch.Models.Response;
using System.Linq;

namespace WhereWeLunch.Controllers
{
    public class LoginController : ApiController
    {
        [System.Web.Http.HttpPost]
        public LoginResponse Login([FromBody]HungryProfessional hungryProfessional)
        {
            var dao = new HungryProfessionalDAO();

            var user = dao.Get(hungryProfessional.Email);

            if (user != null && (user.Password == hungryProfessional.Password))
            {
                var claims = new[] {
                    new Claim(ClaimTypes.Email, user.Email),
                };

                var identity = new ClaimsIdentity(claims, "ApplicationCookie");

                var context = Request.GetOwinContext();
                var authManager = context.Authentication;

                authManager.SignIn(new AuthenticationProperties(), identity);

                return new LoginResponse { ResponseCode = HttpStatusCode.OK, StatusIsSuccessful = true, Data = user };
            }

            return new LoginResponse { ResponseCode = HttpStatusCode.Forbidden, StatusIsSuccessful = false, ResponseResult = "User is not valid!" };
        }

        [System.Web.Http.HttpGet]
        public string UserIsLoaged()
        {
            if ((Request != null && Request.GetOwinContext() != null))
            {
                var claim = (Request.GetOwinContext().Request.User.Identity as ClaimsIdentity).Claims.FirstOrDefault();

                if (claim != null)
                    return claim.Value;
            }

            return string.Empty;
        }
    }
}