using CoffeeShopWebApp.Helpers;
using CoffeeShopWebApp.Models;
using System;
using System.Web;
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
            HttpCookie t;
            if (Request.Cookies[Constants.FirstNameCookie] == null)
            {
                t = new HttpCookie(Constants.FirstNameCookie);
                t.Value = "";
                t.Expires = DateTime.UtcNow.AddYears(1);
            }
            else
            {
                t = Request.Cookies[Constants.FirstNameCookie];
            }

            t.Value = model.FirstName;
            Response.Cookies.Add(t);
            ViewBag.Message = $"Hello {t.Value}";

            HttpCookie favCoffeeCookie;
            if (Request.Cookies[Constants.FavoriteCoffeeCookie] == null)
            {
                favCoffeeCookie = new HttpCookie(Constants.FavoriteCoffeeCookie);

                favCoffeeCookie.Expires = DateTime.UtcNow.AddYears(1);
            }
            else
            {
                favCoffeeCookie = Request.Cookies[Constants.FavoriteCoffeeCookie];
            }
            favCoffeeCookie.Value = model.FavoriteCoffee;
            Response.Cookies.Add(favCoffeeCookie);
            return View();
        }

        public ActionResult Product()
        {

            HttpCookie cookie = HttpContext.Request.Cookies[Constants.FavoriteCoffeeCookie];
            ViewBag.FavCoffee = cookie.Value;
            return View();
        }

        int Counter = 0;
        public ActionResult AddToCart()
        {
            HttpCookie counterCookie;
            if (Request.Cookies[Constants.CounterCookie] == null)
            {
                counterCookie = new HttpCookie(Constants.CounterCookie);
                counterCookie.Value = "0";
                counterCookie.Expires = DateTime.UtcNow.AddYears(1);
            }
            else
            {
                counterCookie = Request.Cookies[Constants.CounterCookie];
            }

            Counter = int.Parse(counterCookie.Value);
            Counter += 1;
            counterCookie.Value = Counter.ToString();
            Response.Cookies.Add(counterCookie);

            return RedirectToAction("Product");
        }

        public ActionResult Cart()
        {
            if (Request.Cookies[Constants.FavoriteCoffeeCookie] != null)
            {
                HttpCookie cookie = HttpContext.Request.Cookies[Constants.FavoriteCoffeeCookie];
                ViewBag.FavCoffee = cookie.Value;
            }

            if (Request.Cookies[Constants.CounterCookie] != null)
            {
                HttpCookie temp = HttpContext.Request.Cookies[Constants.CounterCookie];
                ViewBag.Counter = temp.Value;
            }
            
            return View();
        }

        public ActionResult ClearCart()
        {
            if (Request.Cookies[Constants.FavoriteCoffeeCookie] != null)
            {
                HttpCookie temp1 = new HttpCookie(Constants.FavoriteCoffeeCookie);
                temp1.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(temp1);
            }

            if (Request.Cookies[Constants.CounterCookie] != null)
            {
                HttpCookie temp2 = new HttpCookie(Constants.CounterCookie);
                temp2.Expires = DateTime.UtcNow.AddDays(-1);
                Response.Cookies.Add(temp2);
            }

            return RedirectToAction("Cart");
        }
    }
}