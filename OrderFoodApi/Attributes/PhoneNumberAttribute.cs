using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OrderFoodApi.Attributes
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var regex = new Regex("[0-9]{9}");
            if (regex.IsMatch(value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid phone number!");
        }
    }
}
