using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Äventyrliga_kontakter
{
    public class RouteConfig
    {
        // Extensionclass to "hide" page source. Using 2 atm error and Contact.
        public static void SetRoute(RouteCollection route)
        {
            route.MapPageRoute("error", "Error", "~/error.aspx");
            route.MapPageRoute("Start", "kontakter", "~/default.aspx");
            route.MapPageRoute("Default", "", "~/default.aspx");
        }
    }
}