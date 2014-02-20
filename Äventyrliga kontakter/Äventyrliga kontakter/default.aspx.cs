using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Äventyrliga_kontakter.Model;

namespace Äventyrliga_kontakter
{
    public partial class _default : System.Web.UI.Page
    {
        private Service _service;

        // Egenskap för skapa Service referens endast om det behövs.
        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Genererar alla kontakter.
        public IEnumerable<Äventyrliga_kontakter.Model.Contact> ContactListView_GetData()
        {
            return Service.GetContacts();
        }

        public void ContactListView_InsertItem(Contact contact)
        {
            // Metod för lägga in kontakter till min databas.
            
            // TODO: Ska lägga in isvalid här sen.
            
                try
                {
                    Service.SaveContact(contact);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade när Kunduppgift skulle Läggas till.");
                }
            
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_UpdateItem(int contactId)
        {
            try
            {
                var contact = Service.GetContact(contactId);
                if (Service.GetContact(contactId) == null)
                {
                     //varför är string emty bättre.
                    ModelState.AddModelError(String.Empty, "Fel inträffade när kontaktuppgift skulle Sparas.");
                    return;
                }

               // TODO: Ska lägga in isvalid här sen.

                    // Chanser, tryupdatemodel försöker spara min kontakt i min tabell. om true så sparar jag även i mitt affärslager.
                    if (TryUpdateModel(contact))
                    {
                        ContactListView.EnableViewState = true;
                        Service.SaveContact(contact);
                    }
                

            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade när Kunduppgift skulle Sparas.");
            }

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_DeleteItem(int contactId)
        {
            // TODO:
            try
            {
                Service.DeleteContact(contactId);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade när Kunduppgift skulle Raderas.");
            }
        }


    }
}
