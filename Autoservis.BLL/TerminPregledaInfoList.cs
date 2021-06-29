using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;
using Csla.Data;
using Csla.Validation;
using Autoservis.DAL;

namespace Autoservis.BLL
{
    [Serializable()]
    public class TerminPregledaInfoList :ReadOnlyListBase<TerminPregledaInfoList, TerminPregledaInfo>
    {
        #region Constructors
        private TerminPregledaInfoList()
        {
        }
        #endregion

        #region  Factory Methods
        public static TerminPregledaInfoList Get()
        {
            return DataPortal.Fetch<TerminPregledaInfoList>();
        }

        public static TerminPregledaInfoList Get(int idKlijenta)
        {
            return DataPortal.Fetch<TerminPregledaInfoList>(new SingleCriteria<KlijentVozilaInfoList, int>(idKlijenta));
        }
        #endregion

        #region  Data Access
        #region DataPortal Methods
        private void DataPortal_Fetch(SingleCriteria<KlijentVozilaInfoList, int> criteria)
        {
            RaiseListChangedEvents = false;
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(Database.ProjektConnectionString))
            {

                List<TerminPregledaInfo> data = new List<TerminPregledaInfo>();

                
                foreach (var o in ctx.DataContext.TerminPregledaSet.Where(el=> el.KlijentIdKlijent == criteria.Value).ToList())
                {
                    data.Add(new TerminPregledaInfo(o.Id,o.Vozilo.Marka + " "+o.Vozilo.Tip+ ","+o.Vozilo.GodinaProizvodnje,o.DatumIVrijeme.ToLongDateString(),(Status)o.Status,o.Klijent.Prezime+ ", "+o.Klijent.Ime,o.KlijentIdKlijent));
                }

                IsReadOnly = false;
                this.AddRange(data);
                IsReadOnly = true;
            }
            RaiseListChangedEvents = true;
        }

        private void DataPortal_Fetch()
        {
            RaiseListChangedEvents = false;
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(Database.ProjektConnectionString))
            {

                List<TerminPregledaInfo> data = new List<TerminPregledaInfo>();


                foreach (var o in ctx.DataContext.TerminPregledaSet.ToList())
                {
                    int status = o.Status;
                    Status stat = StatusHelper.Get(o.Status);
                    data.Add(new TerminPregledaInfo(o.Id, o.Vozilo.Marka + " " + o.Vozilo.Tip + "," + o.Vozilo.GodinaProizvodnje, o.DatumIVrijeme.ToLongDateString(), stat,o.Klijent.Prezime+ ", "+o.Klijent.Ime,o.KlijentIdKlijent));
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
