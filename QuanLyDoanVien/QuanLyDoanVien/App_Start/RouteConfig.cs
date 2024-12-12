using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyDoanVien
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route cho Hoạt Động
            routes.MapRoute(
                name: "HoatDong",
                url: "Admin/HoatDong",
                defaults: new { controller = "HoatDong", action = "HoatDong" }
            );

            // Route cho Chi Đoàn
            routes.MapRoute(
                name: "ChiDoan",
                url: "Admin/ChiDoan/ChiDoan",
                defaults: new { controller = "ChiDoan", action = "ChiDoan" }
            );

            // Route mặc định
            routes.MapRoute(
     name: "DoanVien",
     url: "Admin/DoanVien/{action}/{id}",
     defaults: new { controller = "DoanVien", action = "Index", id = UrlParameter.Optional }
 );
        }
    }
}
    
