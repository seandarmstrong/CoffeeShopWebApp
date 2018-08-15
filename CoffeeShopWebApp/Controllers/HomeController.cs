using CoffeeShopWebApp.Models;
using System.Web.Mvc;

namespace CoffeeShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// this function calls the action of view for the Register page
        /// </summary>
        /// <returns>the View for the Register page</returns>
        public ActionResult Register()
        {
            ViewBag.Message = "Please fill out the form below to register!";

            return View();
        }

        /// <summary>
        /// this function calls the action of view for the AddUser page and passes the RegisterList model to the page as well
        /// </summary>
        /// <param name="model">this passes the properties of the RegisterLiveView model</param>
        /// <returns>the View for the AddUser page with the properties of the RegisterLiveView model</returns>
        [HttpPost]
        public ActionResult AddUser(RegisterListViewModel model)
        {
            return View(model);
        }
    }
}