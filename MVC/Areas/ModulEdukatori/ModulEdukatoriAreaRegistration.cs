using System.Web.Mvc;

namespace MVC.Areas.ModulEdukatori
{
    // "ModulEdukatori" je naziv ovog Area, i namijenjen je profesorima za postavljanje materijala, unos ocjena itd.
    public class ModulEdukatoriAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulEdukatori";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulEdukatori_default",
                "ModulEdukatori/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}