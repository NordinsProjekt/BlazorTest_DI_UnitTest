using Rules;
using SharedProject.Interfaces;
using SharedProject.DTO;
using System.Collections.Generic;

namespace DataSources
{
    public class DS_Array : IDataSource
    {
        private List<dto_people> personArray = new List<dto_people>();
        IRules _rules = new B_Rules();

        public DS_Array()
        {
            SeedList();
        }

        public string DeletePerson(int id)
        {
            if (id >= personArray.Count || id<0)
                return "Fail";
            personArray.RemoveAt(id);
            return "Success";
        }

        public List<dto_people> GetAllPeople()
        {
            return personArray;
        }

        public string GetPerson(int id)
        {
            if (id >= personArray.Count || id < 0)
                throw new IndexOutOfRangeException();
            return personArray.ElementAt(id).Firstname + " " + personArray.ElementAt(id).Lastname;
        }

        public string NewPerson(string person)
        {
            if (person == null || person.Equals(""))
                return "Fail";
            dto_people p = StringToDTO_Person(person);
            personArray.Append(p);
            return "Success";
        }

        public string NewPerson()
        {
            dto_people p = StringToDTO_Person(_rules.GeneratePerson());
            personArray.Add(p);
            return "Success";
        }

        public string SetPerson(string person, int id)
        {
            if (person == null || person == "")
                return "Fail";
            if (id >= personArray.Count() || id < 0)
                return "Fail";
            dto_people p = StringToDTO_Person(person);
            personArray.RemoveAt(id);
            personArray.Insert(id,p);
            return "Success";
        }

        private void SeedList()
        {
            personArray.Add(StringToDTO_Person("Markus Nordin"));
            personArray.Add(StringToDTO_Person("Test Testsson"));
            personArray.Add(StringToDTO_Person("Johan Johansson"));
            personArray.Add(StringToDTO_Person("Karl Karlsson"));
            personArray.Add(StringToDTO_Person("Sven Svensson"));
        }

        private dto_people StringToDTO_Person(string person)
        {
            var p = person.Split(" ");
            dto_people people = new dto_people();
            if (p.Length >= 2)
            {
                people.Firstname = p[0];
                people.Lastname = p[1];
            }
            else
                throw new ArgumentException("Ett förnamn och ett efternam tack");
            return people;
        }

    }
}
