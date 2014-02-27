using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Äventyrliga_kontakter
{
    public static class ValidationExtensions
    {
        // Works aproximatly, This is extension method to my Validation on properties in Contact.cs.
        // They are used to initialize 1 ValidationContext that if if no Failed ValidationResults returns true = no failed property validations.
        public static bool Validate<Typ>(this Typ instance, out ICollection<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(instance);
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(instance,validationContext,validationResults,true);
        }
    }
}