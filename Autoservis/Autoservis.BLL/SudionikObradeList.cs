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
    public class SudionikObradeList: BusinessListBase<SudionikObradeList, SudionikObrade>
    {

            #region Constructors
            private SudionikObradeList()
            {
            }
            #endregion

            #region  Business Methods
            public SudionikObrade GetSudionikObrade(int idZaposlenika)
            {
                if (ContainsOsoba(idZaposlenika))
                {
                    return this.Where(x => x.IdZaposlenika == idZaposlenika).Select(x => x).Single();
                }
                else
                {
                    return null;
                }
            }

            public void DodijeliZaposlenika(int idZaposlenika)
            {
                if (!ContainsOsoba(idZaposlenika))
                {
                    SudionikObrade osoba = SudionikObrade.New(idZaposlenika);
                    this.Add(osoba);
                }
                else
                {
                    throw new InvalidOperationException(Resource.ZaposlenikVecRadiNaAutomobilu);
                }
            }

            public void UkloniZaposlenika(int idZaposlenika)
            {
                //if (ContainsOsoba(idZaposlenika))
              //  {
                    Remove(this.Where(x => x.IdZaposlenika == idZaposlenika).Select(x => x).Single());
               // }
            }

            public bool ContainsOsoba(int idZaposlenika)
            {
                return this.Where(x => x.IdZaposlenika == idZaposlenika).Count() > 0;
            }

            internal bool ContainsDeleted(int idZaposlenika)
            {
                return DeletedList.Where(x => x.IdZaposlenika == idZaposlenika).Count() > 0;
            }
            #endregion

            #region  Factory Methods
            // stvaranje nove liste
            internal static SudionikObradeList New()
            {
                return DataPortal.CreateChild<SudionikObradeList>();
            }

            // punjenje postojećim
            internal static SudionikObradeList Load(DAL.ZaposlenikObrada[] data)
            {
                return DataPortal.FetchChild<SudionikObradeList>(data);
            }
            #endregion

            #region  Data Access
            // dohvati detail iz Projekt.UlogaOsobe (vidi EF model)
            private void Child_Fetch(DAL.ZaposlenikObrada[] data)
            {
                this.RaiseListChangedEvents = false;
                foreach (var value in data)
                    this.Add(SudionikObrade.Load(value));
                this.RaiseListChangedEvents = true;
            }
            #endregion
        }
    
}
