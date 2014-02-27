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
        public IEnumerable<Äventyrliga_kontakter.Model.Contact> ContactListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            //var fullContactList = Service.GetContacts();
            return Service.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount).OrderBy(c => c.FirstName);
        }

        public void ContactListView_InsertItem(Contact contact)
        {
            // Metod för lägga in kontakter till min databas. FATTTAR INTE MODELSTATE
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveContact(contact);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade när Kunduppgift skulle Läggas till.");
                }
                Response.RedirectToRoute("contact");
            }

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_UpdateItem(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var contact = Service.GetContact(contactId);
                    //if (Service.GetContact(contactId) == null)
                    //{
                    //    ModelState.AddModelError(String.Empty, "Fel inträffade när kontaktuppgift skulle Sparas.");
                    //    return;
                    //}
                    // TODO: Ska lägga in isvalid här sen.

                    // Chanser, tryupdatemodel Validerar objktet Contact, eftersom vi hämtar det från server.
                    if (TryUpdateModel(contact))
                    {
                        Service.SaveContact(contact);
                    }
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade när Kunduppgift skulle Sparas.");
                }
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
