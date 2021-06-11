using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace Autoservis
{
    [Serializable()]
    public class ObradaVozilaInfo:ReadOnlyBase<ObradaVozilaInfo>
    {
        #region Constructors
        internal ObradaVozilaInfo(int idObrade, string markaVozila, string tipVozila, DateTime datum)
        {
            IdObrade = idObrade;
            NazObrade = string.Format("{0} {1}, {2}", markaVozila, tipVozila, datum.Date);
        }
        #endregion
        #region Properties
        public int IdObrade { get; private set; }
        public string NazObrade { get; private set; }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return NazObrade;
        }
        #endregion
    }
}

