using CoffeeShopWebApp.DAL;
using CoffeeShopWebApp.Helpers;
using CoffeeShopWebApp.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private GcCoffeeShopModelContainer db = new GcCoffeeShopModelContainer();

        public ActionResult Index()
        {
            return View(db.Items.ToList());
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
        /// this function takes in the model and creates two new cookies based on the user information
        /// </summary>
        /// <param name="model">this passes the properties of the RegisterLiveView model</param>
        /// <returns>the View for the AddUser page with the properties of the RegisterLiveView model</returns>
        [HttpPost]
        public ActionResult AddUser(RegisterListViewModel model)
        {
            HttpCookie t;
            if (Request.Cookies[Constants.FirstNameCookie] == null)
            {
                //bake new cookie for first name
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
                //bake new cookie for favorite coffee
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

        /// <summary>
        /// this function calls two cookies and stores their value in a viewbag for use on the product page
        /// </summary>
        /// <returns>the product page and two cookie data in viewbags</returns>
        public ActionResult Product()
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

        /// <summary>
        /// this function handles increasing the counter cookie when the product is added to cart and re-displays the product page
        /// </summary>
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

        /// <summary>
        /// this function calls two cookies for use on the cart page and calls the view of the cart
        /// </summary>
        /// <returns>the view of the cart page</returns>
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

        /// <summary>
        /// this function requests the two cookies that exist, sets them to expired to delete them,
        /// and then assigns the temp cookies that arent used
        /// </summary>
        /// <returns>the cart view but with an empty cart</returns>
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

        [HttpPost]
        public ActionResult Search(string seachQuery)
        {
            var searchTerm = db.Items.Where(per => per.Name.Contains(seachQuery));
            return View(searchTerm);
        }
    }
}