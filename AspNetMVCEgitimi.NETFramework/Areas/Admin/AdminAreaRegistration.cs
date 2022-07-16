using System.Web.Mvc;

namespace AspNetMVCEgitimi.NETFramework.Areas.Admin
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
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Categories", action = "Index", id = UrlParameter.Optional } // Adres çubuğunda site adından sonra /Admin/ yazdığımızda varsayılan olarak hangi controller ve hangi action çalışsın.
            );
        }
    }
}