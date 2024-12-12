using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TTDoanVien
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route cho Edit DoanVien
            routes.MapRoute(
                name: "EditDoanVien",
                url: "Admin/DoanVien/Edit/{id}",
                defaults: new { controller = "DoanVien", action = "Edit", id = UrlParameter.Optional }
            );

            // Route cho Create DoanVien
            routes.MapRoute(
                name: "CreateDoanVien",
                url: "Admin/DoanVien/Create",
                defaults: new { controller = "DoanVien", action = "Create" }
            );
            routes.MapRoute(
                name: "DeleteDoanVien",
                url: "Admin/DoanVien/Delete/{id}",
                defaults: new { controller = "DoanVien", action = "Delete" }
            );


            // Route mặc định
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
