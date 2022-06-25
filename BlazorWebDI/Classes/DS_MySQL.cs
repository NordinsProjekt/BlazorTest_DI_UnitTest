using BlazorWebDI.Interfaces;

namespace BlazorWebDI.Classes
{
    public class DS_MySQL : IDataSource
    {
        public DS_MySQL()
        {

        }
        public string DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllPeople()
        {
            return new List<string>() { "hej3" };
        }

        public string GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public string NewPerson(string person)
        {
            if (person == null || Equals(""))
                return "Fail";
            return "Success";
        }

        public string SetPerson(string person, int id)
        {
            throw new NotImplementedException();
        }
    }
}
