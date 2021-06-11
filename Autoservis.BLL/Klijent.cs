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
    public class Klijent:BusinessBase<Klijent>
    {
       #region Constructors
        private Klijent()
        {
        }

        #endregion

       #region  Properties
        private static PropertyInfo<int> IdKlijentaProperty =
          RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<Klijent>(x => x.IdKlijenta)));
        public int IdKlijenta
        {
            get { return GetProperty(IdKlijentaProperty); }
        }

        private static PropertyInfo<string> PrezimeKlijentaProperty =
        RegisterProperty(typeof(Klijent), new PropertyInfo<string>(Reflector.GetPropertyName<Klijent>(x => x.PrezimeKlijenta)));
        public string PrezimeKlijenta
        {
            get { return GetProperty(PrezimeKlijentaProperty); }
            set { SetProperty(PrezimeKlijentaProperty, value); }
        }

        private static PropertyInfo<string> ImeKlijentaProperty =
        RegisterProperty(typeof(Klijent), new PropertyInfo<string>(Reflector.GetPropertyName<Klijent>(x => x.ImeKlijenta)));
        public string ImeKlijenta
        {
            get { return GetProperty(ImeKlijentaProperty); }
            set { SetProperty(ImeKlijentaProperty, value); }
        }

        private static PropertyInfo<string> LozinkaKlijentaProperty =
        RegisterProperty(typeof(Klijent), new PropertyInfo<string>(Reflector.GetPropertyName<Klijent>(x => x.LozinkaKlijenta)));
        public string LozinkaKlijenta
        {
            get { return GetProperty(LozinkaKlijentaProperty); }
            set { SetProperty(LozinkaKlijentaProperty, value); }
        }

      

        private static PropertyInfo<string> UlicaKlijentaProperty =
        RegisterProperty(typeof(Klijent), new PropertyInfo<string>(Reflector.GetPropertyName<Klijent>(x => x.UlicaKlijenta)));
        public string UlicaKlijenta
        {
            get { return GetProperty(UlicaKlijentaProperty); }
            set { SetProperty(UlicaKlijentaProperty, value); }
        }

        private static PropertyInfo<string> KucniBrojKlijentaProperty =
        RegisterProperty(typeof(Klijent), new PropertyInfo<string>(Reflector.GetPropertyName<Klijent>(x => x.KucniBrojKlijenta)));
        public string KucniBrojKlijenta
        {
            get { return GetProperty(KucniBrojKlijentaProperty); }
            set { SetProperty(KucniBrojKlijentaProperty, value); }
        }

        private static PropertyInfo<Mjesto> MjestoKlijentaProperty =
        RegisterProperty(typeof(Klijent), new PropertyInfo<Mjesto>(Reflector.GetPropertyName<Klijent>(x => x.MjestoKlijenta)));
        public Mjesto MjestoKlijenta
        {
            get { return GetProperty(MjestoKlijentaProperty); }
            set { SetProperty(MjestoKlijentaProperty, value); }
        }

        private static PropertyInfo<int> IdMjestoProperty =
        RegisterProperty(typeof(Klijent), new PropertyInfo<int>(Reflector.GetPropertyName<Klijent>(x => x.MjestoKlijenta)));
        public int IdMjesto
        {
            get { return GetProperty(IdMjestoProperty); }
            set { SetProperty(IdMjestoProperty, value); }
        }

        private static PropertyInfo<KlijentVozilaInfoList> KlijentVozilaProperty =
     RegisterProperty(typeof(Klijent), new PropertyInfo<KlijentVozilaInfoList>(Reflector.GetPropertyName<Klijent>(x => x.KlijentVozila)));
        public KlijentVozilaInfoList KlijentVozila
        {
            get { return GetProperty(KlijentVozilaProperty); }
        }

        #endregion

        #region  Validation Rules
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.StringRequired, ImeKlijentaProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(ImeKlijentaProperty, 25));

            ValidationRules.AddRule(CommonRules.StringRequired, PrezimeKlijentaProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(PrezimeKlijentaProperty, 25));

            ValidationRules.AddRule(CommonRules.StringRequired, UlicaKlijentaProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(UlicaKlijentaProperty, 50));

            ValidationRules.AddRule(CommonRules.StringRequired, KucniBrojKlijentaProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(KucniBrojKlijentaProperty, 10));

         //   ValidationRules.AddRule(CommonRules.StringRequired, IdMjestoProperty);
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(KucniBrojKlijentaProperty, 10));


            /* ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(OIBProperty, 11));
             ValidationRules.AddRule<Osoba>(IsOIBValid, OIBProperty);
             ValidationRules.AddRule<Osoba>(IsOIBUnique, OIBProperty);*/
        }
        #endregion
        #region Factory Methods

        public static Klijent New()
        {
            return DataPortal.Create<Klijent>();
        }
        public static Klijent Get(int idKlijenta)
        {
            return DataPortal.Fetch<Klijent>(new SingleCriteria<Klijent, int>(idKlijenta));
        }
        public static void Delete(int idKlijenta)
        {
            DataPortal.Delete<Klijent>(new SingleCriteria<Klijent, int>(idKlijenta));
        }
        #endregion
        #region Data Access
        private void DataPortal_Fetch(SingleCriteria<Klijent, int> criteria)
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {
        
                // var data = (from o in ctx.DataContext.Osoba where o.IdOsobe == criteria.Value select o).Single();
                var data = ctx.DataContext.KlijentSet.Find(criteria.Value);
               
                LoadProperty(IdKlijentaProperty, data.IdKlijent);
                LoadProperty(ImeKlijentaProperty, data.Ime);
                LoadProperty(PrezimeKlijentaProperty, data.Prezime);
                LoadProperty(LozinkaKlijentaProperty, data.Lozinka);
                LoadProperty(UlicaKlijentaProperty, data.Adresa.Naziv);
                LoadProperty(KucniBrojKlijentaProperty, data.Adresa.KucniBroj);
                LoadProperty(MjestoKlijentaProperty,Mjesto.Get(data.Adresa.MjestoIdMjesto));
                LoadProperty(KlijentVozilaProperty, KlijentVozilaInfoList.Get(data.IdKlijent));
            }
        }
        
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {

                DAL.Klijent kl = new DAL.Klijent
                {
                    Ime = ImeKlijenta,
                    Prezime = PrezimeKlijenta,
                    Lozinka = LozinkaKlijenta,
                    Adresa = new DAL.Adresa
                    {
                        Naziv = UlicaKlijenta,
                        KucniBroj = KucniBrojKlijenta,
                        MjestoIdMjesto = IdMjesto
                    }
                   
                };

                ctx.DataContext.KlijentSet.Add(kl);
                ctx.DataContext.SaveChanges();

                LoadProperty(IdKlijentaProperty, kl.IdKlijent);

                FieldManager.UpdateChildren(this);
            }
        }
        
        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {
                DAL.Klijent kl = ctx.DataContext.KlijentSet.Find(this.IdKlijenta);
         
                kl.Ime = ImeKlijenta;
                kl.Prezime = PrezimeKlijenta;
                kl.Adresa.Naziv = UlicaKlijenta;
                kl.Adresa.KucniBroj = KucniBrojKlijenta;
                kl.Adresa.MjestoIdMjesto = IdMjesto;
                kl.Lozinka = LozinkaKlijenta;

                FieldManager.UpdateChildren(this);

                ctx.DataContext.SaveChanges();
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new SingleCriteria<Klijent, int>(IdKlijenta));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(SingleCriteria<Klijent, int> criteria)
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {
                var o = ctx.DataContext.KlijentSet.Find(criteria.Value);
                if (o != null)
                {
                    try
                    {
                        ctx.DataContext.AdresaSet.Remove(o.Adresa);
                        ctx.DataContext.KlijentSet.Remove(o);
                        ctx.DataContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Izbrišite sve podatke");
                    }
                }
            }
        }
        #endregion
    }
}
