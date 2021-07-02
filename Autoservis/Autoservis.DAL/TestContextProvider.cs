using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.EntityClient;
using Effort.DataLoaders;

namespace Autoservis.DAL
{
    public class TestContextProvider<C> : IContextProvider<C>
    {
        private static EntityConnection connection = null;

        private EntityConnection GetConnection()
        {
            if (connection == null)
            {
                IDataLoader loader = new EntityDataLoader("name=AutoservisDATAContainer");
                connection = Effort.EntityConnectionFactory.CreateTransient("name=AutoservisDATAContainer", loader);
            }
            return connection;
        }

        public C DataContext
        {
            get
            {
                connection = GetConnection();
                return (C)Activator.CreateInstance(typeof(C), connection);
            }
        }
    }
}
