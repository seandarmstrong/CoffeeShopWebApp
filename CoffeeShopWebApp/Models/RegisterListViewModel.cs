using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShopWebApp.Models
{
    public class RegisterListViewModel
    {
        public RegisterListViewModel()
        {

        }

        //creates the properties for the class and sets the attributes for validation on the form
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Favorite coffee is required")]
        public string FavoriteCoffee { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        //unused but here for example of how to implement the custom attribute class created for class
        //[CustomEmail]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^(\+\d{1, 2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", ErrorMessage = "Phone number not valid")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(15, ErrorMessage = "Password must be between {2} and {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [StringLength(15, ErrorMessage = "Password must be between {2} and {1} characters long.", MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "The password you're entering must match the password you entered above")]
        public string ConfirmPassword { get; set; }

        //marked as required in the HTML
        public string PreferredContact { get; set; }

    }
}