using System.Collections.Generic;

namespace DataSources
{
    public interface IDataSource
    {
        //Return test person
        public List<string> GetAllPeople();
        public string GetPerson(int id);
        //Return fail or success
        public string NewPerson(string person);
        public string DeletePerson(int id);
        public string SetPerson(string person, int id);
    }
}
