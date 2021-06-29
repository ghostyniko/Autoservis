using Autoservis.BLL;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
//using System.Messaging;

namespace Autoservis.MVC.Controllers
{
    /// <summary>Kontroler koji obrađuje akcije vezane uz voditelja autoservisa.</summary>
    public class VoditeljController : Controller
    {
        // GET: Voditelj
        /// <summary>Poziva se nakon zahtjeva za pregledom aktivnosti koji su u nadležnosti voditelja autoservisa.</summary>
        /// <returns>Akcija koja vraća pogled koji sadrži uvid u sve poslove za koje je nadležan voditelj.</returns>
        public ActionResult Index()
        {
            var list = TerminPregledaInfoList.Get();
            
            ViewBag.Poruke = "";
            return View(list);
        }

        /// <summary>Poziva se nakon što voditelj zatraži uređivanje termina. Objekt tipa TerminPregleda propušta se kroz radni tok.</summary>
        /// <param name="IdTermina">Identifikator termina za koji se vrši ažuriranje.</param>
        /// <returns>Akcija preusmjeravanja na akciju Index.</returns>
        [HttpGet]

        public ActionResult UrediTermin(int IdTermina)
        {
            return RedirectToAction("Edit", "TerminPregleda", new { IdTermina = IdTermina, klijentUredio = false });
        }

        /// <summary>Poziva se nakon što voditelj prihvati termin. Objekt tipa TerminPregleda propušta se kroz radni tok.</summary>
        /// <param name="IdTermina">Identifikator termina koji se prihvaća.</param>
        /// <returns>Akcija preusmjeravanja na akciju Index.</returns>
        public ActionResult PrihvatiTermin(int IdTermina)
        {
            TerminPregleda termin = TerminPregleda.Get(IdTermina);

            var workflow = new Appointment();
            Dictionary<string, object> inputs = new Dictionary<string, object>();
            inputs["Termin"] = termin;
            var results = WorkflowInvoker.Invoke(workflow, inputs);

            return RedirectToAction("Index");
        }

        /// <summary>Poziva se nakon što se zatraži brisanje termina pregleda iz popisa termina vidljivih od strane voditelja autoservisa.</summary>
        /// <param name="IdTermina">Identifikator termina koji se želi izbrisati.</param>
        /// <returns>Akcija koja generira pogled koji vraća detalje vidljive voditelju autoservisa.</returns>
        [HttpPost]
        public ActionResult IzbrisiTermin(int IdTermina)
        {

            TerminPregleda.Delete(IdTermina);
            return RedirectToAction("Index");
        }

        /*
        private string Receive()
        {

            StringBuilder sb = new StringBuilder();

            var queue = Queue.Queue.GetAutoservisMQ();

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
    }
}