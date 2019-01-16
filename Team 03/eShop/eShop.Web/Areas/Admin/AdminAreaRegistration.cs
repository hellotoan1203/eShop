using System.Web.Mvc;

namespace eShop.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Admin",
                url: "admin",
                defaults: new { controller = "HomeAdmin", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "eShop.Web.Areas.Admin.Controllers" }
            );

            // context.MapRoute(
            //    "Admin_default",
            //    "Admin/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}