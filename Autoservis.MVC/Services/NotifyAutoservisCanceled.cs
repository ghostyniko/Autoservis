using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoservis.MVC.Services
{
    public class NotifyAutoservisCanceled : NotifyAutoservis
    {
        public override string GetMessage(TerminPregleda p)
        {
            return String.Format("Klijent {0} {1} odustaje od termina {2} za pregled vozila {3}", p.Klijent.ImeKlijenta, p.Klijent.PrezimeKlijenta, p.DatumIVrijemeTermina.ToLongDateString(), p.Vozilo.PuniNazivVozila);
        }
    }
}