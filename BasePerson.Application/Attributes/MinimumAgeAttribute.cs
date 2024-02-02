using System.ComponentModel.DataAnnotations;

namespace BasePerson.Application.Attributes
{

    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is DateTime))
            {
                // If the value is null or not a DateTime, return an error.
                return new ValidationResult("A valid date is required.");
            }

            var date = (DateTime)value;
            var age = DateTime.Today.Year - date.Year;

            // Check for a leap year.
            if (date > DateTime.Today.AddYears(-age)) age--;

            if (age < _minimumAge)
            {
                return new ValidationResult($"You must be at least {_minimumAge} years old.");
            }

            return ValidationResult.Success;
        }
    }
}
