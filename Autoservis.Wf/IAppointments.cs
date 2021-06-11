using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Autoservis;

namespace Autoservis.Wf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAppointments" in both code and config file together.
    [ServiceContract]
    public interface IAppointments
    {
        [OperationContract]
        TerminPregledaInfoList GetTermini(int id);
    }
}
