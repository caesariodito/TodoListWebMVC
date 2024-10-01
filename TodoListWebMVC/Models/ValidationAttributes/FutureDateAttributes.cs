using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListWebMVC.Models.ValidationAttributes
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                if (dateValue < DateTime.Now.Date)
                {
                    return new ValidationResult("Goal to finish must be a future date.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
