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
    public class ObradaVozilaInfoList : ReadOnlyListBase<ObradaVozilaInfoList, ObradaVozilaInfo>
    {
        #region  Factory Methods
        public static ObradaVozilaInfoList Get(int idVozila)
        {
            return DataPortal.Fetch<ObradaVozilaInfoList>(new SingleCriteria<ObradaVozilaInfoList, int>(idVozila));
        }
        #endregion

        #region  Data Access
        #region DataPortal Methods
        private void DataPortal_Fetch(SingleCriteria<ObradaVozilaInfoList, int> criteria)
        {
            RaiseListChangedEvents = false;
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(Database.ProjektConnectionString))
            {

                List<ObradaVozilaInfo> data = new List<ObradaVozilaInfo>();
                DAL.Vozilo vozilo= ctx.DataContext.VoziloSet.Find(criteria.Value);

                foreach (var obr in vozilo.ObradaVozila)
                {
                    data.Add(new ObradaVozilaInfo(obr.IdObrada, vozilo.Marka, vozilo.Tip, obr.DatumIVrijemeZaprimanja));
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
