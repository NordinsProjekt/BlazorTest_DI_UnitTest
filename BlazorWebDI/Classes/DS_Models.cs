using BlazorWebDI.Interfaces;
using BlazorWebDI.Models;

namespace BlazorWebDI.Classes
{
    public class DS_Models : IDataSource
    {
        public List<People> PersonList = new List<People>();
        public DS_Models()
        {
            SeedData();
        }
        public string DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllPeople()
        {
            List<string> returnList = new List<string>();
            foreach (var person in PersonList)
            {
                returnList.Add(person.Firstname + " " + person.Lastname);
            }
            return returnList;
        }

        public string GetPerson(int id)
        {
            if (id < 0 || id >= PersonList.Count)
                throw new IndexOutOfRangeException();
            return PersonList[id].Firstname +" "+PersonList[id].Lastname;
        }

        public string NewPerson(string person)
        {
            var dto_p = person.Split(" ");
            if (dto_p.Length >= 2)
                PersonList.Add(new People() { Firstname = dto_p[0], Lastname = dto_p[1] });
            else
                return "Fail";
            return "Success";
        }

        public string SetPerson(string person, int id)
        {
            throw new NotImplementedException();
        }
        private void SeedData()
        {
            People tempPerson = new People() { Firstname = "Test", Lastname = "Johansson", Age = 28};
            PersonList.Add(tempPerson);
            tempPerson = new People() { Firstname = "Rune", Lastname = "Johansson", Age = 87};
            PersonList.Add(tempPerson);
            tempPerson = new People() { Firstname = "Julia", Lastname = "Karlsson", Age = 35};
            PersonList.Add(tempPerson);
        }

    }
}
