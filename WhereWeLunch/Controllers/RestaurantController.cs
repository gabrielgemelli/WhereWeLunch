using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using WhereWeLunch.DAO;
using WhereWeLunch.Models;

namespace WhereWeLunch.Controllers
{
    public class RestaurantController : ApiController
    {
        // GET api/<controller>
        [System.Web.Http.HttpGet]
        [ValidateAntiForgeryToken]
        public IEnumerable<Restaurant> Get()
        {
            var dao = new RestaurantDAO();

            return dao.Get().OrderBy(a => a.Name);
        }

        // GET api/<controller>/5
        [System.Web.Http.HttpGet]
        [ValidateAntiForgeryToken]
        public Restaurant Get(int id)
        {
            var dao = new RestaurantDAO();

            return dao.Get(id);
        }

        // POST api/<controller>
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public void Post([FromBody]Restaurant restaurant)
        {
            var dao = new RestaurantDAO();

            dao.Post(restaurant);
        }
    }
}