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
        [StringLength(50, ErrorMessage = "Email kan max vara 50 tecken långt.")]
        [EmailAddress(ErrorMessage = "Det går ej tolka som giltig Email, Försök igen.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Fält får ej lämnas tomt.")]
        [StringLength(50, ErrorMessage = "Förnamn kan max vara 50 tecken långt.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Fält får ej lämnas tomt.")]
        [StringLength(50, ErrorMessage = "EfterNamn kan max vara 50 tecken långt.")]
        public string LastName { get; set; }
    }
}