using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoservis.MVC.Services
{
    public class NotifyAutoservisAccepted : NotifyAutoservis
    {
        public override string GetMessage(TerminPregleda p)
        {
            return String.Format("Klijent {0} {1} prihvaća termim {2} za vozilo {3}", p.Klijent.PrezimeKlijenta,p.Klijent.ImeKlijenta, p.DatumIVrijemeTermina.ToLongDateString(), p.Vozilo.PuniNazivVozila);
        }
    }
}