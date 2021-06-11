using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;
using Csla.Data;
using Csla.Validation;
using Autoservis.DAL;

namespace Autoservis
{
    [Serializable()]
    public class Zaposlenik:BusinessBase<Zaposlenik>
    {
        #region Constructors
        private Zaposlenik()
        {
        }

        #endregion

        #region  Properties
        private static PropertyInfo<int> IdZaposlenikaProperty =
          RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<Zaposlenik>(x => x.IdZaposlenika)));
        public int IdZaposlenika
        {
            get { return GetProperty(IdZaposlenikaProperty); }
        }

        private static PropertyInfo<string> PrezimeZaposlenikaProperty =
        RegisterProperty(typeof(Zaposlenik), new PropertyInfo<string>(Reflector.GetPropertyName<Zaposlenik>(x => x.PrezimeZaposlenika)));
        public string PrezimeZaposlenika
        {
            get { return GetProperty(PrezimeZaposlenikaProperty); }
            set { SetProperty(PrezimeZaposlenikaProperty, value); }
        }

        private static PropertyInfo<string> ImeZaposlenikaProperty =
        RegisterProperty(typeof(Zaposlenik), new PropertyInfo<string>(Reflector.GetPropertyName<Zaposlenik>(x => x.ImeZaposlenika)));
        public string ImeZaposlenika
        {
            get { return GetProperty(ImeZaposlenikaProperty); }
            set { SetProperty(ImeZaposlenikaProperty, value); }
        }


        private static PropertyInfo<string> UlicaZaposlenikaProperty =
        RegisterProperty(typeof(Zaposlenik), new PropertyInfo<string>(Reflector.GetPropertyName<Zaposlenik>(x => x.UlicaZaposlenika)));
        public string UlicaZaposlenika
        {
            get { return GetProperty(UlicaZaposlenikaProperty); }
            set { SetProperty(UlicaZaposlenikaProperty, value); }
        }

        private static PropertyInfo<string> KucniBrojZaposlenikaProperty =
        RegisterProperty(typeof(Zaposlenik), new PropertyInfo<string>(Reflector.GetPropertyName<Zaposlenik>(x => x.KucniBrojZaposlenika)));
        public string KucniBrojZaposlenika
        {
            get { return GetProperty(KucniBrojZaposlenikaProperty); }
            set { SetProperty(KucniBrojZaposlenikaProperty, value); }
        }

        private static PropertyInfo<Mjesto> MjestoZaposlenikaProperty =
        RegisterProperty(typeof(Zaposlenik), new PropertyInfo<Mjesto>(Reflector.GetPropertyName<Zaposlenik>(x => x.MjestoZaposlenika)));
        public Mjesto MjestoZaposlenika
        {
            get { return GetProperty(MjestoZaposlenikaProperty); }
            set { SetProperty(MjestoZaposlenikaProperty, value); }
        }

        private static PropertyInfo<int> IdMjestoProperty =
        RegisterProperty(typeof(Zaposlenik), new PropertyInfo<int>(Reflector.GetPropertyName<Zaposlenik>(x => x.MjestoZaposlenika)));
        public int IdMjesto
        {
            get { return GetProperty(IdMjestoProperty); }
            set { SetProperty(IdMjestoProperty, value); }
        }

        private static PropertyInfo<DateTime> DatumZaposlenjaProperty =
       RegisterProperty(typeof(Zaposlenik), new PropertyInfo<DateTime>(Reflector.GetPropertyName<Zaposlenik>(x => x.DatumZaposlenja)));
        public DateTime DatumZaposlenja
        {
            get { return GetProperty(DatumZaposlenjaProperty); }
            set { SetProperty(DatumZaposlenjaProperty, value); }
        }

        private static PropertyInfo<ObradaSudioniciList> ObradeProperty =
       RegisterProperty(typeof(Zaposlenik), new PropertyInfo<ObradaSudioniciList>(Reflector.GetPropertyName<Zaposlenik>(x => x.DatumZaposlenja)));
        public ObradaSudioniciList Obrade
        {
            get
            {
                if (!(FieldManager.FieldExists(ObradeProperty)))
                {
                    LoadProperty(ObradeProperty, ObradaSudioniciList.New());
                }
                return GetProperty(ObradeProperty);
            }
        }


        #endregion

        #region  Validation Rules
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.StringRequired, ImeZaposlenikaProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(ImeZaposlenikaProperty, 25));

            ValidationRules.AddRule(CommonRules.StringRequired, PrezimeZaposlenikaProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(PrezimeZaposlenikaProperty, 25));

            ValidationRules.AddRule(CommonRules.StringRequired, UlicaZaposlenikaProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(UlicaZaposlenikaProperty, 50));

            ValidationRules.AddRule(CommonRules.StringRequired, KucniBrojZaposlenikaProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(KucniBrojZaposlenikaProperty, 10));
        }
        #endregion
        #region Factory Methods

        public static Zaposlenik New()
        {
            return DataPortal.Create<Zaposlenik>();
        }
        public static Zaposlenik Get(int idZaposlenika)
        {
            return DataPortal.Fetch<Zaposlenik>(new SingleCriteria<Zaposlenik, int>(idZaposlenika));
        }
        public static void Delete(int idZaposlenika)
        {
            DataPortal.Delete<Zaposlenik>(new SingleCriteria<Zaposlenik, int>(idZaposlenika));
        }
        #endregion
        #region Data Access
        private void DataPortal_Fetch(SingleCriteria<Zaposlenik, int> criteria)
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {

                // var data = (from o in ctx.DataContext.Osoba where o.IdOsobe == criteria.Value select o).Single();
                var data = ctx.DataContext.ZaposlenikSet.Find(criteria.Value);

                var obr = ctx.DataContext.ZaposlenikObradaSet.Include("ObradaVozila").Include("ObradaVozila.Vozilo")
                    .Where(x => x.ZaposlenikIdZaposlenik == criteria.Value).ToArray();

                LoadProperty(IdZaposlenikaProperty, data.IdZaposlenik);
                LoadProperty(ImeZaposlenikaProperty, data.Ime);
                LoadProperty(PrezimeZaposlenikaProperty, data.Prezime);
               
                LoadProperty(UlicaZaposlenikaProperty, data.IdAdresa.Naziv);
                LoadProperty(KucniBrojZaposlenikaProperty, data.IdAdresa.KucniBroj);
                LoadProperty(MjestoZaposlenikaProperty, Mjesto.Get(data.IdAdresa.MjestoIdMjesto));
                
                LoadProperty(IdMjestoProperty, data.IdAdresa.MjestoIdMjesto);
                LoadProperty(DatumZaposlenjaProperty, data.DatumZaposlenja);
                LoadProperty(ObradeProperty, ObradaSudioniciList.Load(obr));

            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {

                DAL.Zaposlenik zap = new DAL.Zaposlenik
                {
                    Ime = ImeZaposlenika,
                    Prezime = PrezimeZaposlenika,
                    IdAdresa = new DAL.Adresa
                    {
                        Naziv = UlicaZaposlenika,
                        KucniBroj = KucniBrojZaposlenika,
                        MjestoIdMjesto = IdMjesto
                    },
                    DatumZaposlenja = DatumZaposlenja
                };

                ctx.DataContext.ZaposlenikSet.Add(zap);
                ctx.DataContext.SaveChanges();

                LoadProperty(IdZaposlenikaProperty, zap.IdZaposlenik);

                FieldManager.UpdateChildren(this);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {
                DAL.Zaposlenik zap = ctx.DataContext.ZaposlenikSet.Find(this.IdZaposlenika);

                zap.Ime = ImeZaposlenika;
                zap.Prezime = PrezimeZaposlenika;
                zap.IdAdresa.Naziv = UlicaZaposlenika;
                zap.IdAdresa.KucniBroj = KucniBrojZaposlenika;
                zap.IdAdresa.MjestoIdMjesto = IdMjesto;
                zap.DatumZaposlenja = DatumZaposlenja;

                FieldManager.UpdateChildren(this);

                ctx.DataContext.SaveChanges();
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new SingleCriteria<Zaposlenik, int>(IdZaposlenika));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(SingleCriteria<Zaposlenik, int> criteria)
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {
                var o = ctx.DataContext.ZaposlenikSet.Find(criteria.Value);
                if (o != null)
                {
                    ctx.DataContext.AdresaSet.Remove(o.IdAdresa);
                    ctx.DataContext.ZaposlenikSet.Remove(o);
                    ctx.DataContext.SaveChanges();
                }
            }
        }
        #endregion
    }

}
