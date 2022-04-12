using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{

    // Defaultni controller(kad unesemo: http://localhost:50913/) - HomeController (mora imati ovaj naziv).
    // Nakon sto kreiramo controller ASP.NET MVC ce kreirat i odgovarajuci folder Home unutar View foldera.
    public class HomeController : Controller
    {
        // GET: home 
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}