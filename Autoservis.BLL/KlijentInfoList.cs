using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoservisBLL.DAL;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace AutoservisBLL
{
    public class KlijentInfoList: ReadOnlyListBase<KlijentInfoList, KlijentInfo>
    {
        #region Constructors
        private KlijentInfoList()
        {
        }
        #endregion

        #region  Factory Methods
        public static KlijentInfoList Get()
        {
            return DataPortal.Fetch<KlijentInfoList>();
        }
        #endregion

        #region  Data Access
        #region DataPortal Methods
        private void DataPortal_Fetch()
        {
            RaiseListChangedEvents = false;
            using (var ctx = DAL.ContextManager<AutoservisModel>.GetManager(Database.ProjektConnectionString))
            {
                
                List<KlijentInfo> data = new List<KlijentInfo>();
                foreach (var o in ctx.DataContext.Klijent.AsNoTracking().ToList())
                {
                    data.Add(new KlijentInfo(o.IdKlijent, o.Prezime, o.Ime));
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

