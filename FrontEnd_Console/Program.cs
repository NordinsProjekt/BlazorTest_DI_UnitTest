using DataSources;
using SharedProject.Interfaces;
using DS_MySQL;
using DS_MySQL_EF;
namespace FrontEnd_Console
{
    internal class Program
    {
        //Ger consollen en datakälla
        //private static IDataSource _data = new MySQL();
        private static IDataSource _data = new MSSQL_EF();
        //private static IDataSource _data = new DS_Array();

        private static bool runIt = true;
        static void Main(string[] args)
        {
            while (runIt)
            {
                ShowMeny();
            }
        }
        static private void ShowMeny()
        {
            Console.WriteLine("-----:: People List ::-----");
            Console.WriteLine("(1) Visa listan");
            Console.WriteLine("(2) Lägg till Person");
            Console.WriteLine("(3) Redigera Person");
            Console.WriteLine("(4) Radera Person");
            Console.WriteLine("(5) Avsluta");
            string? userChoice = Console.ReadLine();
            try
            {
                CheckUserInputMainMeny(userChoice);
            }
            catch (Exception e)
            {
                ShowError(e);
            }
            finally
            {
                Console.Clear();
            }
        }
        static private void ShowError(Exception error)
        {
            Console.Clear();
            Console.WriteLine("-----:: Felmeddelande ::-----");
            Console.WriteLine(error.Message);
            Console.WriteLine(error.StackTrace);
            Console.WriteLine("\n\nTryck på ENTER för att fortsätta");
            Console.ReadLine();
        }
        static private void CheckUserInputMainMeny(string? userChoice)
        {
            bool isItInt = int.TryParse(userChoice, out int val);
            if (isItInt)
                RouteUser(val);
            else
                throw new ArgumentException("Borde vara en siffra");
        }

        static private void CheckUserInputCreateNewPerson(string? personName)
        {
            if (personName == null || personName.Equals(""))
                _data.NewPerson();
            else
                _data.NewPerson(personName);
        }

        static private void CheckUserInputDeletePerson(string? index)
        {
            bool isItInt = int.TryParse(index, out int val);
            if (isItInt)
                _data.DeletePerson(val);
            else
                throw new ArgumentException("Borde vara en siffra");
        }
        static private void RouteUser(int userChoice)
        {
            switch(userChoice)
            {
                case 1:
                    ShowAllPeopleScreen();
                    break;
                case 2:
                    CreateNewPersonScreen();
                    break;
                case 3:
                    UpdatePersonScreen();
                    break;
                case 4:
                    DeletePersonScreen();
                    break;
                case 5:
                    runIt = false;
                    break;
                default:
                    throw new ArgumentException("Borde vara en siffra mellan 1-5");
            }
        }
        static private void ShowAllPeopleScreen()
        {
            Console.Clear();
            Console.WriteLine("-----:: Visa alla personer ::-----");
            foreach (var person in _data.GetAllPeople())
                Console.WriteLine(person.Firstname +" "+ person.Lastname);
            Console.WriteLine("\n\nTryck på ENTER för att fortsätta");
            Console.ReadLine();
        }

        static private void CreateNewPersonScreen()
        {
            Console.Clear();
            Console.WriteLine("-----:: Skapa ny person ::-----");
            Console.WriteLine("Skriv inget för att få ett slumpat namn");
            Console.Write("Skriv in ett namn: ");
            string? personName = Console.ReadLine();
            CheckUserInputCreateNewPerson(personName);
        }
        static private void UpdatePersonScreen()
        {
            Console.Clear();
            Console.WriteLine("-----:: Redigera person ::-----");
            throw new NotImplementedException();
            //Välj person att redigera
            //Skriv in nytt namn för personen
        }
        static private void DeletePersonScreen()
        {
            Console.Clear();
            Console.WriteLine("-----:: Radera person ::-----");
            int x = 0;
            var persons = _data.GetAllPeople();
            foreach (var person in persons)
                Console.WriteLine($"({x++}) {person.Firstname +" "+ person.Lastname}");
            Console.Write("Skriv in ett index: ");
            if (int.TryParse(Console.ReadLine(), out int index))
                _data.DeletePerson(persons.ElementAt(index).Id);
            else
                throw new ArgumentException("Endast siffror tack");
        }
    }
}