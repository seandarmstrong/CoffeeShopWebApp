using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CoffeeShopWebApp.Models
{
    public class CustomEmailAttribute : ValidationAttribute
    {
        //unused but created for example as shown in class
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = value.ToString();
            var emailRegex = new Regex("\\W+@\\w.\\w");

            var isValidEmail = emailRegex.IsMatch(email);
            if (isValidEmail)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("This is an invalid email address.");
            }


        }
    }
}