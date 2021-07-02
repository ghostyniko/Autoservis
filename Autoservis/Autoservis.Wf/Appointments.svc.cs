using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Autoservis.Wf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Appointments" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Appointments.svc or Appointments.svc.cs at the Solution Explorer and start debugging.
    public class Appointments : IAppointments
    {
        public TerminPregledaInfoList GetTermini(int id)
        {
            return TerminPregledaInfoList.Get(id);
        }
    }
}
