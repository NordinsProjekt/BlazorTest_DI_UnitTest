using DataSources;
using SharedProject.Interfaces;
namespace FrontEnd_Console
{
    internal class Program
    {
        //Ger consollen en datakälla
        private static IDataSource _data = new DS_Models();
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
            Console.WriteLine("(3) Radera Person");
            Console.WriteLine("(4) Avsluta");
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
                    DeletePersonScreen();
                    break;
                case 4:
                    runIt = false;
                    break;
                default:
                    throw new ArgumentException("Borde vara en siffra mellan 1-4");
            }
        }
        static private void ShowAllPeopleScreen()
        {
            Console.Clear();
            Console.WriteLine("-----:: Visa alla personer ::-----");
            foreach (var person in _data.GetAllPeople())
                Console.WriteLine(person.ToString());
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

        static private void DeletePersonScreen()
        {
            Console.Clear();
            Console.WriteLine("-----:: Radera person ::-----");
            int x = 0;
            foreach (var person in _data.GetAllPeople())
                Console.WriteLine($"({x++}) {person.ToString()}");
            Console.Write("Skriv in ett index: ");
            string? index = Console.ReadLine();
            CheckUserInputDeletePerson(index);
        }
    }
}