using System;
using SharedProject.Interfaces;
using MySql.Data.MySqlClient;
using SharedProject.DTO;
using Rules;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_MySQL
{
    public class MySQL : IDataSource
    {
        string connectionString = @"server=localhost;userid=root;password=;database=mypeople";
        IRules _rules = new B_Rules();

        public MySQL()
        {
            //TODO Kolla om databasen finns, annars skapa
            //SeedData(); Skapar databas tabellen och informationen.
        }
        public void SetConnectionString(string conn)
        {
            connectionString = conn;
        }
        private List<dto_people> TalkToMySQL(string sql, string[,] paramList)
        {
            using var con = new MySqlConnection(connectionString);
            con.Open();
            var cmd = new MySqlCommand(sql, con);
            if (paramList != null)
                for (int i = 0; i < paramList.GetLength(0); i++)
                    cmd.Parameters.AddWithValue(paramList[i, 0], paramList[i, 1]);
            MySqlDataReader myReader = cmd.ExecuteReader();
            List<dto_people> result = new List<dto_people>();
            while (myReader.Read())
                result.Add(new dto_people()
                {
                    Firstname = myReader.GetString("Firstname"),
                    Lastname = myReader.GetString("Lastname"),
                    Id = myReader.GetInt32("Id")
                });
            return result;
        }
        public string DeletePerson(int id)
        {
            dto_people p = new dto_people() { Id = id };
            if (PrepareDeletePersonFromDatabase(p))
                return "Success";
            return "Fail";
        }

        public List<dto_people> GetAllPeople()
        {
            string[,] parameters = new string[0, 0] { };
            List<dto_people> result = TalkToMySQL("SELECT * FROM person ORDER BY Firstname,Lastname;",parameters);
            return result;
        }

        public string GetPerson(int id)
        {
            string[,] parameters = new string[1, 2] { { "@id", id.ToString() } };
            IEnumerable<dto_people> result = TalkToMySQL("SELECT * FROM person WHERE Id = @id;", parameters);
            if (!result.Any())
                throw new IndexOutOfRangeException("Index verkar inte finnas");
            dto_people _p = result.First();
            return _p.GetFullname();
        }

        public string NewPerson(string person)
        {
            var splitPerson = person.Split(" ");
            if (splitPerson.Length == 2)
                PrepareNewPersonToDatabase(new dto_people() { Firstname = splitPerson[0],Lastname = splitPerson[1] });
            else
                return "Fail";
            return "Success";
        }

        public string NewPerson()
        {
            var splitPerson = _rules.GeneratePerson().Split(" ");
            if (splitPerson.Length == 2)
                PrepareNewPersonToDatabase(new dto_people() { Firstname = splitPerson[0], Lastname = splitPerson[1] });
            else
                return "Fail";
            return "Success";
        }

        public string SetPerson(string person, int id)
        {
            throw new NotImplementedException();
        }

        private bool PrepareNewPersonToDatabase(dto_people p)
        {
            string[,] parameters = new string[2, 2] { { "@Firstname", p.Firstname }, { "@Lastname", p.Lastname } };
            string sql = "INSERT INTO person (Firstname,Lastname) VALUES (@Firstname,@Lastname);";
            if (NonQueryToDatabase(sql, parameters))
                return true;
            return false;
        }

        private bool PrepareDeletePersonFromDatabase(dto_people p)
        {
            string[,] parameters = new string[1, 2] { { "@id", p.Id.ToString() } };
            string sql = "DELETE FROM person WHERE Id = @id;";
            if (NonQueryToDatabase(sql, parameters))
                return true;
            return false;
        }

        private bool NonQueryToDatabase(string sql, string[,] paramList)
        {
            using var con = new MySqlConnection(connectionString);
            con.Open();
            var cmd = new MySqlCommand(sql, con);
            if (paramList != null)
                for (int i = 0; i < paramList.GetLength(0); i++)
                    cmd.Parameters.AddWithValue(paramList[i, 0], paramList[i, 1]);
            cmd.ExecuteNonQuery();
            return true;
        }

        private void SeedData()
        {
            IDataSourceControl _dbC = new MySqlControl();
            _dbC.SeedDataSource(connectionString);
        }
    }
}
