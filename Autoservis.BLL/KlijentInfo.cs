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
    public class KlijentInfo:ReadOnlyBase<KlijentInfo>
    {
        #region Constructors
        internal KlijentInfo(int id, string prezime, string ime)
        {
            IdKlijenta = id;
            NazOsobe = string.Format("{0}, {1}", prezime, ime);
            Prezime = prezime;
            Ime = ime;
        }
        #endregion
        #region Properties
        public int IdKlijenta { get; private set; }
        public string NazOsobe { get; private set; }
        public string Prezime { get; private set; }
        public string Ime { get; private set; }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return NazOsobe;
        }
        #endregion

    }
}
