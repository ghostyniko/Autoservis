using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoservis.MVC.Services
{
    public class NotifyClientNewAppointment : NotifyClient
    {
        public override string GetMessage(TerminPregleda p)
        {
            return String.Format("Za pregled vozila {0} autoservis nudi novi termin: {1}", p.Vozilo.PuniNazivVozila, p.DatumIVrijemeTermina.ToLongDateString());
        }
    }
}