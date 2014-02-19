using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Äventyrliga_kontakter.Model.DAL
{
    public class ContactDAL
    {
        

        public Contact GetContactById (int contactId){ throw new NotImplementedException("Här ska jag retunera enskild kontakt");}

        public IEnumerable<Contact> GetContacts() { throw new NotImplementedException("Härifrån ska jag hämta en kontaktlista"); }

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount) { throw new NotImplementedException("Härifrån ska jag hämta en hur lång min lista är"); }

        
        public void InsertContact(Contact contact) { /*Metod för  köra lagrad procedur med*/ }

        public void DeleteContact(int contactId)
        {
            /*Metod för  köra lagrad procedur med*/
        }
        public void UpdateContact(Contact contact) { /*Metod för  köra lagrad procedur med*/ }
    }
}