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

      
        }
    }
