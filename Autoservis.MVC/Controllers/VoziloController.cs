using Autoservis.MVC.ViewModel;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autoservis.MVC.Controllers
{
    /// <summary>Kontroler koji obrađuje akcije vezane uz vozilo.</summary>
    public class VoziloController : Controller
    {
      
      

        /// <summary>Poziva se nakon zahtjeva za pregledom detalja vozila.</summary>
        /// <param name="IdVozila">Identifikator vozila za koje se želi pregled detalja.</param>
        /// <returns>Akcija koja generira pogled koji sadrži detalje o vozilu.</returns>
        [HttpGet]
        public ActionResult Details(int IdVozila)
        {
            return View(Vozilo.Get(IdVozila));
        }

        /// <summary>Poziva se nakon zahtjeva za brisanjem vozila. Instanca objekta Vozilo se briše. U slučaju pogreške, vraća se pogled s porukom pogreške.</summary>
        /// <param name="IdKlijenta">Identifikator klijenta čije se vozilo briše.</param>
        /// <param name="IdVozila">Identifikator vozila koje se briše.</param>
        /// <returns>U slučaju uspješnog brisanja, vraća se pogled s detaljima klijenta. Inače, vraća se originalni pogled s porukom pogreške.</returns>
        [HttpPost]
        public ActionResult Delete(int IdKlijenta, int IdVozila)
        {
            try
            {
                Vozilo.Delete(IdVozila);
            }
            catch (Exception ex)
            {
                TempData["Pogreska"] = ex.Message;
            }
            return RedirectToAction("Details", "Klijent", new { IdKlijenta = IdKlijenta });
        }

        /// <summary>Obrađuje GET zahtjev.</summary>
        /// <overloads>Poziva se nakon zahtjeva za unosom nove obrade vozila. Vraća se obrazac za unos podataka o vozilu.</overloads>
        /// <param name="IdKlijenta">Identifikator klijenta za kojeg se unosi novo vozilo.</param>
        /// <returns>Akcija koja generira pogled s obrascem za unos podataka o vozilu.</returns>
        [HttpGet]
        public ActionResult Create(int IdKlijenta)
        {
            var viewModel = new VoziloViewModel() 
            { 
                IdKlijenta = IdKlijenta
            };

            return View(viewModel);
        }



        /// <summary>Obrađuje POST zahtjev.</summary>
        /// <overloads>Poziva se nakon podnošenja (submit) podataka. Na temelju podataka stvara se nova instanca objekta Vozilo te se objekt sprema. U slučaju pogreške
        /// validacije ili neke druge pogreške, vraća se obrazac za unos podataka.</overloads>
        /// <param name="IdKlijenta">Identifikator klijenta za kojeg se unosi novo vozilo.</param>
        /// <param name="MarkaVozila">Marka novog vozila.</param>
        /// <param name="TipVozila">Tip novog vozila.</param>
        /// <param name="GodinaProizvodnje">Godina proizvodnje novog vozila.</param>
        /// <returns>Ovisno o uspjehu unosa, vraća se odgovarajući pogled. U slučaju uspjeha, vrši se preusmjeravanje na akciju koja vraća pogled s detaljima novog vozila. U
        /// slučaju pogreške, vraća se pogled s obrascem za unos podataka s obavijestima o pogreškama.</returns>
        [HttpPost]
     
        public ActionResult Create([Bind(Include ="IdKlijenta,Vozilo")]VoziloViewModel voziloViewModel)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    voziloViewModel.Vozilo.Vlasnik = Klijent.Get(voziloViewModel.IdKlijenta);
                    voziloViewModel.Vozilo.Save();
                }
                catch (Exception ex)
                {
                    ViewBag.Pogreska = ex.Message;
                    return View(voziloViewModel);
                }
            }
           
            return View(voziloViewModel);
        /*
            try
            {
                vozilo.Vlasnik = Klijent.Get(IdKlijenta);
                
                // System.Diagnostics.Debug.WriteLine(ImeKlijenta + " "+PrezimeKlijenta +" " +UlicaKlijenta + " " +KucniBrojKlijenta + " " +"");

                vozilo = vozilo.Save();
                return RedirectToAction("Details", "Klijent", new { IdKlijenta = vozilo.Vlasnik.IdKlijenta });
            }
            catch (Csla.Validation.ValidationException ex)
            {
                ViewBag.Pogreska = ex.Message;
                if (vozilo.BrokenRulesCollection.Count > 0)
                {
                    List<string> errors = new List<string>();
                    foreach (Csla.Validation.BrokenRule rule in vozilo.BrokenRulesCollection)
                    {
                        errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
                        ModelState.AddModelError(rule.Property, rule.Description);
                    }
                    ViewBag.ErrorsList = errors;
                }
                return View(vozilo);
            }
            catch (Csla.DataPortalException ex)
            {
                ViewBag.Pogreska = ex.BusinessException.Message;
                return View(vozilo);
            }
            catch (Exception ex)
            {
                ViewBag.Pogreska = ex.Message;
                return View(vozilo);
            }*/
        }

        /// <summary>Obrađuje GET zahtjev.</summary>
        /// <overloads>Poziva se nakon što se zatraži uređivanje vozila. Vraća se obrazac za uređivanje podataka.</overloads>
        /// <param name="IdVozila">Identifikator vozila čiji se podatci uređuju.</param>
        /// <returns>Akcija koja generira pogled s obrascem za uređivanje podataka.</returns>
        public ActionResult Edit(int IdVozila)
        {
            Vozilo v = Vozilo.Get(IdVozila);
            return View(v);
        }

        /// <summary>Obrađuje POST zahtjev.</summary>
        /// <overloads>Poziva se nakon podnošena obrasca. Ažuriraju se elementi objekta Vozilo. U slučaju pogreške, vraća se obrazac za uređivanje podataka s porukom greške.</overloads>
        /// <param name="IdVozila">Identifikator vozila čiji se podatci uređuju.</param>
        /// <param name="MarkaVozila">Nova marka vozila.</param>
        /// <param name="TipVozila">Novi tip vozila.</param>
        /// <param name="GodinaProizvodnje">Nova godina proizvodnje vozila.</param>
        /// <returns>U slučaju uspješnog ažuriranja vraća se akcija koja generira pogled s detaljima o vozilu. Inače, vraća se akcija koja generira pogled s obrascem za uređivanjem
        /// s porukom o greškama.</returns>
        [HttpPost]
        public ActionResult Edit(int IdVozila, string MarkaVozila, string TipVozila, short GodinaProizvodnje)
        {
            Vozilo vozilo = null;
            try
            {
                vozilo = Vozilo.Get(IdVozila);
                vozilo.MarkaVozila = MarkaVozila;
                vozilo.TipVozila = TipVozila;
                vozilo.GodinaProizvodnje = GodinaProizvodnje;

                vozilo = vozilo.Save();
                return RedirectToAction("Details", "Vozilo", new { IdVozila = vozilo.IdVozila });
            }
            catch (Csla.Validation.ValidationException ex)
            {
                ViewBag.Pogreska = ex.Message;
                if (vozilo.BrokenRulesCollection.Count > 0)
                {
                    List<string> errors = new List<string>();
                    foreach (Csla.Validation.BrokenRule rule in vozilo.BrokenRulesCollection)
                    {
                        errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
                        ModelState.AddModelError(rule.Property, rule.Description);
                    }
                    ViewBag.ErrorsList = errors;
                }
                return View(vozilo);
            }
            catch (Csla.DataPortalException ex)
            {
                ViewBag.Pogreska = ex.BusinessException.Message;
                return View(vozilo);
            }
            catch (Exception ex)
            {
                ViewBag.Pogreska = ex.Message;
                return View(vozilo);
            }
        }

        /// <summary>Poziva se nakon zahtjeva za dodavanjem nove obrade vozila.</summary>
        /// <param name="IdVozila">Identifikator vozila za koje se unosi nova obrada.</param>
        /// <returns>Akcija preusmjeravanja na akciju Create kontrolera ObradaVozila.</returns>
        public ActionResult DodajObradu(int IdVozila)
        {
            return RedirectToAction("Create", "Obrada", new { IdVozila = IdVozila });
        }



    }
}