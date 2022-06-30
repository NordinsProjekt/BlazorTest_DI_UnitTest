namespace DataSources
{
    public class DS_Array : IDataSource
    {
        private List<string> personArray = new List<string>();

        public DS_Array()
        {
            SeedList();
        }

        public string DeletePerson(int id)
        {
            if (id >= personArray.Count || id<0)
                return "Fail";
            return "Success";
        }

        public List<string> GetAllPeople()
        {
            return personArray;
        }

        public string GetPerson(int id)
        {
            if (id >= personArray.Count || id < 0)
                throw new IndexOutOfRangeException();
            return personArray[id];
        }

        public string NewPerson(string person)
        {
            if (person == null || person.Equals(""))
                return "Fail";
            personArray.Add(person);
            return "Success";
        }

        public string NewPerson()
        {
            throw new NotImplementedException();
        }

        public string SetPerson(string person, int id)
        {
            if (person == null || person == "")
                return "Fail";
            if (id >= personArray.Count || id < 0)
                return "Fail";
            personArray[id] = person;
            return "Success";
        }

        private void SeedList()
        {
            personArray.Add("Markus Nordin");
            personArray.Add("Test Testsson");
            personArray.Add("Johan Johansson");
            personArray.Add("Karl Karlsson");
            personArray.Add("Sven Svensson");
        }

    }
}
