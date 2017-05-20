using System.Web.Mvc;

namespace WhereWeLunch.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Home";

            return View();
        }

        public ActionResult Voting()
        {
            ViewBag.Title = "Voting";

            return View();
        }

        public ActionResult Restaurants()
        {
            ViewBag.Title = "Restaurants";

            return View();
        }

        public ActionResult VotingResults()
        {
            ViewBag.Title = "Voting Results";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login";

            return View();
        }

        public ActionResult Logout()
        {
            ViewBag.Title = "Logout";

            return View();
        }

    }
}