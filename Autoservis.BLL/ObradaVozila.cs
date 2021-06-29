//#define POGRESKA1
//#define POGRESKA2
//#define POGRESKA_VALIDACIJE

//#define POGRESKA_REFERENCIJSKI_INTEGRITET
//#define POGRESKA_POGRESNO_ZAPISIVANJE


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
using Autoservis.Properties;


namespace Autoservis.BLL
{
    [Serializable()]
    public class ObradaVozila:BusinessBase<ObradaVozila>
    {

        #region Constructors
        private ObradaVozila()
        {
        }

        #endregion

        #region  Properties
        private static PropertyInfo<int> IdObradeProperty =
          RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<ObradaVozila>(x => x.IdObrade)));
        public int IdObrade
        {
            get { return GetProperty(IdObradeProperty); }
        }

        private static PropertyInfo<DateTime> DatumZaprimanjaProperty =
        RegisterProperty(typeof(ObradaVozila), new PropertyInfo<DateTime>(Reflector.GetPropertyName<ObradaVozila>(x => x.DatumZaprimanja)));
        public DateTime DatumZaprimanja
        {
            get { return GetProperty(DatumZaprimanjaProperty); }
            set { SetProperty(DatumZaprimanjaProperty, value); }
        }

        private static PropertyInfo<DateTime?> DatumPreuzimanjaProperty =
         RegisterProperty(typeof(ObradaVozila), new PropertyInfo<DateTime?>(Reflector.GetPropertyName<ObradaVozila>(x => x.DatumPreuzimanja)));
        public DateTime? DatumPreuzimanja
        {
            get { return GetProperty(DatumPreuzimanjaProperty); }
            set { SetProperty(DatumPreuzimanjaProperty, value); }
        }

        private static PropertyInfo<string> OpisProperty =
            RegisterProperty(typeof(ObradaVozila), new PropertyInfo<string>(Reflector.GetPropertyName<ObradaVozila>(x => x.Opis)));
        public string Opis
        {
            get { return GetProperty(OpisProperty); }
            set { SetProperty(OpisProperty, value); }
        }

        private static PropertyInfo<Vozilo> VoziloProperty =
            RegisterProperty(typeof(ObradaVozila), new PropertyInfo<Vozilo>(Reflector.GetPropertyName<ObradaVozila>(x => x.Vozilo)));
        public Vozilo Vozilo
        {
            get { return GetProperty(VoziloProperty); }
            set { SetProperty(VoziloProperty, value); }
        }


        private static PropertyInfo<SudionikObradeList> SudioniciObradeVozilaProperty =
      RegisterProperty(typeof(ObradaVozila), new PropertyInfo<SudionikObradeList>(Reflector.GetPropertyName<ObradaVozila>(x => x.SudioniciObrade)));
        public SudionikObradeList SudioniciObrade
        {
            get
            {
                if (!(FieldManager.FieldExists(SudioniciObradeVozilaProperty)))
                {
                    LoadProperty(SudioniciObradeVozilaProperty, SudionikObradeList.New());
                }
                return GetProperty(SudioniciObradeVozilaProperty);
            }
        }

        #endregion
        #region  Validation Rules
        protected override void AddBusinessRules()
        {
            
            ValidationRules.AddRule(CommonRules.StringRequired, OpisProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(OpisProperty, 300));

            ValidationRules.AddRule<ObradaVozila>(DateCheckDatumZaprimanja<ObradaVozila>, DatumZaprimanjaProperty);
            ValidationRules.AddRule<ObradaVozila>(DateCheckDatumPreuzimanja<ObradaVozila>, DatumPreuzimanjaProperty);

            ValidationRules.AddRule<ObradaVozila>(StartDateGTEEndDate<ObradaVozila>, DatumPreuzimanjaProperty);

            ValidationRules.AddDependentProperty(DatumZaprimanjaProperty, DatumPreuzimanjaProperty, true);


        }

#if POGRESKA_VALIDACIJE
        private static bool StartDateGTEEndDate<T>(T target, RuleArgs e) where T : ObradaVozila
        {
            if (target.ReadProperty(DatumPreuzimanjaProperty).HasValue && target.ReadProperty(DatumZaprimanjaProperty) <= target.ReadProperty(DatumPreuzimanjaProperty))
            {
                e.Description = Resource.DatumError;
                return false;
            }
            else
            {
                return true;
            }
        }
#else
            private static bool StartDateGTEEndDate<T>(T target, RuleArgs e) where T : ObradaVozila
        {
            if (target.ReadProperty(DatumPreuzimanjaProperty).HasValue && target.ReadProperty(DatumZaprimanjaProperty) >= target.ReadProperty(DatumPreuzimanjaProperty))
            {
                e.Description = Resource.DatumError;
                return false;
            }
            else
            {
                return true;
            }
        }
#endif
        private static bool DateCheckDatumZaprimanja<T>(T target, RuleArgs e) where T : ObradaVozila
        {
            DateTime tempData;
            return DateTime.TryParse(target.DatumZaprimanja.ToString(), out tempData);
            
          
        }

        private static bool DateCheckDatumPreuzimanja<T>(T target, RuleArgs e) where T : ObradaVozila
        {
            DateTime tempData;
            if (!target.DatumPreuzimanja.HasValue) return true;
            return DateTime.TryParse(target.DatumPreuzimanja.ToString(), out tempData);


        }

#endregion
#region Factory Methods

        public static ObradaVozila New()
        {
            return DataPortal.Create<ObradaVozila>();
        }
        public static ObradaVozila Get(int idObradaVozila)
        {
            return DataPortal.Fetch<ObradaVozila>(new SingleCriteria<ObradaVozila, int>(idObradaVozila));
        }
        public static void Delete(int idObradaVozila)
        {
            DataPortal.Delete<ObradaVozila>(new SingleCriteria<ObradaVozila, int>(idObradaVozila));
        }

        #endregion



        #region Data Access


        private void DataPortal_Fetch(SingleCriteria<ObradaVozila, int> criteria)
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {

                // var data = (from o in ctx.DataContext.Osoba where o.IdOsobe == criteria.Value select o).Single();
                var data = ctx.DataContext.ObradaVozilaSet.Find(criteria.Value);
                var zapObr = ctx.DataContext.ZaposlenikObradaSet.Include("Zaposlenik")
                    .Where(x => x.ObradaVozilaIdObrada == criteria.Value).ToArray();

                LoadProperty(IdObradeProperty, data.IdObrada);
                LoadProperty(DatumZaprimanjaProperty, data.DatumIVrijemeZaprimanja);
                LoadProperty(DatumPreuzimanjaProperty, data.DatumIVrijemePreuzimanja);
                LoadProperty(OpisProperty, data.Opis);
                LoadProperty(VoziloProperty, Vozilo.Get(data.VoziloIdVozilo));
                LoadProperty(SudioniciObradeVozilaProperty, SudionikObradeList.Load(zapObr));
            }
        }

#if POGRESKA_REFERENCIJSKI_INTEGRITET
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {

                DAL.ObradaVozila ob = new DAL.ObradaVozila
                {
                    DatumIVrijemeZaprimanja = DatumZaprimanja,
                    DatumIVrijemePreuzimanja = null,
                    Opis = Opis,
                    
                };

                ctx.DataContext.ObradaVozilaSet.Add(ob);
                ctx.DataContext.SaveChanges();

                LoadProperty(IdObradeProperty, ob.IdObrada);

                FieldManager.UpdateChildren(this);
            }
        }
#elif POGRESKA_POGRESNO_ZAPISIVANJE
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {

                DAL.ObradaVozila ob = new DAL.ObradaVozila
                {
                    DatumIVrijemeZaprimanja = DatumZaprimanja,
                    DatumIVrijemePreuzimanja = null,
                    Opis = Opis,
                    VoziloIdVozilo = Vozilo.IdVozila

                };

                ctx.DataContext.ObradaVozilaSet.Add(ob);
                ctx.DataContext.SaveChanges();

                LoadProperty(IdObradeProperty, ob.IdObrada);

                FieldManager.UpdateChildren(this);
            }
        }
#else
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {

                DAL.ObradaVozila ob = new DAL.ObradaVozila
                {
                    DatumIVrijemeZaprimanja = DatumZaprimanja,
                    DatumIVrijemePreuzimanja = DatumPreuzimanja,
                    Opis = Opis,
                    VoziloIdVozilo = Vozilo.IdVozila

                };

                ctx.DataContext.ObradaVozilaSet.Add(ob);
                ctx.DataContext.SaveChanges();

                LoadProperty(IdObradeProperty, ob.IdObrada);

                FieldManager.UpdateChildren(this);
            }
        }
#endif


        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {
                DAL.ObradaVozila ob = ctx.DataContext.ObradaVozilaSet.Find(this.IdObrade);

                ob.Opis = Opis;
                ob.DatumIVrijemeZaprimanja = DatumZaprimanja;
                ob.DatumIVrijemePreuzimanja = DatumPreuzimanja;
                ob.VoziloIdVozilo = Vozilo.IdVozila;
                FieldManager.UpdateChildren(this);

                ctx.DataContext.SaveChanges();
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new SingleCriteria<ObradaVozila, int>(IdObrade));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(SingleCriteria<ObradaVozila, int> criteria)
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {
                var o = ctx.DataContext.ObradaVozilaSet.Find(criteria.Value);
                if (o != null)
                {
                    var obradaZap = o.ZaposleniciObrada.ToList();
                    foreach (var i in obradaZap)
                    {
                        ctx.DataContext.ZaposlenikObradaSet.Remove(i);
                    }
                    ctx.DataContext.ObradaVozilaSet.Remove(o);
                    ctx.DataContext.SaveChanges();
                }
            }
        }
#endregion

    }
}
