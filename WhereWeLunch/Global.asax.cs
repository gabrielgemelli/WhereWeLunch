using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WhereWeLunch.DAO;

namespace WhereWeLunch
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var restaurantDao = new RestaurantDAO();
            restaurantDao.InitializeData();

            var hungryProfessionalDao = new HungryProfessionalDAO();
            hungryProfessionalDao.InitializeData();
        }
    }
}
