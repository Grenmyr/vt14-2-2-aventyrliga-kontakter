using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Äventyrliga_kontakter.Model
{
    public class Contact
    {
        
        public int ContactId { get; set; }
        [Required(ErrorMessage="Fält får ej lämnas tomt.")]
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}