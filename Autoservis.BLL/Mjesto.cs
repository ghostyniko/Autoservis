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
    [Serializable()]
    public class Mjesto : BusinessBase<Mjesto>
    {
        #region Constructors
        private Mjesto()
        {
        }
        #endregion

        #region  Properties
        private static PropertyInfo<int> IdMjestaProperty =
          RegisterProperty(new PropertyInfo<int>(Reflector.GetPropertyName<Mjesto>(x => x.IdMjesta)));
        public int IdMjesta
        {
            get { return GetProperty(IdMjestaProperty); }
        }

        private static PropertyInfo<string> NazivMjestaProperty =
        RegisterProperty(typeof(Mjesto), new PropertyInfo<string>(Reflector.GetPropertyName<Mjesto>(x => x.NazivMjesta)));
        public string NazivMjesta
        {
            get { return GetProperty(NazivMjestaProperty); }
            set { SetProperty(NazivMjestaProperty, value); }
        }

        private static PropertyInfo<int> PostanskiBrojProperty =
        RegisterProperty(typeof(Mjesto), new PropertyInfo<int>(Reflector.GetPropertyName<Mjesto>(x => x.PostanskiBroj)));
        public int PostanskiBroj
        {
            get { return GetProperty(PostanskiBrojProperty); }
            set { SetProperty(PostanskiBrojProperty, value); }
        }
        #endregion

        #region  Validation Rules
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.StringRequired, NazivMjestaProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(NazivMjestaProperty, 25));

            ValidationRules.AddRule(CommonRules.IntegerMinValue, new CommonRules.IntegerMinValueRuleArgs(PostanskiBrojProperty, 0));
            ValidationRules.AddRule(CommonRules.IntegerMaxValue, new CommonRules.IntegerMaxValueRuleArgs(PostanskiBrojProperty, 100000));
        }

        #endregion
        #region Factory Methods

        public static Mjesto New()
        {
            return DataPortal.Create<Mjesto>();
        }

        public static Mjesto Get(int idMjesta)
        {
            return DataPortal.Fetch<Mjesto>(new SingleCriteria<Mjesto, int>(idMjesta));
        }

        public static void Delete(int idMjesta)
        {
            DataPortal.Delete<Mjesto>(new SingleCriteria<Mjesto, int>(idMjesta));
        }

        #endregion
        #region Data Access
        private void DataPortal_Fetch(SingleCriteria<Mjesto, int> criteria)
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(Database.ProjektConnectionString))
            {
                // var data = (from o in ctx.DataContext.Osoba where o.IdOsobe == criteria.Value select o).Single();
                var data = ctx.DataContext.MjestoSet.Find(criteria.Value);
                LoadProperty(IdMjestaProperty, data.IdMjesto);
                LoadProperty(NazivMjestaProperty, data.Naziv);
                LoadProperty(PostanskiBrojProperty, data.PostanskiBroj);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {
                DAL.Mjesto mj = new DAL.Mjesto
                {
                    Naziv = NazivMjesta,
                    PostanskiBroj = PostanskiBroj
                };

                ctx.DataContext.MjestoSet.Add(mj);
                ctx.DataContext.SaveChanges();

                //  ctx.DataContext.Entry<DAL.Mjesto>(mj).Reload();

                LoadProperty(IdMjestaProperty, mj.IdMjesto);

                FieldManager.UpdateChildren(this);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))

            {
                DAL.Mjesto mj = ctx.DataContext.MjestoSet.Find(this.IdMjesta);

                mj.Naziv = NazivMjesta;
                mj.PostanskiBroj = PostanskiBroj;

                FieldManager.UpdateChildren(this);

                ctx.DataContext.SaveChanges();
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new SingleCriteria<Mjesto, int>(IdMjesta));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        private void DataPortal_Delete(SingleCriteria<Mjesto, int> criteria)
        {
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {
                
                var mjesto = ctx.DataContext.MjestoSet.Find(criteria.Value);
                ctx.DataContext.MjestoSet.Remove(mjesto);
            }
        }
    
        
        #endregion

    }
}
