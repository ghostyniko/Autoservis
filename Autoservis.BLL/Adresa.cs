using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autoservis.DAL;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace Autoservis
{
    public class Adresa:BusinessBase<Adresa>
    {
        #region Constructors
        private Adresa()
        {
        }
        #endregion

        #region  Properties
        private static PropertyInfo<int> IdAdreseProperty =
          RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<Adresa>(x => x.IdAdrese)));
        public int IdAdrese
        {
            get { return GetProperty(IdAdreseProperty); }
        }

        private static PropertyInfo<string> NazivUliceProperty =
        RegisterProperty(typeof(Adresa), new PropertyInfo<string>(Reflector.GetPropertyName<Adresa>(x => x.NazivUlice)));
        public string NazivUlice
        {
            get { return GetProperty(NazivUliceProperty); }
            set { SetProperty(NazivUliceProperty, value); }
        }

        private static PropertyInfo<string> KucniBrojProperty =
        RegisterProperty(typeof(Adresa), new PropertyInfo<string>(Reflector.GetPropertyName<Adresa>(x => x.KucniBroj)));
        public string KucniBroj
        {
            get { return GetProperty(KucniBrojProperty); }
            set { SetProperty(KucniBrojProperty, value); }
        }

        private static PropertyInfo<Mjesto> MjestoProperty =
        RegisterProperty(typeof(Adresa), new PropertyInfo<Mjesto>(Reflector.GetPropertyName<Adresa>(x => x.Mjesto)));
        public Mjesto Mjesto
        {
            get { return GetProperty(MjestoProperty); }
            set { SetProperty(MjestoProperty, value); }
        }

        private static PropertyInfo<int> IdMjestoProperty =
       RegisterProperty(typeof(Adresa), new PropertyInfo<int>(Reflector.GetPropertyName<Adresa>(x => x.IdMjesto)));
        public int IdMjesto
        {
            get { return GetProperty(IdMjestoProperty); }
            set { SetProperty(IdMjestoProperty, value); }
        }

        #endregion
        #region Factory Methods

        public static Adresa New()
        {
            return DataPortal.Create<Adresa>();
        }

        #endregion
        #region Data Access
        private void DataPortal_Fetch(SingleCriteria<Adresa, int> criteria)
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(Database.ProjektConnectionString))
            {
                // var data = (from o in ctx.DataContext.Osoba where o.IdOsobe == criteria.Value select o).Single();
                var data = ctx.DataContext.AdresaSet.Find(criteria.Value);

                LoadProperty(IdAdreseProperty, data.IdAdresa);
                LoadProperty(NazivUliceProperty, data.Naziv);
                LoadProperty(KucniBrojProperty, data.KucniBroj);
                LoadProperty(MjestoProperty, data.Mjesto);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {
                DAL.Adresa ad = new DAL.Adresa
                {
                    KucniBroj = KucniBroj,
                    Naziv = NazivUlice,
                    MjestoIdMjesto = IdMjesto
                };

                ctx.DataContext.AdresaSet.Add(ad);
                ctx.DataContext.SaveChanges();
                LoadProperty(IdAdreseProperty, ad.IdAdresa);
                LoadProperty(MjestoProperty, ad.Mjesto);

                FieldManager.UpdateChildren(this);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {
                DAL.Adresa ad = ctx.DataContext.AdresaSet.Find(this.IdAdrese);

                ad.Naziv = NazivUlice;
                ad.KucniBroj = KucniBroj;
                ad.MjestoIdMjesto = IdMjesto;

                FieldManager.UpdateChildren(this);

                ctx.DataContext.SaveChanges();
            }
        }

        #endregion
    }
}
