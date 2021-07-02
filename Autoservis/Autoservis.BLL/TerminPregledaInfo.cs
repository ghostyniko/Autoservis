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
    public class TerminPregledaInfo : ReadOnlyBase<TerminPregledaInfo>
    {
        #region Constructors
        internal TerminPregledaInfo(int id, string automobil, string termin, Status status, string klijent, int idKlijent)
        {
            IdTermina = id;
            IdKlijenta = idKlijent;
            NazKlijent = klijent;
            NazTermina = string.Format("{0}, {1}", automobil, termin);
            Status = status;
        }
        #endregion
        #region Properties
        public int IdTermina { get; private set; }
        public string NazTermina { get; private set; }

        public int IdKlijenta { get; private set; }
        public string NazKlijent { get; private set; }

        public Status Status { get; set; }
        #endregion
        #region Overrides
        public override string ToString()
        {
            return NazTermina;
        }
        #endregion
    }
}
