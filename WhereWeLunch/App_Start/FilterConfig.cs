using System.Web.Mvc;
using WhereWeLunch.Filters;

namespace WhereWeLunch
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizationFilterAttribute());
        }
    }
}
