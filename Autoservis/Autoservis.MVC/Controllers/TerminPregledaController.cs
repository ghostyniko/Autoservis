using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autoservis.MVC.Controllers
{
    /// <summary>Kontroler koji obrađuje akcije vezane uz termine pregleda vozila.</summary>
    public class TerminPregledaController : Controller
    {
        /// <summary>Poziva se nakonšto se zatraži pregled detalja termina.</summary>
        /// <param name="IdTermina">Identifikator termina za koji se želi pregled detalja.</param>
        /// <returns>Akcija koja generira pogled s detaljima o terminu.</returns>
        [HttpGet]
        public ActionResult Details(int IdTermina)
        {

            TerminPregleda termin = TerminPregleda.Get(IdTermina);

            return View(termin);
        }
        /// <summary>Obrađuje GET zahtjev.</summary>
        /// <overloads>Poziva se nakon zahtjeva za uređivanje podataka o terminu.</overloads>
        /// <param name="IdTermina">Identifikator termina koji se uređuje.</param>
        /// <param name="klijentUredio">Varijabla koja sadrži informaciju o tome je li podatke mijenjao klijent ili voditelj autoservisa.</param>
        /// <returns>Akcija koja generira pogled koji sadrži obrazac popunjen s trenutnim podatcima o terminu te koji se može uređivati.</returns>
        [HttpGet]
        public ActionResult Edit(int IdTermina, bool klijentUredio)
        {
            ViewBag.KlijentUredio = klijentUredio;

            TerminPregleda termin = TerminPregleda.Get(IdTermina);
            return View(termin);
        }

        /// <summary>Obrađuje POST zahtjev.</summary>
        /// <overloads>Poziva se nakon podnošena obrasca. Ažuriraju se elementi objekta TerminPregleda te se objekt propušta kroz tok rada. U slučaju pogreške, vraća se obrazac za
        /// uređivanje podataka s porukom greške.</overloads>
        /// <param name="IdTermina">Identifikator termina koji se uređuje.</param>
        /// <param name="DatumIVrijemeTermina">Novi datum i vrijeme termina.</param>
        /// <param name="klijentUredio">Varijabla koja sadrži informaciju o tome je li podatke mijenjao klijent ili voditelj autoservisa.</param>
        /// <returns>U slučaju uspješnog ažuriranja vraća se akcija koja generira pogled s detaljima o inicijatoru izmjene (klijent ili voditelj autoservisa, ovisno o varijabli
        /// klijentUredio). Inače, vraća se akcija koja generira pogled s obrascem za uređivanje termina s porukom o greškama.</returns>
        [HttpPost]
        public ActionResult Edit(int IdTermina, DateTime DatumIVrijemeTermina, bool klijentUredio)
        {
            TerminPregleda termin = null;
            try
            {
                termin = TerminPregleda.Get(IdTermina);

                termin.DatumIVrijemeTermina = DatumIVrijemeTermina;


                var workflow = new Appointment();
                Dictionary<string, object> inputs = new Dictionary<string, object>();
                inputs["Termin"] = termin;
                var results = WorkflowInvoker.Invoke(workflow, inputs);
                // termin.Save();
                if ((bool)results["IsValid"] == false)
                {
                    throw new Csla.Validation.ValidationException();
                }
                if (klijentUredio)
                    return RedirectToAction("Details", "Klijent", new { IdKlijenta = termin.IdKlijenta });
                else
                    return RedirectToAction("Index", "Voditelj", null);
            }
            catch (Csla.Validation.ValidationException ex)
            {

                if (termin.BrokenRulesCollection.Count > 0)
                {
                    List<string> errors = new List<string>();
                    foreach (Csla.Validation.BrokenRule rule in termin.BrokenRulesCollection)
                    {
                        errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
                        ModelState.AddModelError(rule.Property, rule.Description);
                    }
                    ViewBag.ErrorsList = errors;
                }
                ViewBag.KlijentUredio = klijentUredio;
                return View(termin);
            }
            catch (Csla.DataPortalException ex)
            {
                ViewBag.Pogreska = ex.BusinessException.Message;
                ViewBag.KlijentUredio = klijentUredio;
                return View(termin);
            }
            catch (Exception ex)
            {
                ViewBag.Pogreska = ex.Message;
                ViewBag.KlijentUredio = klijentUredio;
                return View(termin);
            }
        }




        /// <summary>Obrađuje GET zahtjev</summary>
        /// <overloads>Poziva se nakon zahtjeva za unosom novog termina pregleda vozila. Vraća se obrazac za unos podataka o terminu.</overloads>
        /// <param name="IdKlijenta">Identifikator klijenta koji stvara novi termin pregleda.</param>
        /// <returns>Akcija koja generira pogled s obrascem za unos podataka o terminu.</returns>
        [HttpGet]
        // GET: TerminPregleda
        public ActionResult Create(int IdKlijenta)
        {
            TerminPregleda termin = TerminPregleda.New();
            termin.IdKlijenta = IdKlijenta;
            return View(termin);

        }

        /// <summary>Obrađuje POST zahtjev</summary>
        /// <overloads>Poziva se nakon podnošenja (submit) podataka. Na temelju podataka stvara se nova instanca objekta TerminPregleda te se objekt propušta kroz radni tok. U
        /// slučaju pogreške validacije ili neke druge pogreške, vraća se obrazac za unos podataka.</overloads>
        /// <param name="IdKlijenta">Identifikator klijenta koji stvara novi termin.</param>
        /// <param name="IdVozila">Identifikator vozila za koje se stvara novi termin pregleda.</param>
        /// <param name="DatumIVrijemeTermina">Datum i vrijeme termina.</param>
        /// <returns>Akcija koja generira pogled s detaljima o klijentu.</returns>
        [HttpPost]
        public ActionResult Create(int IdKlijenta, int IdVozila, DateTime DatumIVrijemeTermina)
        {
            TerminPregleda termin = TerminPregleda.New();


            try
            {
                termin.IdKlijenta = IdKlijenta;
                // termin.Klijent = Klijent.Get(IdKlijenta);
                //  termin.Vozilo = Vozilo.Get(IdVozila);
                termin.IdVozila = IdVozila;
                termin.DatumIVrijemeTermina = DatumIVrijemeTermina;
                termin.Status = Status.Kreirano;

                var workflow = new Appointment();
                Dictionary<string, object> inputs = new Dictionary<string, object>();
                inputs["Termin"] = termin;
                var results = WorkflowInvoker.Invoke(workflow, inputs);

                if ((bool)results["IsValid"] == false)
                {
                    throw new Csla.Validation.ValidationException();
                }
                //termin = termin.Save();
                return RedirectToAction("Details", "Klijent", new { IdKlijenta = IdKlijenta });
            }

            catch (Csla.Validation.ValidationException ex)
            {

                if (termin.BrokenRulesCollection.Count > 0)
                {
                    List<string> errors = new List<string>();
                    foreach (Csla.Validation.BrokenRule rule in termin.BrokenRulesCollection)
                    {
                        errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
                        ModelState.AddModelError(rule.Property, rule.Description);
                    }
                    ViewBag.ErrorsList = errors;
                }
                return View(termin);
            }
            catch (Csla.DataPortalException ex)
            {
                ViewBag.Pogreska = ex.BusinessException.Message;
                return View(termin);
            }
            catch (Exception ex)
            {
                ViewBag.Pogreska = ex.Message;
                return View(termin);
            }
        }
    }
}