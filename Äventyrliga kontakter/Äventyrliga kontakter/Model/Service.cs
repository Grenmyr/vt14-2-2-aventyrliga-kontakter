using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Äventyrliga_kontakter.Model.DAL;

// lag till DAL
namespace Äventyrliga_kontakter.Model.DAL
{
    public class Service
    {

        private ContactDAL _contactDAL;

        public ContactDAL ContacDAL
        {
            get { return _contactDAL ?? (_contactDAL = new ContactDAL()); }
        }


        public void DeleteContact(Contact contact)
        {
        }

        public void DeleteContact(int contactId)
        {
            //ContactDAL.DeleteContact(contactId);
        }

        public Contact GetContact(int contactId)
        {
            //return ContactDAL.GetContactById(contactId);
            throw new NotImplementedException("dsadsadsa");
        }

        public IEnumerable<Contact> GetContacts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount) { throw new NotImplementedException(); }

        public void SaveContact(Contact contact) { }
    }
}