using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rules;
using SharedProject.Interfaces;
using SharedProject.DTO;

namespace DS_MySQL_EF
{
    public class MySQL_EF : IDataSource
    {
        IRules _rules = new B_Rules();
        private string connectionString = "";
        
        public string DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public List<dto_people> GetAllPeople()
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
