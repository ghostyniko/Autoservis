using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace Autoservis.BLL
{
    [Serializable()]
    public class KlijentVozilaInfo:ReadOnlyBase<KlijentVozilaInfo>
    {
        #region Constructors
        internal KlijentVozilaInfo(int idVozila, string markaVozila, string tipVozila, short godinaProizvodnje)
        {
            IdVozila = idVozila;
            NazVozila = string.Format("{0} {1}, {2}", markaVozila, tipVozila,godinaProizvodnje);
            MarkaVozila = markaVozila;
            TipVozila = tipVozila;
            GodinaProizvodnje = godinaProizvodnje;
            
        }
        #endregion
        #region Properties
        public int IdVozila { get; private set; }
        public string NazVozila { get; private set; }
        public string MarkaVozila { get; private set; }
        public string TipVozila { get; private set; }
        public short GodinaProizvodnje { get; private set; }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return NazVozila;
        }
        #endregion
    }
}
