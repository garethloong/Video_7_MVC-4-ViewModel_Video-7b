using System.Web.Mvc;

namespace MVC.Areas.ModulStudenti
{
    // "ModulStudenti" je naziv ovog Area, i namijenjen je studentima, za pregled obavijesti, ocjena, prijavu ispita itd.
    public class ModulStudentiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulStudenti";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulStudenti_default",
                "ModulStudenti/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}