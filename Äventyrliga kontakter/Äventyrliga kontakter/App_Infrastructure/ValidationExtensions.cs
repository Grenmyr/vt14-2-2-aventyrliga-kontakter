using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Äventyrliga_kontakter
{
    public static class ValidationExtensions
    {
        // Works aproximatly, This is extension method to my Validation on Contact Objects.
        public static bool Validate<Contact>(this Contact instance, out ICollection<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(instance);
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(instance,validationContext,validationResults,true);
        }
    }
}