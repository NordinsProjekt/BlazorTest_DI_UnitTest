﻿using Rules;
namespace DataSources
{
    public class DS_Models : IDataSource
    {
        public List<dto_people> PersonList = new List<dto_people>();

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
                PersonList.Add(new dto_people() { Firstname = dto_p[0], Lastname = dto_p[1] });
            else
                return "Fail";
            return "Success";
        }

        public string NewPerson()
        {
            B_Rules rules = new B_Rules();
            var dto_p = rules.GeneratePerson().Split(" ");
            if (dto_p.Length >= 2)
                PersonList.Add(new dto_people() { Firstname = dto_p[0], Lastname = dto_p[1] });
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
            dto_people tempPerson = new dto_people() { Firstname = "Test", Lastname = "Johansson", Age = 28};
            PersonList.Add(tempPerson);
            tempPerson = new dto_people() { Firstname = "Rune", Lastname = "Johansson", Age = 87};
            PersonList.Add(tempPerson);
            tempPerson = new dto_people() { Firstname = "Julia", Lastname = "Karlsson", Age = 35};
            PersonList.Add(tempPerson);
        }

    }
}
