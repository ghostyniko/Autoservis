using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autoservis.DAL;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace Autoservis
{
    [Serializable()]
    public class KlijentVozilaInfoList: ReadOnlyListBase<KlijentVozilaInfoList, KlijentVozilaInfo>
    {
        #region  Factory Methods
        public static KlijentVozilaInfoList Get(int idKlijenta)
        {
            return DataPortal.Fetch<KlijentVozilaInfoList>(new SingleCriteria<KlijentVozilaInfoList, int>(idKlijenta));
        }
        #endregion

        #region  Data Access
        #region DataPortal Methods
        private void DataPortal_Fetch(SingleCriteria<KlijentVozilaInfoList, int> criteria)
        {
            RaiseListChangedEvents = false;
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(Database.ProjektConnectionString))
            {
      
                List<KlijentVozilaInfo> data = new List<KlijentVozilaInfo>();
                DAL.Klijent klijent = ctx.DataContext.KlijentSet.Find(criteria.Value);

                foreach (var voz in klijent.Vozilo)
                {
                    data.Add(new KlijentVozilaInfo(voz.IdVozilo,voz.Marka,voz.Tip,voz.GodinaProizvodnje));
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
