using System.ComponentModel.DataAnnotations;

public class NotWeekendAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime dateValue)
        {
            if (dateValue.DayOfWeek == DayOfWeek.Saturday || dateValue.DayOfWeek == DayOfWeek.Sunday)
            {
                return new ValidationResult("Goal to finish cannot be on a weekend.");
            }
        }

        return ValidationResult.Success;
    }
}
