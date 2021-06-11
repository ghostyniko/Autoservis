using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservis.DAL
{
    public class ContextConfigurer<C>
    {
        private static IContextProvider<C> contextProvider = new SqlServerContextProvider<C> ("AutoservisDATAContainer");


        public static IContextProvider<C>  GetContextProvider()
        {
            return contextProvider;
        }
        
        public static void ConfigureTest()
        {
            contextProvider = new TestContextProvider<C>();
        }
    }
}
