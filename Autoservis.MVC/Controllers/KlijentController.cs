using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoservisBLL;

namespace Autoservis.MVC.Controllers
{

    public class KlijentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(KlijentInfoList.Get());
        }

        public ActionResult Details(int IdKlijenta)
        {
            return View(Klijent.Get(IdKlijenta));
        }

        public ActionResult Edit(int IdKlijenta)
        {
            return null;
        }

        [HttpPost]
        public ActionResult Delete(int IdKlijenta)
        {
            Klijent.Delete(IdKlijenta);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Klijent
        public ActionResult Create()
        {
            return View(Klijent.New());
        }

        [HttpPost]
        public ActionResult Create(string ImeKlijenta, string PrezimeKlijenta, string LozinkaKlijenta, string UlicaKlijenta, string KucniBrojKlijenta, int IdMjesto)
        {
            Klijent klijent = Klijent.New();
            klijent.ImeKlijenta = ImeKlijenta;
            klijent.PrezimeKlijenta = PrezimeKlijenta;
            klijent.LozinkaKlijenta = LozinkaKlijenta;
            klijent.UlicaKlijenta = UlicaKlijenta;
            klijent.KucniBrojKlijenta = KucniBrojKlijenta;
            klijent.IdMjesto = IdMjesto;

            System.Diagnostics.Debug.WriteLine(ImeKlijenta + " "+PrezimeKlijenta +" " +UlicaKlijenta + " " +KucniBrojKlijenta + " " +"");

            klijent = klijent.Save();
            return RedirectToAction("Index", "Home");
        }

     
    }
}