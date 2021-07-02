using System;
using Autoservis.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autoservis.BLL;

namespace Autoservis.Test
{
    [TestClass]
    public class ObradaVozilaTest
    {
        private  static Autoservis.BLL.ObradaVozila obrada = null;

       [TestInitialize]
        public void PodesiDAL()
        {
            //Autoservis.DAL.ContextConfigurer<AutoservisDATAContainer>.ConfigureTest();
            
        }

        private void ObradaInit()
        {
            Autoservis.DAL.ContextConfigurer<AutoservisDATAContainer>.ConfigureTest();
            obrada = ObradaVozila.New().GetDefault();
            var vozilo = obrada.Vozilo;
            var klijent = vozilo.Vlasnik;
            var mjesto = klijent.MjestoKlijenta.Save();
            klijent.IdMjesto = mjesto.IdMjesta;
            klijent.MjestoKlijenta = mjesto;
           
            vozilo.Vlasnik = vozilo.Vlasnik.Save();
            obrada.Vozilo = obrada.Vozilo.Save();
            
           
        }

        private void ObradaDelete()
        {
            var voz = obrada.Vozilo;
            var klijent = voz.Vlasnik;
            var mjesto = klijent.MjestoKlijenta;

            ObradaVozila.Delete(obrada.IdObrade);
            Vozilo.Delete(voz.IdVozila);
            Klijent.Delete(klijent.IdKlijenta);
            Mjesto.Delete(mjesto.IdMjesta);
        }

        [TestMethod]
        public void TestPrazniPodatci()
        {
            ObradaVozila obradaVozila = ObradaVozila.New();

            bool validActual = obradaVozila.IsValid;
            bool validExpected = false;
            Assert.AreEqual(validExpected, validActual);
        }

        [TestMethod]
        public void TestValidacija()
        {
            ObradaInit();
            bool isValidActual;
            bool isValidExpected = true;

            isValidActual = obrada.IsValid;
            Assert.AreEqual(isValidExpected, isValidActual);

        }

        [TestMethod]
        public void TestPohranjivanje()
        {
           
            
                //ObradaInit();

                Exception exception = null;

                try
                {
                    obrada = obrada.Save();
                }

                catch (Exception ex)
                {
                    exception = ex;

                }

                Assert.IsNull(exception);
                Assert.IsNotNull(obrada);
                     
            
        }

        [TestMethod]
        public void TestCitanje()
        {
          /* ObradaInit();

            obrada.Save();*/
            var procitanaObrada = ObradaVozila.Get(obrada.IdObrade);

            Assert.AreEqual(obrada.IdObrade, procitanaObrada.IdObrade);
            Assert.AreEqual(obrada.DatumPreuzimanja, procitanaObrada.DatumPreuzimanja);
            Assert.AreEqual(obrada.DatumZaprimanja, procitanaObrada.DatumZaprimanja);
            Assert.AreEqual(obrada.Vozilo.IdVozila, procitanaObrada.Vozilo.IdVozila);
        }

    }
}
