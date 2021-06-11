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
    public class ZaposlenikInfo:ReadOnlyBase<ZaposlenikInfo>
    {
        #region Constructors
        internal ZaposlenikInfo(int id, string prezime, string ime)
        {
            IdZaposlenika = id;
            NazOsobe = string.Format("{0}, {1}", prezime, ime);
        }
        #endregion
        #region Properties
        public int IdZaposlenika { get; private set; }
        public string NazOsobe { get; private set; }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return NazOsobe;
        }
        #endregion
    }
}
