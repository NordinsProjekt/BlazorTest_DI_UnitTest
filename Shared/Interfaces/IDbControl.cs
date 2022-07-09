using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject.Interfaces
{
    public interface IDataSourceControl
    {
        public bool CreateDataSource();
        public bool DeleteDataSource();
        public bool SeedDataSource(string connectionString);
    }
}
