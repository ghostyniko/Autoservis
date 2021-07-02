using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservis
{
    internal static class ObradaZaduzenja
    {
        #region  Business Methods
        public static int GetBrojPopravaka()
        {
            return 1;
        }
        #endregion


        #region  Data Access
        public static void DodajZaduzenje(int idObrade, int idZaposlenika)
        {
            using (var ctx = DAL.ContextManager<DAL.AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {
                DAL.ZaposlenikObrada zaduzenje = new DAL.ZaposlenikObrada
                {
                    ObradaVozilaIdObrada = idObrade,
                    ZaposlenikIdZaposlenik = idZaposlenika,
                    BrojPopravaka = 1
                };

                ctx.DataContext.ZaposlenikObradaSet.Add(zaduzenje);
                ctx.DataContext.SaveChanges();
            }
        }

        public static void PromijeniBrojPopravaka(int idObrade, int idZaposlenika,int noviBrojPopravaka)
        {
            using (var ctx = DAL.ContextManager<DAL.AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {
                try
                {
                    DAL.ZaposlenikObrada zaduzenje = ctx.DataContext.ZaposlenikObradaSet
                        .Where(x => x.ObradaVozilaIdObrada == idObrade && x.ZaposlenikIdZaposlenik == idZaposlenika).Single();

                    zaduzenje.BrojPopravaka = noviBrojPopravaka;
                    ctx.DataContext.SaveChanges();
                }
                catch
                {
                    new Exception("Neispravni broj");
                }
            }
        }

        public static void UkloniZaduzenje(int idObrade, int idZaposlenika)
        {
            using (var ctx = DAL.ContextManager<DAL.AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {
                var u = ctx.DataContext.ZaposlenikObradaSet.Find(idZaposlenika, idObrade);
                if (u != null)
                {
                    ctx.DataContext.ZaposlenikObradaSet.Remove(u);
                    ctx.DataContext.SaveChanges();
                }
            }
        }
        #endregion
    }
}
