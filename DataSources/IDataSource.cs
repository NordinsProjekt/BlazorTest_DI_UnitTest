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
        //Tanken är med denna är att det ska genereras en randomperson och metoden anropas från rules projektet.
        public string NewPerson();
        public string DeletePerson(int id);
        public string SetPerson(string person, int id);
    }
}
