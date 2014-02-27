using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Äventyrliga_kontakter
{
    public class RouteConfig
    {
        public static void SetRoute(RouteCollection route)
        {
            route.MapPageRoute("contact", "Start", "~/default.aspx");
            route.MapPageRoute("Start", "Start", "~/default.aspx");
            route.MapPageRoute("error", "Error", "~/");
        }
    }
}