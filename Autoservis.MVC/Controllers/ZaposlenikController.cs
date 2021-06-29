using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autoservis;
using Autoservis.BLL;

namespace Autoservis.MVC.Controllers
{
    /// <summary>Kontroler koji obrađuje akcije vezane uz zaposlenika.</summary>
    public class ZaposlenikController : Controller
    {
        /// <summary>Poziva se nakon zahtjeva za pregled popisa svih zaposlenika.</summary>
        /// <returns>Akcija koja generira pogled koji sadrži popis svih zaposlenika.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View(ZaposlenikInfoList.Get());
        }

        /// <summary>Poziva se nakon zahtjeva za pregledom detalja vozila.</summary>
        /// <param name="IdZaposlenika">Identifikator zaposlenika za koje se želi pregled detalja.</param>
        /// <returns>Akcija koja generira pogled koji sadrži detalje o zaposleniku.</returns>
        public ActionResult Details(int IdZaposlenika)
        {
            return View(Zaposlenik.Get(IdZaposlenika));
        }

        /// <summary>Obrađuje GET zahtjev.</summary>
        /// <overloads>Poziva se nakon što se zatraži uređivanje podataka o zaposleniku. Vraća se obrazac za uređivanje podataka.</overloads>
        /// <param name="IdZaposlenika">Identifikator zaposlenika čiji se podatci uređuju.</param>
        /// <returns>Akcija koja generira pogled s obrascem za uređivanje podataka.</returns>
        public ActionResult Edit(int IdZaposlenika)
        {
            var zap = Zaposlenik.Get(IdZaposlenika);
            return View(zap);
        }

        /// <summary>Obrađuje POST zahtjev.</summary>
        /// <overloads>Poziva se nakon podnošena obrasca. Ažuriraju se elementi objekta Zaposlenik. U slučaju pogreške, vraća se obrazac za uređivanje podataka s porukom greške.</overloads>
        /// <param name="IdZaposlenika">Identifikator zaposlenika čiji se podatci uređuju.</param>
        /// <param name="ImeZaposlenika">Novo ime zaposlenika.</param>
        /// <param name="PrezimeZaposlenika">Novo prezime zaposlenika.</param>
        /// <param name="UlicaZaposlenika">Nova ulica stanovanja zaposlenika.</param>
        /// <param name="KucniBrojZaposlenika">Novi kućni broj zaposlenika.</param>
        /// <param name="IdMjesto">Identifikator novog mjesta stanovanje zaposlenika.</param>
        /// <param name="DatumZaposlenja">Novi datum zaposlenja zaposlenika.</param>
        /// <returns>U slučaju uspješnog ažuriranja vraća se akcija koja generira pogled s detaljima o zaposleniku. Inače, vraća se akcija koja generira pogled s obrascem za
        /// uređivanjem s porukom o greškama.</returns>
        [HttpPost]
        public ActionResult Edit(int IdZaposlenika, string ImeZaposlenika, string PrezimeZaposlenika, string UlicaZaposlenika, string KucniBrojZaposlenika, int IdMjesto, DateTime DatumZaposlenja)
        {
            Zaposlenik Zaposlenik = null;
            try
            {
                Zaposlenik = Zaposlenik.Get(IdZaposlenika);
                Zaposlenik.ImeZaposlenika = ImeZaposlenika;
                Zaposlenik.PrezimeZaposlenika = PrezimeZaposlenika;
                Zaposlenik.UlicaZaposlenika = UlicaZaposlenika;
                Zaposlenik.KucniBrojZaposlenika = KucniBrojZaposlenika;
                Zaposlenik.IdMjesto = IdMjesto;
                Zaposlenik.DatumZaposlenja = DatumZaposlenja;
                Zaposlenik = Zaposlenik.Save();
                return RedirectToAction("Details", new { IdZaposlenika = Zaposlenik.IdZaposlenika });
            }
            catch (Csla.Validation.ValidationException ex)
            {
                ViewBag.Pogreska = ex.Message;
                if (Zaposlenik.BrokenRulesCollection.Count > 0)
                {
                    List<string> errors = new List<string>();
                    foreach (Csla.Validation.BrokenRule rule in Zaposlenik.BrokenRulesCollection)
                    {
                        errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
                        ModelState.AddModelError(rule.Property, rule.Description);
                    }
                    ViewBag.ErrorsList = errors;
                }
                return View(Zaposlenik);
            }
            catch (Csla.DataPortalException ex)
            {
                ViewBag.Pogreska = ex.BusinessException.Message;
                return View(Zaposlenik);
            }
            catch (Exception ex)
            {
                ViewBag.Pogreska = ex.Message;
                return View(Zaposlenik);
            }
        }


        /// <summary>Poziva se nakon zahtjeva za brisanjem zaposlenika. Instanca objekta Zaposlenika se briše. U slučaju pogreške, vraća se pogled s porukom pogreške.</summary>
        /// <param name="IdZaposlenika">Identifikator zaposlenika kojeg se briše.</param>
        /// <returns>U slučaju uspješnog brisanja, vraća se pogled s listom zaposlenika. Inače, vraća se originalni pogled s porukom pogreške.</returns>
        [HttpPost]
        public ActionResult Delete(int IdZaposlenika)
        {
            try
            {
                Zaposlenik.Delete(IdZaposlenika);
            }
            catch (Exception ex)
            {
                TempData["Pogreska"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        /// <summary>Obrađuje GET zahtjev.</summary>
        /// <overloads>Poziva se nakon zahtjeva za unosom novog zaposlenika. Vraća se obrazac za unos podataka o zaposleniku.</overloads>
        /// <returns>Akcija koja generira pogled s obrascem za unos podataka o novom zapoleniku.</returns>
        [HttpGet]
        // GET: Zaposlenik
        public ActionResult Create()
        {
            return View(Zaposlenik.New());
        }

        /// <summary>Obrađuje POST zahtjev.</summary>
        /// <overloads>Poziva se nakon podnošenja (submit) podataka. Na temelju podataka stvara se nova instanca objekta Zaposlenik te se objekt sprema. U slučaju pogreške
        /// validacije ili neke druge pogreške, vraća se obrazac za unos podataka.</overloads>
        /// <param name="ImeZaposlenika">Ime novog zaposlenika.</param>
        /// <param name="PrezimeZaposlenika">Prezime novog zaposlenika.</param>
        /// <param name="UlicaZaposlenika">Ulica stanovanje novg zaposlenika.</param>
        /// <param name="KucniBrojZaposlenika">Kućni broj novog zaposlenika.</param>
        /// <param name="IdMjesto">Identifikator mjesta stanovanja novog zaposlenika.</param>
        /// <param name="DatumZaposlenja">Datum zaposlenja novo zaposlenika.</param>
        /// <returns>Ovisno o uspjehu unosa, vraća se odgovarajući pogled. U slučaju uspjeha, vrši se preusmjeravanje na akciju koja vraća pogled s detaljima novog zaposlenika. U
        /// slučaju pogreške, vraća se pogled s obrascem za unos podataka s obavijestima o pogreškama.</returns>
        [HttpPost]
        public ActionResult Create(string ImeZaposlenika, string PrezimeZaposlenika, string UlicaZaposlenika, string KucniBrojZaposlenika, int IdMjesto, DateTime DatumZaposlenja)
        {
            Zaposlenik Zaposlenik = Zaposlenik.New();
            try
            {
                Zaposlenik.ImeZaposlenika = ImeZaposlenika;
                Zaposlenik.PrezimeZaposlenika = PrezimeZaposlenika;
                Zaposlenik.UlicaZaposlenika = UlicaZaposlenika;
                Zaposlenik.KucniBrojZaposlenika = KucniBrojZaposlenika;
                Zaposlenik.IdMjesto = IdMjesto;
                Zaposlenik.DatumZaposlenja = DatumZaposlenja;
                Zaposlenik = Zaposlenik.Save();
                return RedirectToAction("Details", new { IdZaposlenika = Zaposlenik.IdZaposlenika });
            }
            catch (Csla.Validation.ValidationException ex)
            {
                ViewBag.Pogreska = ex.Message;
                if (Zaposlenik.BrokenRulesCollection.Count > 0)
                {
                    List<string> errors = new List<string>();
                    foreach (Csla.Validation.BrokenRule rule in Zaposlenik.BrokenRulesCollection)
                    {
                        errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
                        ModelState.AddModelError(rule.Property, rule.Description);
                    }
                    ViewBag.ErrorsList = errors;
                }
                return View(Zaposlenik);
            }
            catch (Csla.DataPortalException ex)
            {
                ViewBag.Pogreska = ex.BusinessException.Message;
                return View(Zaposlenik);
            }
            catch (Exception ex)
            {
                ViewBag.Pogreska = ex.Message;
                return View(Zaposlenik);
            }
        }

        /// <summary>Poziva se nakon zahtjeva za popisom svih zaposlenika koji ne sudjeluju u obradi.</summary>
        /// <param name="IdObrade">Identifikator obrade za koju se traži popis svih zaposlenika koji ne sudjeluju u obradi.</param>
        /// <returns>Akcija koja generira pogled koji sadrži popis svih zaposlenika koji ne sudjeluju u obradi.</returns>
        public ActionResult Select(int IdObrade)
        {
            ViewData["IdObrade"] = IdObrade;
            ObradaVozila obrada = ObradaVozila.Get(IdObrade);
            var sudioniciObrade = obrada.SudioniciObrade.Select(o => o.IdZaposlenika);

            ZaposlenikInfoList svi = ZaposlenikInfoList.Get();
            var preostali = svi.Where(o => !sudioniciObrade.Contains(o.IdZaposlenika));
            return View(preostali);
        }

    }
}