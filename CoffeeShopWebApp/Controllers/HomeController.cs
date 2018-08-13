using System.Web.Mvc;
using CoffeeShopWebApp.Models;

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

        public ActionResult Register()
        {
            ViewBag.Message = "Please fill out the form below to register!";

            return View();
        }

        [HttpPost]
        public ActionResult AddUser(RegisterListViewModel model)
        {
            return View(model);
        }
    }
}