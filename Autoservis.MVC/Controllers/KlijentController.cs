using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
//using System.Messaging;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Autoservis;

namespace Autoservis.MVC.Controllers
{

    /// <summary>Kontroler koji obrađuje akcije vezane uz klijenta</summary>
    public class KlijentController : Controller
    {
        /// <summary>Poziva se nakon zahtjeva za pregled popisa svih klijenata.</summary>
        /// <returns>Akcija koja generira pogled koji sadrži popis svih klijenata.</returns>
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View(KlijentInfoList.Get());
        }

        /// <summary>Poziva se nakon zahtjeva za pregledom detalja klijenta.</summary>
        /// <param name="IdKlijenta">Identikikator klijenta za kojeg se želi pregled detalja.</param>
        /// <returns>Akcija koja generira pogled koji sadrži detalje o klijentu.</returns>
        public ActionResult Details(int IdKlijenta)
        {
            var termini = TerminPregledaInfoList.Get(IdKlijenta);
            /*var messages = Receive(IdKlijenta);*/

            ViewBag.Message = "";

            ViewBag.Termini = termini;
            return View(Klijent.Get(IdKlijenta));
        }

        /// <summary>Obrađuje GET zahtjev</summary>
        /// <overloads>Poziva se nakon zahtjeva za uređivanje podataka o klijentu.</overloads>
        /// <param name="IdKlijenta">Identifikator klijenta čiji se podatci uređuju.</param>
        /// <returns>Akcija koja generira pogled koji sadrži obrazac popunjen s trenutnim podatcima o klijentu te koji se može uređivati.</returns>
        public ActionResult Edit(int IdKlijenta)
        {
            Klijent k = Klijent.Get(IdKlijenta);
            return View(k);
        }

        /// <summary>Obrađuje POST zahtjev</summary>
        /// <overloads>Poziva se nakon podnošena obrasca. Ažuriraju se elementi objekta Klijent. U slučaju pogreške, vraća se obrazac za uređivanje podataka s porukom greške.</overloads>
        /// <param name="IdKlijenta">Identifikator klijenta čiji se podatci uređuju.</param>
        /// <param name="ImeKlijenta">Novo ime klijenta.</param>
        /// <param name="PrezimeKlijenta">Novo prezime klijenta.</param>
        /// <param name="LozinkaKlijenta">Nova lozinka klijenta.</param>
        /// <param name="UlicaKlijenta">Nova ulica stanovanja klijenta.</param>
        /// <param name="KucniBrojKlijenta">Novi kućni broj klijenta.</param>
        /// <param name="IdMjesto">Identifikator novog mjesta stanovanja klijenta.</param>
        /// <returns>U slučaju uspješnog ažuriranja vraća se akcija koja generira pogled s detaljima o klijentu. Inače, vraća se akcija koja generira pogled s obrascem za
        /// uređivanjem s porukom o greškama.</returns>
        [HttpPost]
        public ActionResult Edit(int IdKlijenta, string ImeKlijenta, string PrezimeKlijenta, string LozinkaKlijenta, string UlicaKlijenta, string KucniBrojKlijenta, int IdMjesto)
        {
            Klijent klijent = null;
            try
            {
                klijent = Klijent.Get(IdKlijenta);
                klijent.ImeKlijenta = ImeKlijenta;
                klijent.PrezimeKlijenta = PrezimeKlijenta;
                klijent.LozinkaKlijenta = LozinkaKlijenta;
                klijent.UlicaKlijenta = UlicaKlijenta;
                klijent.KucniBrojKlijenta = KucniBrojKlijenta;
                klijent.IdMjesto = IdMjesto;
                klijent.Save();
                return RedirectToAction("Details", new
                {
                    IdKlijenta = klijent.IdKlijenta
                });
            }
            catch (Csla.Validation.ValidationException ex)
            {
                ViewBag.Pogreska = ex.Message;
                if (klijent.BrokenRulesCollection.Count > 0)
                {
                    List<string> errors = new List<string>();
                    foreach (Csla.Validation.BrokenRule rule in klijent.BrokenRulesCollection)
                    {
                        errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
                        ModelState.AddModelError(rule.Property, rule.Description);
                    }
                    ViewBag.ErrorsList = errors;
                }
                return View(klijent);
            }
            catch (Csla.DataPortalException ex)
            {
                ViewBag.Pogreska = ex.BusinessException.Message;
                return View(klijent);
            }
            catch (Exception ex)
            {
                ViewBag.Pogreska = ex.Message;
                return View(klijent);
            }
        }


        /// <summary>Poziva se nakon zahtjeva za brisanjem klijenta. Instanca objekta Klijent se briše. U slučaju pogreške, vraća se pogled s porukom pogreške.</summary>
        /// <param name="IdKlijenta">Identifikator klijenta kojeg se želi izbrisati</param>
        /// <returns>U slučaju uspješnog brisanja, vraća se pogled s listom klijenata. Inače, vraća se originalni pogled s porukom pogreške.</returns>
        [HttpPost]
        public ActionResult Delete(int IdKlijenta)
        {
            try
            {
                Klijent.Delete(IdKlijenta);
                Queue.Queue.Delete(IdKlijenta);
            }
            catch (Csla.DataPortalException ex)
            {
                ViewBag.Pogreska = ex.BusinessException.Message;
                TempData["Pogreska"] = ex.BusinessException.Message;
                return RedirectToAction("Details", new { IdKlijenta = IdKlijenta });
            }
            catch (Exception ex)
            {
                TempData["Pogreska"] = ex.Message;
                return RedirectToAction("Details", new { IdKlijenta = IdKlijenta });
            }

            return RedirectToAction("Index");
        }

        /// <summary>Obrađuje GET zahtjev za kreiranje novog korisnika.</summary>
        /// <overloads>Poziva se nakon zahtjeva za kreiranje novog korisnika. Generira pogled koji sadrži obrazac za unos podataka.</overloads>
        /// <returns>Pogled koji predstavlja obrazac za unos podataka o novom korisniku.</returns>
        [HttpGet]
        // GET: Klijent
        public ActionResult Create()
        {
            ViewBag.Mjesta = new SelectList(MjestoList.Get(), "IdMjesto", "Mjesto");
            return View("Create",Klijent.New());
        }

        /// <summary>Obrađuje POST zahtjev za kreiranje novog korisnika.</summary>
        /// <overloads>Poziva se nakon podnošenja (submit) podataka. Na temelju podataka stvara se nova instanca objekta Klijent te se objekt sprema. U slučaju pogreške validacije
        /// ili neke druge pogreške, vraća se obrazac za unos podataka.</overloads>
        /// <param name="ImeKlijenta">Ime novog klijenta</param>
        /// <param name="PrezimeKlijenta">Prezime novog klijenta</param>
        /// <param name="LozinkaKlijenta">Lozinka novog klijenta</param>
        /// <param name="UlicaKlijenta">Ulica stanovanja novog klijenta</param>
        /// <param name="KucniBrojKlijenta">Kućni broj novog klijenta</param>
        /// <param name="IdMjesto">Identifikator mjesta u kojem novi klijent stanuje</param>
        /// <returns>Ovisno o uspjehu unosa, vraća se odgovarajući pogled. U slučaju uspjeha, vrši se preusmjeravanje na akciju koja vraća pogled s detaljima novog klijenta. U
        /// slučaju pogreške, vraća se pogled s obrascem za unos podataka s obavijestima o pogreškama.</returns>
        [HttpPost]
        public ActionResult Create(string ImeKlijenta, string PrezimeKlijenta, string LozinkaKlijenta, string UlicaKlijenta, string KucniBrojKlijenta, int IdMjesto)
        {
            Klijent klijent = Klijent.New();
            try
            {
                klijent.ImeKlijenta = ImeKlijenta;
                klijent.PrezimeKlijenta = PrezimeKlijenta;
                klijent.LozinkaKlijenta = LozinkaKlijenta;
                klijent.UlicaKlijenta = UlicaKlijenta;
                klijent.KucniBrojKlijenta = KucniBrojKlijenta;
                klijent.IdMjesto = IdMjesto;

                // System.Diagnostics.Debug.WriteLine(ImeKlijenta + " "+PrezimeKlijenta +" " +UlicaKlijenta + " " +KucniBrojKlijenta + " " +"");

                klijent = klijent.Save();
                Queue.Queue.Create(klijent.IdKlijenta);
                return RedirectToAction("Details", new { IdKlijenta = klijent.IdKlijenta });
            }
            catch (Csla.Validation.ValidationException ex)
            {
                ViewBag.Pogreska = ex.Message;
                if (klijent.BrokenRulesCollection.Count > 0)
                {
                    List<string> errors = new List<string>();
                    foreach (Csla.Validation.BrokenRule rule in klijent.BrokenRulesCollection)
                    {
                        errors.Add(string.Format("{0}: {1}", rule.Property, rule.Description));
                        ModelState.AddModelError(rule.Property, rule.Description);
                    }
                    ViewBag.ErrorsList = errors;
                }
                return View(klijent);
            }
            catch (Csla.DataPortalException ex)
            {
                ViewBag.Pogreska = ex.BusinessException.Message;
                return View(klijent);
            }
            catch (Exception ex)
            {
                ViewBag.Pogreska = ex.Message;
                return View(klijent);
            }
        }

        /// <summary>Poziva se nakon što se zatraži kreiranje novog vozila za klijenta.</summary>
        /// <param name="IdKlijenta">Identifikator klijenta za kojeg se želi kreirati vozilo.</param>
        /// <returns>Akcija koja vrši preusmjeravanje na akciju za kreiranje vozila.</returns>
        [HttpGet]

        public ActionResult DodajVozilo(int IdKlijenta)
        {
            return RedirectToAction("Create", "Vozilo", new { idKlijenta = IdKlijenta });
        }

        /// <summary>Poziva se nakon zahtjeva za brisanjem vozila klijenta. Vrši se brisanja objekta tipa Vozilo.</summary>
        /// <param name="IdKlijenta">Identifikator klijenta čije se vozilo želi izbrisati.</param>
        /// <param name="IdVozila">Identifikator vozila koje se želi izbrisati.</param>
        /// <returns>Akcija koja generira pogled s detaljima o klijentu.</returns>
        [HttpPost]

        public ActionResult IzbrisiVozilo(int IdKlijenta, int IdVozila)
        {
            Vozilo.Delete(IdVozila);
            return RedirectToAction("Details", "Klijent", new { IdKlijenta = IdKlijenta });
        }

        /*
        private string Receive(int IdKlijenta)
        {
            if (!Queue.Queue.Exists(IdKlijenta)) return "";
            StringBuilder sb = new StringBuilder();

            var queue = Queue.Queue.GetClientMQ(IdKlijenta);
            Message[] messages = queue.GetAllMessages();

            foreach (Message m in messages)
            {
                m.Formatter = new XmlMessageFormatter(

                    new String[] { "System.String, mscorlib" });

                var mess = (string)m.Body;
                sb.Append(mess + "\n");
                queue.Receive();

            }

            queue.Close();
            return sb.ToString();

        }*/

        /// <summary>Poziva se nakon što se zatraži uređivanje termina pregleda od strane klijenta.</summary>
        /// <param name="IdTermina">Identifikator termina koji se želi uređivati.</param>
        /// <returns>Akcija koja vrši preusmjeravanje na akciju Edit kontrolera TerminPregleda.</returns>
        [HttpGet]

        public ActionResult UrediTermin(int IdTermina)
        {
            return RedirectToAction("Edit", "TerminPregleda", new { IdTermina = IdTermina, klijentUredio = true });
        }

        /// <summary>Poziva se nakon što se izvrši prihvat termina od strane klijenta. Objekt tipa TerminPregleda propušta se kroz radni tok.</summary>
        /// <param name="IdTermina">Identifikator termina koji se želi prihvatiti.</param>
        /// <returns>Akcija koja vrši preusmjeravanje na akciju generiranja pogleda s detaljima o klijentu.</returns>
        [HttpGet]

        public ActionResult PrihvatiTermin(int IdTermina)
        {
            TerminPregleda termin = TerminPregleda.Get(IdTermina);

            var workflow = new Appointment();
            Dictionary<string, object> inputs = new Dictionary<string, object>();
            inputs["Termin"] = termin;
            var results = WorkflowInvoker.Invoke(workflow, inputs);

            return RedirectToAction("Details", new { IdKlijenta = termin.IdKlijenta });
        }

        /// <summary>Poziva se nakon što se zatraži poništavanje termina pregleda. Vrši se promjena statusa objekta tipa TerminPregleda u poništeno.</summary>
        /// <param name="IdTermina">Identifikator termina koji se želi poništiti.</param>
        /// <returns>Akcija koja vrši preusmjeravanje na akciju generiranja pogleda s detaljima o klijentu.</returns>
        [HttpGet]
        public ActionResult PonistiTermin(int IdTermina)
        {
            TerminPregleda termin = TerminPregleda.Get(IdTermina);
            termin.Status = Status.Ponisteno;
            var workflow = new Appointment();
            Dictionary<string, object> inputs = new Dictionary<string, object>();
            inputs["Termin"] = termin;
            var results = WorkflowInvoker.Invoke(workflow, inputs);

            return RedirectToAction("Details", new { IdKlijenta = termin.IdKlijenta });
        }


    }
}