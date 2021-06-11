using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservis.DAL
{
    public interface IContextProvider<C>
    {
        C DataContext { get; }
    }
}
