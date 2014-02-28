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

        // Property to Save my confirmationmessage from previous session. After used it delete the sessionmsg.
        public string SessionProp
        {
            get
            {
                var confirmationMessage = Session["text"] as string;
                Session.Remove("text");
                return confirmationMessage;
            }

            set { Session["text"] = value; }
        }
        private bool HasMessage
        {
            get { return Session["text"] != null; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HasMessage) 
            {
                PlaceHolder.Visible = true;
                ConfirmationMessage.Text = SessionProp;
            }
        }
        // Genererar alla kontakter.
        public IEnumerable<Äventyrliga_kontakter.Model.Contact> ContactListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            //var fullContactList = Service.GetContacts();
            return Service.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount).OrderBy(c => c.FirstName);
        }

        public void ContactListView_InsertItem(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveContact(contact);
                    SessionProp = String.Format("Du har laddat upp | Förnamn: {0} | EfterNamn: {1} | E-Post: {2} |", contact.FirstName, contact.LastName, contact.EmailAddress);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Fel inträffade när Kunduppgift skulle Läggas till.");
                }
                Response.RedirectToRoute("contact");
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_UpdateItem(int contactId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var contact = Service.GetContact(contactId);
                    if (contact == null)
                    {
                        ModelState.AddModelError(String.Empty, "Fel inträffade när kontaktuppgift skulle Sparas.");
                        return;
                    }
                   
                    // //Chanser, tryupdatemodel Validerar objktet Contact, eftersom vi hämtar det från server.
                    if (TryUpdateModel(contact))
                    {
                        Service.SaveContact(contact);
                    }
                    PlaceHolder.Visible = true;
                    ConfirmationMessage.Text = String.Format(" Efter Redigering är uppgifterna | Förnamn: {0} | EfterNamn: {1} | E-Post: {2} | sparade.", contact.FirstName, contact.LastName, contact.EmailAddress);
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
