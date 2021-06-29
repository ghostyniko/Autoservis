using Autoservis.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoservis.MVC.Services
{
    public class NotifyAutoservisNewAppointment : NotifyAutoservis
    {
        public override string GetMessage(TerminPregleda p)
        {
            return String.Format("Klijent {0} {1}  predlaže novi termin {3} za vozilo {2}", p.Klijent.PrezimeKlijenta, p.Klijent.ImeKlijenta, p.Vozilo.PuniNazivVozila, p.DatumIVrijemeTermina.ToLongDateString());
        }
    }
}