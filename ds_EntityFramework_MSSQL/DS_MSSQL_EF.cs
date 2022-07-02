using ds_EntityFramework_MSSQL.Models;
using ds_EntityFramework_MSSQL;
using SharedProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_EntityFramework_MSSQL
{
    public class DS_MSSQL_EF : IDataSource
    {
        private PeopleContext db = new PeopleContext();

        public string DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllPeople()
        {
            throw new NotImplementedException();
        }

        public string GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public string NewPerson(string person)
        {
            throw new NotImplementedException();
        }

        public string NewPerson()
        {
            throw new NotImplementedException();
        }

        public string SetPerson(string person, int id)
        {
            throw new NotImplementedException();
        }
    }
}
