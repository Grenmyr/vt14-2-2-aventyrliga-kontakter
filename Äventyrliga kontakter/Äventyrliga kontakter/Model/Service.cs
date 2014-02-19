using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Äventyrliga_kontakter.Model.DAL;


namespace Äventyrliga_kontakter.Model
{
    public class Service
    {

        private ContactDAL _contactDAL;

        public ContactDAL ContacDAL { get; private set; }

        public void DeleteContact(Contact contact)
        {
        }

        public void DeleteContact(int contactId)
        {
        }

        public Contact GetContact(int contactId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContacts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount) { throw new NotImplementedException(); }

        public void SaveContact(Contact contact) { }
    }
}