using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autoservis.MVC.Controllers
{
    /// <summary>Kontroler za početnu stranicu</summary>
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>Metoda kontrolera koja generira pogled početne stranice</summary>
        /// <returns>Pogled početne stranice</returns>
        public ActionResult Index()
        {
            return View();
        }

    }
}