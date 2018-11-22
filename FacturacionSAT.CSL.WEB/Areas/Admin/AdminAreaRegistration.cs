using System.Web.Mvc;

namespace FacturacionSAT.CSL.WEB.Areas.Admin
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
                 "Admin/{controller}/{action}/{id}/{id2}",
                 new { action = "Index", id = UrlParameter.Optional, id2 = UrlParameter.Optional }
             );
        }
    }
}