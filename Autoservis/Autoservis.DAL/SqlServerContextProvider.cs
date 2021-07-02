using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservis.DAL
{
    public class SqlServerContextProvider<C> : IContextProvider<C>
    {
        private string connectionString;

        public SqlServerContextProvider(string connectionString)
            {
            this.connectionString = connectionString;
            }

        public C DataContext
        {
            get
            {
                return (C)Activator.CreateInstance(typeof(C), connectionString);
            }
        }
    }
}
