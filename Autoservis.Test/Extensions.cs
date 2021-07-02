using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autoservis.BLL;

namespace Autoservis.Test
{
    public static class Extensions
    {
        public static Klijent GetDefault(this Klijent klijent)
        {
            klijent.ImeKlijenta = "Default";
            klijent.PrezimeKlijenta = "Default";
           
            klijent.UlicaKlijenta = "Default";
            klijent.KucniBrojKlijenta = "Default";
            klijent.MjestoKlijenta = Mjesto.New().GetDefault();
            return klijent;
        }

        public static Mjesto GetDefault(this Mjesto mjesto)
        {
            mjesto.NazivMjesta = "Default";
            mjesto.PostanskiBroj = 10000;
            return mjesto;
        }

        public static Vozilo GetDefault(this Vozilo vozilo)
        {
            vozilo.MarkaVozila = "Default";
            vozilo.TipVozila = "Default";
            vozilo.GodinaProizvodnje = 1999;
            vozilo.Vlasnik = Klijent.New().GetDefault();
            return vozilo;
        }

        public static ObradaVozila GetDefault(this ObradaVozila obrada)
        {
            obrada.Vozilo = Vozilo.New().GetDefault();
            obrada.DatumZaprimanja = new DateTime(2019, 1, 1);
            obrada.DatumPreuzimanja = new DateTime(2019, 2, 1);
            obrada.Opis = "Default";
            return obrada;
        }
    }
}
