using System;
using SharedProject.Interfaces;
using MySql.Data.MySqlClient;
using SharedProject.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_MySQL
{
    public class MySQL : IDataSource
    {
        string connectionString = @"server=localhost;userid=root;password=;database=mypeople";
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
                    Lastname = myReader.GetString("Lastname")
                });
            return result;
        }
        public string DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllPeople()
        {
            string[,] parameters = new string[0, 0] { };
            IEnumerable<dto_people> result = TalkToMySQL("SELECT * FROM person;",parameters);
            List<string> peopleList = new List<string>();
            foreach (var person in result)
                peopleList.Add(person.Firstname +" " + person.Lastname);
            return peopleList;
        }

        public string GetPerson(int id)
        {
            string[,] parameters = new string[1, 2] { { "@id", id.ToString() } };
            IEnumerable<dto_people> result = TalkToMySQL("SELECT * FROM person WHERE Id = @id;", parameters);
            if (!result.Any())
                throw new IndexOutOfRangeException("Index verkar inte finnas");
            dto_people _p = result.First();
            return _p.Firstname + " " + _p.Lastname;
            throw new NotImplementedException();
        }

        public string NewPerson(string person)
        {
            throw new NotImplementedException();
        }

        public string NewPerson()
        {
            throw new NotImplementedException();
        }

        public string SetPerson(string person, int id)
        {
            throw new NotImplementedException();
        }
    }
}
