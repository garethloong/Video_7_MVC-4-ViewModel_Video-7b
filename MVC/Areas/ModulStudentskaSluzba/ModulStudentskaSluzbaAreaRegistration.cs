using System.Web.Mvc;

namespace MVC.Areas.ModulStudentskaSluzba
{
    // "ModulStudentskaSluzba" je naziv ovog Area, i namijenjen je teti u Studentskoj sluzbi za dodavanje studenata, ovjeru semestara itd.
    public class ModulStudentskaSluzbaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ModulStudentskaSluzba";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ModulStudentskaSluzba_default",
                "ModulStudentskaSluzba/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}