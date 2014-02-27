using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Äventyrliga_kontakter.Model.DAL;

// lag till DAL
namespace Äventyrliga_kontakter.Model
{
    public class Service
    {

        private ContactDAL _contactDAL;

        public ContactDAL ContactDAL
        {
            get { return _contactDAL ?? (_contactDAL = new ContactDAL()); }
        }

        public void DeleteContact(Contact contact)
        {
            // TODO:
        }

        public void DeleteContact(int contactId)
        {
            ContactDAL.DeleteContact(contactId);
        }
        /// Hämtar en kund med ett specifikt kontaktid från databasen.
        public Contact GetContact(int contactId)
        {
            return ContactDAL.GetContactById(contactId);

        }
        /// Hämtar alla kontrakt som finns lagrade i databasen.
        public IEnumerable<Contact> GetContacts()
        {
            return ContactDAL.GetContacts();
        }

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return ContactDAL.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount);
        }

        public void SaveContact(Contact contact)
        {
            
            // Kontrollerar att contact objkt går igenom validation innan jag sätter in kontakten. Om ID är 0 så är det en ny kontakt.
            ICollection<ValidationResult> validationresults;
            if (contact.Validate(out validationresults))
            {
            if (contact.ContactId == 0)
            {
                ContactDAL.InsertContact(contact);
            }
            else
            {
                ContactDAL.UpdateContact(contact);
            }
            }
        }
    }
}