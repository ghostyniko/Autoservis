using Autoservis.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autoservis.MVC;

namespace Autoservis.MVC.Controllers
{
    /// <summary>Kontroler koji obrađuje akcije vezane uz mjesto.</summary>
    public class MjestoController : Controller
    {
        /// <summary>Obrađuje GET zahtjev.</summary>
        /// <overloads>Poziva se nakon što se zatraži unos novog mjesta. Generira se obrazac za unos podataka o mjestu.</overloads>
        /// <returns>Akcija koja generira pogled koji sadrži obrazac za unos podataka o novom mjestu.</returns>
        [HttpGet]
        // GET: Mjesto
        public ActionResult Create()
        {
            return View(Mjesto.New());
        }

        /// <summary>Obrađuje POST zahtjev.</summary>
        /// <overloads>Poziva se nakon podnošenja (submit) podataka. Na temelju podataka stvara se nova instanca objekta Mjesto te se objekt sprema. U slučaju pogreške
        /// validacije ili neke druge pogreške, vraća se obrazac za unos podataka.</overloads>
        /// <param name="NazivMjesta">Naziv mjesta koje se unosi.</param>
        /// <param name="PostanskiBroj">Poštanski broj mjesta koje se unosi.</param>
        /// <returns>U slučaju uspjeha, vraća se akcija koja generira pogled početne stranice. U suprotnom, vraća se akcija koja generira originalni pogled za unos podataka s
        /// porukom greške.</returns>
        [HttpPost]
        public ActionResult Create(string NazivMjesta, int PostanskiBroj)
        {
            Mjesto mjesto = Mjesto.New();
            try
            {

                mjesto.NazivMjesta = NazivMjesta;
                mjesto.PostanskiBroj = PostanskiBroj;

                mjesto = mjesto.Save();
                Autoservis.BLL.MjestoList.InvalidateCache();

                return RedirectToAction("Index", "Home");
            }


            catch (Csla.Validation.ValidationException ex)
            {
                mjesto.HandleBusinessException(ex,this.ControllerContext);

               /* ViewBag.Pogreska = ex.Message;
                if (mjesto.BrokenRulesCollection.Count > 0)
                {
                    List<string> errors = new List<string>();
                    foreach (Csla.Validation.BrokenRule rule in mjesto.BrokenRulesCollection)
                    {
                        errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
                        ModelState.AddModelError(rule.Property, rule.Description);
                    }
                    ViewBag.ErrorsList = errors;
                }*/
                return View(mjesto);
            }
            catch (Csla.DataPortalException ex)
            {
                ViewBag.Pogreska = ex.BusinessException.Message;
                return View(mjesto);
            }
            catch (Exception ex)
            {
                ViewBag.Pogreska = ex.Message;
                return View(mjesto);
            }

        }
    }
}