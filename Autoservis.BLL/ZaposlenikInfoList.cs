using System;
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
    public class ZaposlenikInfoList:ReadOnlyListBase<ZaposlenikInfoList, ZaposlenikInfo>
    {
        #region Constructors
        private ZaposlenikInfoList()
        {
        }
        #endregion

        #region  Factory Methods
        public static ZaposlenikInfoList Get()
        {
            return DataPortal.Fetch<ZaposlenikInfoList>();
        }
        #endregion

        #region  Data Access
        #region DataPortal Methods
        private void DataPortal_Fetch()
        {
            RaiseListChangedEvents = false;
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(Database.ProjektConnectionString))
            {

                List<ZaposlenikInfo> data = new List<ZaposlenikInfo>();
                foreach (var o in ctx.DataContext.ZaposlenikSet.AsNoTracking().ToList())
                {
                    data.Add(new ZaposlenikInfo(o.IdZaposlenik, o.Prezime, o.Ime));
                }

                IsReadOnly = false;
                this.AddRange(data);
                IsReadOnly = true;
            }
            RaiseListChangedEvents = true;
        }
        #endregion
        #endregion
    }
}
