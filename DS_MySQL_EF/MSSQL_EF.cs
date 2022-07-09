using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rules;
using SharedProject.Interfaces;
using SharedProject.DTO;
using DS_MySQL_EF.Models;

namespace DS_MySQL_EF
{
    public class MSSQL_EF : IDataSource
    {
        IRules _rules = new B_Rules();
        PeopleContext _peopleContext = new PeopleContext();
        public MSSQL_EF()
        {
            if (_peopleContext.Database.EnsureCreated())
                SeedDatabase();
        }
        public string DeletePerson(int id)
        {
            People p = _peopleContext.Person.Where(x=>x.Id == id).FirstOrDefault();
            _peopleContext.Person.Remove(p);
            _peopleContext.SaveChanges();
            return "Success";
        }

        public List<dto_people> GetAllPeople()
        {
            var peopleList = _peopleContext.Person.ToList();
            List<dto_people> people = new List<dto_people>();
            foreach (var p in peopleList)
            {
                people.Add(new dto_people()
                {
                    Id = p.Id,
                    Firstname = p.Firstname,
                    Lastname = p.Lastname
                });
            }
            return people;
        }

        public string GetPerson(int id)
        {
            People p = _peopleContext.Person.FirstOrDefault(x => x.Id == id);
            if (p == null)
                throw new IndexOutOfRangeException("Index existerar inte");
            return p.Firstname + " " + p.Lastname;

        }

        public string NewPerson(string person)
        {
            People pers = AssemblePerson(person);
            _peopleContext.Person.Add(pers);
            _peopleContext.SaveChanges();
            return "Success";
        }

        public string NewPerson()
        {
            string personName =  _rules.GeneratePerson();
            People p = AssemblePerson(personName);
            _peopleContext.Person.Add(p);
            _peopleContext.SaveChanges();
            return "Success";
        }

        public string SetPerson(string person, int id)
        {
            throw new NotImplementedException();
        }

        public void SeedDatabase()
        {
            People p = new People() { Firstname = "Test", Lastname = "Testsson"};
            _peopleContext.Add(p);
            _peopleContext.SaveChanges();
        }

        private People AssemblePerson(string fullname)
        {
            var p = fullname.Split(" ");
            if (p.Length < 2)
                throw new ArgumentException("Ett förnamn och ett efternamn");
            People pers = new People { Firstname = p[0], Lastname = p[1] };
            return pers;
        }
    }
}
