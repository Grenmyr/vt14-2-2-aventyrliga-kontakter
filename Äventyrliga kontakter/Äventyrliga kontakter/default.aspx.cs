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
       
        private Service Service  
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ContactListView_InsertItem()
        {
            Service.GetContact(10);

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_DeleteItem(int id)
        {

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_UpdateItem(int id)
        {

        }
    }
}