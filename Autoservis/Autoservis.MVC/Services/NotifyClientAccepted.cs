using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autoservis.MVC.Services
{
    public class NotifyClientAccepted : NotifyClient
    {
        public override string GetMessage(TerminPregleda p)
        {
            return String.Format("Autoservis je prihvatio vaš termin: {0} {1}, {2}", p.Vozilo.MarkaVozila, p.Vozilo.TipVozila, p.DatumIVrijemeTermina.ToLongDateString());
        }
    }
}