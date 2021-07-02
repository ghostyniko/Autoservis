using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;
using Autoservis.Properties;

namespace Autoservis
{
    [Serializable()]
    public class ObradaSudioniciList: BusinessListBase<ObradaSudioniciList, ObradaSudionici>
    {

        #region Constructors
        private ObradaSudioniciList()
        {
        }
        #endregion

        #region  Business Methods
        public ObradaSudionici GetObradaSudionici(int idObrade)
        {
            if (ContainsObrada(idObrade))
            {
                return this.Where(x => x.IdObrade == idObrade).Select(x => x).Single();
            }
            else
            {
                return null;
            }
        }

        public void DodijeliObrade(int idObrade)
        {
            if (!ContainsObrada(idObrade))
            {
                ObradaSudionici osoba = ObradaSudionici.New(idObrade);
                this.Add(osoba);
            }
            else
            {
                throw new InvalidOperationException(Resource.ZaposlenikVecRadiNaAutomobilu);
            }
        }

        public void UkloniObrade(int idObrade)
        {
            if (ContainsObrada(idObrade))
            {
                Remove(this.Where(x => x.IdObrade == idObrade).Select(x => x).Single());
            }
        }

        public bool ContainsObrada(int idObrade)
        {
            return this.Where(x => x.IdObrade == idObrade).Count() > 0;
        }

        internal bool ContainsDeleted(int idObrade)
        {
            return DeletedList.Where(x => x.IdObrade == idObrade).Count() > 0;
        }
        #endregion

        #region  Factory Methods
        // stvaranje nove liste
        internal static ObradaSudioniciList New()
        {
            return DataPortal.CreateChild<ObradaSudioniciList>();
        }

        // punjenje postojećim
        internal static ObradaSudioniciList Load(DAL.ZaposlenikObrada[] data)
        {
            return DataPortal.FetchChild<ObradaSudioniciList>(data);
        }
        #endregion

        #region  Data Access
        // dohvati detail iz Projekt.UlogaOsobe (vidi EF model)
        private void Child_Fetch(DAL.ZaposlenikObrada[] data)
        {
            this.RaiseListChangedEvents = false;
            foreach (var value in data)
                this.Add(ObradaSudionici.Load(value));
            this.RaiseListChangedEvents = true;
        }
        #endregion
    }

}
