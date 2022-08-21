using Rules.DTO;
using System.Collections.Generic;

namespace Rules.Interfaces
{
    public interface IDataSource
    {
        //Return test person
        public List<dto_people> GetAllPeople();
        public string GetPerson(int id);
        //Return fail or success
        public string NewPerson(string person);
        //Tanken är med denna är att det ska genereras en randomperson och metoden anropas från rules projektet.
        public string NewPerson();
        public string DeletePerson(int id);
        public string SetPerson(string person, int id);
    }
}
