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
    public class MjestoList: NameValueListBase<int, string>
    {
        #region Constructors
        private MjestoList()
        {
        }
        #endregion

        #region  Business Methods
        public static int Default()
        {
            MjestoList list = Get();
            if (list.Count > 0)
            {
                return list.Items[0].Key;
            }
            else
            {
                throw new Exception("Bla");
            }
        }
        #endregion

        #region  Factory Methods
        private static MjestoList list;

        public static MjestoList Get()
        {
            if (list == null)
            {
                list = DataPortal.Fetch<MjestoList>();
            }
            return list;
        }

        public static NameValuePair Get (MjestoList list, int IdMjesto)
        {
            var res = list.Where(el => el.Key == IdMjesto).SingleOrDefault();
            return res;
        }
        public static void InvalidateCache()
        {
            list = null;
        }
        #endregion

        #region Data Access
        #region DataPortal Methods
        private void DataPortal_Fetch()        {
            this.RaiseListChangedEvents = false;
            
            using (var ctx = DAL.ContextManager<AutoservisDATAContainer>.GetManager(DAL.Database.ProjektConnectionString))
            {
                // uobičajeno bi bilo
                // var data = from u in ctx.DataContext.Uloga select new NameValuePair(u.IdUloge, u.NazUloge);
                // var data = ctx.DataContext.Uloga.Select(u => new NameValuePair(u.IdUloge, u.NazUloge));
                // var data = ctx.DataContext.Uloga.Select(u => new NameValuePair { Key = u.IdUloge, Value = u.NazUloge });

                // ali zbog {"Only parameterless constructors and initializers are supported in LINQ to Entities."}

                List<NameValuePair> data = new List<NameValuePair>();
          
                foreach (var u in ctx.DataContext.MjestoSet.AsNoTracking().ToList())
                {
                    data.Add(new NameValuePair(u.IdMjesto, u.Naziv + ", " +u.PostanskiBroj));
                }

                IsReadOnly = false;
                this.AddRange(data);
                IsReadOnly = true;
            }
            this.RaiseListChangedEvents = true;
        }
        #endregion
        #endregion
    }
}
