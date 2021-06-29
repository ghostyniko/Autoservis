using Autoservis.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autoservis.MVC.Controllers
{
    /// <summary>Kontroler koji obrađuje akcije vezane uz obradu vozila.</summary>
    public class ObradaController : Controller
    {


        /// <summary>Poziva se nakon zahtjeva za pregledom detalja vozila.</summary>
        /// <param name="IdObrade">Identifikator obrade za koju se vrši pregled detalja.</param>
        /// <returns>Akcija koja generira pogled koji sadrži detalje o obradi vozila.</returns>
        [HttpGet]
        public ActionResult Details(int IdObrade)
        {
            return View(ObradaVozila.Get(IdObrade));
        }

        /// <summary>Poziva se nakon zahtjeva za brisanjem obrade vozila. Briše se objekt tipa ObradaVozila.</summary>
        /// <param name="IdObrade">Identifikator obrade koja se briše.</param>
        /// <param name="IdVozila">Identifikator vozila čija se obrada briše.</param>
        /// <returns>Akcija koja vrši preusjeravanje na akciju Details kontrolera Vozilo, što rezultira prikazom detalja vozila čija je obrada izbrisana.</returns>
        [HttpPost]
        public ActionResult Delete(int IdObrade, int IdVozila)
        {
            ObradaVozila.Delete(IdObrade);
            return RedirectToAction("Details", "Vozilo", new { IdVozila = IdVozila });
        }

        /// <summary>Obrađuje GET zahtjev.</summary>
        /// <overloads>Poziva se nakon zahtjeva za unosom nove obrade vozila. Vraća se obrazac za unos podataka o obradi vozila.</overloads>
        /// <param name="IdVozila">Identifikator vozila za koje se unosi nova obrada.</param>
        /// <returns>Akcija koja generira pogled s obrascem za unos podataka o obradi.</returns>
        [HttpGet]
        public ActionResult Create(int IdVozila)
        {
            ObradaVozila o = ObradaVozila.New();
            o.Vozilo = Vozilo.Get(IdVozila);

            return View(o);
        }

        /// <summary>Obrađuje GET zahtjev</summary>
        /// <overloads>Poziva se nakon što se zatraži uređivanje obrade. Vraća se obrazac za uređivanje podataka.</overloads>
        /// <param name="IdObrade">Identikikator obrade čiji se podatci uređuju.</param>
        /// <returns>Akcija koja generira pogled s obrascem za uređivanje podataka.</returns>
        public ActionResult Edit(int IdObrade)
        {
            var k = ObradaVozila.Get(IdObrade);
            return View(k);
        }

        /// <summary>Obrađuje POST zahtjev</summary>
        /// <overloads>Poziva se nakon podnošena obrasca. Ažuriraju se elementi objekta ObradaVozila. U slučaju pogreške, vraća se obrazac za uređivanje podataka s porukom greške.</overloads>
        /// <param name="IdObrade">Identifikator obrade koja se uređuje.</param>
        /// <param name="DatumZaprimanja">Novi datum zaprimanja vozila.</param>
        /// <param name="DatumPreuzimanja">Novi datum preuzimanja vozila.</param>
        /// <param name="Opis">Novi opis obrade.</param>
        /// <returns>U slučaju uspješnog ažuriranja vraća se akcija koja generira pogled s detaljima o obradi. Inače, vraća se akcija koja generira pogled s obrascem za uređivanjem
        /// s porukom o greškama.</returns>
        [HttpPost]
        public ActionResult Edit(int IdObrade, DateTime DatumZaprimanja, DateTime? DatumPreuzimanja, string Opis)
        {
            ObradaVozila ObradaVozila = null;

            try
            {
                ObradaVozila = ObradaVozila.Get(IdObrade);
                ObradaVozila.DatumZaprimanja = DatumZaprimanja;
                ObradaVozila.DatumPreuzimanja = DatumPreuzimanja;
                ObradaVozila.Opis = Opis;

                ObradaVozila o = ObradaVozila.Save();
                return RedirectToAction("Details", "Obrada", new { IdObrade = o.IdObrade });
            }

            catch (Csla.Validation.ValidationException ex)
            {
                ViewBag.Pogreska = ex.Message;
                if (ObradaVozila.BrokenRulesCollection.Count > 0)
                {
                    List<string> errors = new List<string>();
                    foreach (Csla.Validation.BrokenRule rule in ObradaVozila.BrokenRulesCollection)
                    {
                        errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
                        ModelState.AddModelError(rule.Property, rule.Description);
                    }
                    ViewBag.ErrorsList = errors;
                }
                return View(ObradaVozila);
            }
            catch (Csla.DataPortalException ex)
            {
                ViewBag.Pogreska = ex.BusinessException.Message;
                return View(ObradaVozila);
            }
            catch (Exception ex)
            {
                ViewBag.Pogreska = ex.Message;
                return View(ObradaVozila);
            }
        }

        /// <summary>Obrađuje POST zahtjev.</summary>
        /// <overloads>Poziva se nakon podnošenja (submit) podataka. Na temelju podataka stvara se nova instanca objekta ObradaVozila te se objekt sprema. U slučaju pogreške
        /// validacije ili neke druge pogreške, vraća se obrazac za unos podataka.</overloads>
        /// <param name="IdVozila">Identifikator vozila za koje se unosi nova obrada.</param>
        /// <param name="DatumZaprimanja">Datum zaprimanja vozila.</param>
        /// <param name="DatumPreuzimanja">Datum preuzimanja vozila.</param>
        /// <param name="Opis">Opis obrade vozila.</param>
        /// <returns>Ovisno o uspjehu unosa, vraća se odgovarajući pogled. U slučaju uspjeha, vrši se preusmjeravanje na akciju koja vraća pogled s detaljima nove obrade. U slučaju
        /// pogreške, vraća se pogled s obrascem za unos podataka s obavijestima o pogreškama.</returns>
        [HttpPost]
        public ActionResult Create(int IdVozila, DateTime DatumZaprimanja, DateTime? DatumPreuzimanja, string Opis)
        {
            ObradaVozila ObradaVozila = ObradaVozila.New();

            try
            {
                ObradaVozila.Vozilo = Vozilo.Get(IdVozila);
                ObradaVozila.DatumZaprimanja = DatumZaprimanja;
                ObradaVozila.DatumPreuzimanja = DatumPreuzimanja;
                ObradaVozila.Opis = Opis;

                ObradaVozila o = ObradaVozila.Save();
                return RedirectToAction("Details", "Obrada", new { IdObrade = o.IdObrade });
            }

            catch (Csla.Validation.ValidationException ex)
            {
                ViewBag.Pogreska = ex.Message;
                if (ObradaVozila.BrokenRulesCollection.Count > 0)
                {
                    List<string> errors = new List<string>();
                    foreach (Csla.Validation.BrokenRule rule in ObradaVozila.BrokenRulesCollection)
                    {
                        errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
                        ModelState.AddModelError(rule.Property, rule.Description);
                    }
                    ViewBag.ErrorsList = errors;
                }
                return View(ObradaVozila);
            }
            catch (Csla.DataPortalException ex)
            {
                ViewBag.Pogreska = ex.BusinessException.Message;
                return View(ObradaVozila);
            }
            catch (Exception ex)
            {
                ViewBag.Pogreska = ex.Message;
                return View(ObradaVozila);
            }
        }

        /// <summary>Poziva se nakon zahtjeva za dodjelom zaposlenika obradi.</summary>
        /// <param name="IdZaposlenika">Identifikator zaposlenika koji se dodaje kao sudionik obrade.</param>
        /// <param name="IdObrade">Identikikator obrade kojoj se dodaje zaposlenik.</param>
        /// <returns>Akcija koja generira pogled s detaljima o obradi.</returns>
        public ActionResult DodijeliZaposlenika(int IdZaposlenika, int IdObrade)
        {
            try
            {
                ObradaVozila obrada = ObradaVozila.Get(IdObrade);
                obrada.SudioniciObrade.DodijeliZaposlenika(IdZaposlenika);
                obrada.Save();
            }
            catch (Exception ex)
            {
                TempData["Pogreska"] = ex.Message;
            }
            return RedirectToAction("Details", new { IdObrade = IdObrade });
        }

        /// <summary>Poziva se nakon što se zatraži uklanjanje zaposlenika kao sudionika obrade.</summary>
        /// <param name="IdZaposlenika">Identifikator zaposlenika koji se uklanja s obrade vozila.</param>
        /// <param name="IdObrade">Identifikator obrade s koje se zaposlenik uklanja.</param>
        /// <returns>Akcija koja generira pogled s detaljima o obradi.</returns>
        [HttpPost]
        public ActionResult UkloniZaposlenika(int IdZaposlenika, int IdObrade)
        {
            try
            {
                ObradaVozila obrada = ObradaVozila.Get(IdObrade);
                obrada.SudioniciObrade.UkloniZaposlenika(IdZaposlenika);
                obrada.Save();
            }

            catch (Exception ex)
            {
                TempData["Pogreska"] = ex.Message;
            }
            return RedirectToAction("Details", new { IdObrade = IdObrade });
        }

        /// <summary>Poziva se nakon što se zatraži promjena broja popravaka koje je zaposlenik izvršio u sklopu obrade vozila.</summary>
        /// <param name="IdZaposlenika">Identifikator zaposlenika za kojeg se ažurira broj popravaka.</param>
        /// <param name="IdObrade">Identifikator obrade.</param>
        /// <param name="NoviBroj">Novi broj popravaka zaposlenika.</param>
        /// <returns>U slučaju uspjeha, vraća poruku o uspjehu izvršenja promjene broja popravka. U suprotnom, vraća poruku o grešci.</returns>
        [HttpPost]
        public string PromijeniBroj(int IdZaposlenika, int IdObrade, int NoviBroj)
        {
            try
            {
                ObradaVozila obrada = ObradaVozila.Get(IdObrade);
                var obradaZap = obrada.SudioniciObrade.GetSudionikObrade(IdZaposlenika);
                obradaZap.BrojPopravaka = NoviBroj;

                obrada.Save();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}