using System.ComponentModel.DataAnnotations;

namespace CoffeeShopWebApp.Models
{
    public class RegisterListViewModel
    {
        public RegisterListViewModel()
        {

        }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Favorite coffee is required")]
        public string FavoriteCoffee { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        public string Birthday { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}