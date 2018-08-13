using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShopWebApp.Models
{
    public class RegisterListViewModel
    {
        public RegisterListViewModel()
        {

        }

        [Required(ErrorMessage = "First name is required")]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Favorite coffee is required")]
        public string FavoriteCoffee { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, ErrorMessage = "Password must be between {2} and {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}