using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Autoservis.DAL;
using Autoservis.Properties;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace Autoservis.BLL
{
    [Serializable()]
    public class TerminPregleda : BusinessBase<TerminPregleda>
    {
        #region Constructors
        private TerminPregleda()
        {
        }
        #endregion

        #region  Properties
        private static PropertyInfo<int> IdTerminaProperty =
          RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<TerminPregleda>(x => x.IdTermina)));
        public int IdTermina
        {
            get { return GetProperty(IdTerminaProperty); }
        }

        private static PropertyInfo<DateTime> DatumIVrijemeTerminaProperty =
        RegisterProperty(typeof(TerminPregleda), new PropertyInfo<DateTime>(Reflector.GetPropertyName<TerminPregleda>(x => x.DatumIVrijemeTermina)));
        public DateTime DatumIVrijemeTermina
        {
            get { return GetProperty(DatumIVrijemeTerminaProperty); }
            set { SetProperty(DatumIVrijemeTerminaProperty, value); }
        }

        private static PropertyInfo<int> IdKlijentaProperty =
        RegisterProperty(typeof(TerminPregleda), new PropertyInfo<int>(Reflector.GetPropertyName<TerminPregleda>(x => x.IdKlijenta)));
        public int IdKlijenta
        {
            get { return GetProperty(IdKlijentaProperty); }
            set { SetProperty(IdKlijentaProperty, value); }
        }

        private static PropertyInfo<int> IdVozilaProperty =
        RegisterProperty(typeof(TerminPregleda), new PropertyInfo<int>(Reflector.GetPropertyName<TerminPregleda>(x => x.IdVozila)));
        public int IdVozila
        {
            get { return GetProperty(IdVozilaProperty); }
            set { SetProperty(IdVozilaProperty, value); }
        }

        private static PropertyInfo<Klijent> KlijentProperty =
       RegisterProperty(typeof(TerminPregleda), new PropertyInfo<Klijent>(Reflector.GetPropertyName<TerminPregleda>(x => x.Klijent)));
        public Klijent Klijent
        {
            get { return GetProperty(KlijentProperty); }
            set { SetProperty(KlijentProperty, value); }
        }

        private static PropertyInfo<Vozilo> VoziloProperty =
     RegisterProperty(typeof(TerminPregleda), new PropertyInfo<Vozilo>(Reflector.GetPropertyName<TerminPregleda>(x => x.Vozilo)));
        public Vozilo Vozilo
        {
            get { return GetProperty(VoziloProperty); }
            set { SetProperty(VoziloProperty, value); }
        }

        private static PropertyInfo<Status> StatusProperty =
       RegisterProperty(typeof(TerminPregleda), new PropertyInfo<Status>(Reflector.GetPropertyName<TerminPregleda>(x => x.Status)));
        public Status Status
        {
            get { return GetProperty(StatusProperty); }
            set { SetProperty(StatusProperty, value); }
        }

        #endregion

        #region Factory Methods

        public static TerminPregleda New()
        {
            return DataPortal.Create<TerminPregleda>();
        }

        public static TerminPregleda Get(int idTermina)
        {
            return DataPortal.Fetch<TerminPregleda>(new SingleCriteria<TerminPregleda, int>(idTermina));
        }

        public static void Delete(int idTermina)
        {
            DataPortal.Delete<TerminPregleda>(new SingleCriteria<TerminPregleda, int>(idTermina));
        }

        public static TerminPregleda Spremi(TerminPregleda t)
        {
            
            t = t.Save();
        
            return t.Save();
        }

        public static void Printaj(TerminPregleda t)
        {
            Console.WriteLine("fa");
        }
        public static bool Compare(TerminPregleda t1, TerminPregleda t2)
        {
            
            return t1.DatumIVrijemeTermina.Equals(t2.DatumIVrijemeTermina);
            
        }
        #endregion

        #region  Validation Rules
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule<TerminPregleda>(StartDateGTToday<TerminPregleda>, DatumIVrijemeTerminaProperty);
        }

        private static bool StartDateGTToday<T>(T target, RuleArgs e) where T : TerminPregleda
        {
            if ( target.ReadProperty(DatumIVrijemeTerminaProperty).Date <=DateTime.Now.Date)
            {
                e.Description = Resource.DatumTerminaError;
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region Data Access
        private void DataPortal_Fetch(SingleCriteria<TerminPregleda, int> criteria)
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(Database.ProjektConnectionString))
            {
                // var data = (from o in ctx.DataContext.Osoba where o.IdOsobe == criteria.Value select o).Single();
                var data = ctx.DataContext.TerminPregledaSet.Find(criteria.Value);
                LoadProperty(IdTerminaProperty, data.Id);
                LoadProperty(IdKlijentaProperty, data.KlijentIdKlijent);
                LoadProperty(IdVozilaProperty, data.VoziloIdVozilo);
                LoadProperty(KlijentProperty, Klijent.Get(IdKlijenta));
                LoadProperty(VoziloProperty, Vozilo.Get(IdVozila));
                LoadProperty(StatusProperty, data.Status);
                LoadProperty(DatumIVrijemeTerminaProperty, data.DatumIVrijeme);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {
                DAL.TerminPregleda termin = new DAL.TerminPregleda
                {
                    VoziloIdVozilo = IdVozila,
                    KlijentIdKlijent = IdKlijenta,
                    DatumIVrijeme = DatumIVrijemeTermina,
                    Status = (int)Status
                    
                };

                ctx.DataContext.TerminPregledaSet.Add(termin);
                ctx.DataContext.SaveChanges();

                //  ctx.DataContext.Entry<DAL.TerminPregleda>(mj).Reload();

                LoadProperty(IdTerminaProperty, termin.Id);

                FieldManager.UpdateChildren(this);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {
                DAL.TerminPregleda termin = ctx.DataContext.TerminPregledaSet.Find(this.IdTermina);

                termin.DatumIVrijeme = DatumIVrijemeTermina;
                termin.KlijentIdKlijent = IdKlijenta;
                termin.VoziloIdVozilo = IdVozila;
                termin.Status = (int)Status;

                FieldManager.UpdateChildren(this);

                ctx.DataContext.SaveChanges();
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new SingleCriteria<TerminPregleda, int>(IdTermina));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(SingleCriteria<TerminPregleda, int> criteria)
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {


                
                var TerminPregleda = ctx.DataContext.TerminPregledaSet.Find(criteria.Value);
                if (TerminPregleda != null)
                {
                    try
                    {
                        ctx.DataContext.TerminPregledaSet.Remove(TerminPregleda);
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
