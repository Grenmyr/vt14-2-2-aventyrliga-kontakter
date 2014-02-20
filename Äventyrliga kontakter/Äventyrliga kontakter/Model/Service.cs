using System;
using System.Collections.Generic;
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

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount) { throw new NotImplementedException(); }

        public void SaveContact(Contact contact)
        {
            // Om inte skapad post retuneras null.
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