using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules.Interfaces
{
    public interface IDataSourceControl
    {
        public bool CreateDataSource(string connectionString);
        public bool DeleteDataSource(string connectionString);
        public bool SeedDataSource(string connectionString);
    }
}
