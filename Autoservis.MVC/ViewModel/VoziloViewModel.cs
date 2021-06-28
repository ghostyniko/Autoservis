using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autoservis.MVC.ViewModel
{
    public class VoziloViewModel
    {
        public int IdKlijenta { get; set; }
       
        public Vozilo Vozilo { get; set; } = Vozilo.New();
    }
}