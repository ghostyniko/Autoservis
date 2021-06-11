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
    public class Vozilo:BusinessBase<Vozilo>
    {
        #region Constructors
        private Vozilo()
        {
        }

        #endregion

        #region  Properties
        private static PropertyInfo<int> IdVozilaProperty =
          RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<Vozilo>(x => x.IdVozila)));
        public int IdVozila
        {
            get { return GetProperty(IdVozilaProperty); }
        }

        private static PropertyInfo<string> MarkaVozilaProperty =
        RegisterProperty(typeof(Vozilo), new PropertyInfo<string>(Reflector.GetPropertyName<Vozilo>(x => x.MarkaVozila)));
        public string MarkaVozila
        {
            get { return GetProperty(MarkaVozilaProperty); }
            set { SetProperty(MarkaVozilaProperty, value); }
        }

        private static PropertyInfo<string> TipVozilaProperty =
        RegisterProperty(typeof(Vozilo), new PropertyInfo<string>(Reflector.GetPropertyName<Vozilo>(x => x.TipVozila)));
        public string TipVozila
        {
            get { return GetProperty(TipVozilaProperty); }
            set { SetProperty(TipVozilaProperty, value); }
        }

        private static PropertyInfo<short> GodinaProizvodnjeProperty =
        RegisterProperty(typeof(Vozilo), new PropertyInfo<short>(Reflector.GetPropertyName<Vozilo>(x => x.GodinaProizvodnje)));
        public short GodinaProizvodnje
        {
            get { return GetProperty(GodinaProizvodnjeProperty); }
            set { SetProperty(GodinaProizvodnjeProperty, value); }
        }

        private static PropertyInfo<Klijent> VlasnikProperty =
        RegisterProperty(typeof(Vozilo), new PropertyInfo<Klijent>(Reflector.GetPropertyName<Vozilo>(x => x.Vlasnik)));
        public Klijent Vlasnik
        {
            get { return GetProperty(VlasnikProperty); }
            set { SetProperty(VlasnikProperty, value); }
        }
        private static PropertyInfo<ObradaVozilaInfoList> ObradaVozilaProperty =
        RegisterProperty(typeof(Vozilo), new PropertyInfo<ObradaVozilaInfoList>(Reflector.GetPropertyName<Vozilo>(x => x.ObradaVozila)));
        public ObradaVozilaInfoList ObradaVozila
        {
            get { return GetProperty(ObradaVozilaProperty); }
        }
        #endregion

        #region Calculated Properties
        public string PuniNazivVozila
        {
            get { return MarkaVozila + " " + TipVozila + ", "+GodinaProizvodnje; }
        }
        #endregion

        #region  Validation Rules
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.StringRequired, MarkaVozilaProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(MarkaVozilaProperty, 25));

            ValidationRules.AddRule(CommonRules.StringRequired, TipVozilaProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(TipVozilaProperty, 25));

            /*
            ValidationRules.AddRule(CommonRules.IntegerMinValue, new CommonRules.IntegerMinValueRuleArgs(GodinaProizvodnjeProperty, 1900));
            ValidationRules.AddRule(CommonRules.IntegerMaxValue, new CommonRules.IntegerMaxValueRuleArgs(GodinaProizvodnjeProperty, 2100));
            
            //   ValidationRules.AddRule(CommonRules.StringRequired, IdMjestoProperty);
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(KucniBrojKlijentaProperty, 10));


            /* ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(OIBProperty, 11));
             ValidationRules.AddRule<Osoba>(IsOIBValid, OIBProperty);
             ValidationRules.AddRule<Osoba>(IsOIBUnique, OIBProperty);*/
        }
        #endregion
        #region Factory Methods

        public static Vozilo New()
        {
            return DataPortal.Create<Vozilo>();
        }
        public static Vozilo Get(int idVozila)
        {
            return DataPortal.Fetch<Vozilo>(new SingleCriteria<Vozilo, int>(idVozila));
        }
        public static void Delete(int idVozila)
        {
            DataPortal.Delete<Vozilo>(new SingleCriteria<Vozilo, int>(idVozila));
        }
        #endregion
        #region Data Access
        private void DataPortal_Fetch(SingleCriteria<Vozilo, int> criteria)
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {
                // var data = (from o in ctx.DataContext.Osoba where o.IdOsobe == criteria.Value select o).Single();
                var data = ctx.DataContext.VoziloSet.Find(criteria.Value);

                LoadProperty(IdVozilaProperty, data.IdVozilo);
                LoadProperty(MarkaVozilaProperty, data.Marka);
                LoadProperty(TipVozilaProperty, data.Tip);
                LoadProperty(GodinaProizvodnjeProperty, data.GodinaProizvodnje);
                LoadProperty(VlasnikProperty, Klijent.Get(data.Klijent.IdKlijent));
                LoadProperty(ObradaVozilaProperty, ObradaVozilaInfoList.Get(data.IdVozilo));
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {
                DAL.Klijent vl = ctx.DataContext.KlijentSet.Find(Vlasnik.IdKlijenta);
                DAL.Vozilo voz = new DAL.Vozilo
                {
                    
                    Marka = MarkaVozila,
                    Tip = TipVozila,
                    GodinaProizvodnje = GodinaProizvodnje,
                    Klijent = vl

                };

                ctx.DataContext.VoziloSet.Add(voz);
                ctx.DataContext.SaveChanges();

                LoadProperty(IdVozilaProperty, voz.IdVozilo);

                FieldManager.UpdateChildren(this);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {
                DAL.Vozilo voz = ctx.DataContext.VoziloSet.Find(this.IdVozila);

                voz.Marka = MarkaVozila;
                voz.Tip = TipVozila;
                voz.GodinaProizvodnje = GodinaProizvodnje;

                FieldManager.UpdateChildren(this);

                ctx.DataContext.SaveChanges();
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new SingleCriteria<Vozilo, int>(IdVozila));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(SingleCriteria<Vozilo, int> criteria)
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {
                var voz = ctx.DataContext.VoziloSet.Find(criteria.Value);
                if (voz != null)
                {
                    try
                    {
                        ctx.DataContext.VoziloSet.Remove(voz);
                        ctx.DataContext.SaveChanges();
                    }
                    catch
                    {
                        new InvalidOperationException("Izbrišite sve podatke");
                    }
                }
            }
        }
        #endregion
    
}
}
