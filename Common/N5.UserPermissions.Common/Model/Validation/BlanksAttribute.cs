using System.ComponentModel.DataAnnotations;

namespace N5.UserPermissions.Common.Model.Validation
{
    public class BlanksAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(value?.ToString())) return ValidationResult.Success;

            var words = value.ToString().Split(' ');

            foreach (var word in words)
            {
                if (string.IsNullOrEmpty(word)) return new ValidationResult("No debe colocar espacios vacíos seguidos.");
            }

            return ValidationResult.Success;
        }
    }
}
