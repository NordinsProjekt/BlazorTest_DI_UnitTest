using BlazorWebDI.Interfaces;

namespace BlazorWebDI.Classes
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
            throw new NotImplementedException();
        }

        public List<string> GetAllPeople()
        {
            return personArray;
        }

        public string GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public string NewPerson(string person)
        {
            personArray.Add(person);
            return "Success";
        }

        public string SetPerson(string person, int id)
        {
            throw new NotImplementedException();
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
