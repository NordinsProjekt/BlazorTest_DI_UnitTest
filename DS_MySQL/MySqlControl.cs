using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SharedProject.Interfaces;

namespace DS_MySQL
{
    internal class MySqlControl : IDataSourceControl
    {

        public bool CreateDataSource()
        {
            throw new NotImplementedException();
        }


        public bool DeleteDataSource()
        {
            throw new NotImplementedException();
        }

        public bool SeedDataSource(string connectionString)
        {
            string sql = @"CREATE TABLE `person` (
                          `Id` int(11) NOT NULL,
                          `Firstname` varchar(50) NOT NULL,
                          `Lastname` varchar(50) NOT NULL,
                          `Age` int(3) NOT NULL
                        ) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4; 
                        INSERT INTO `person` (`Id`, `Firstname`, `Lastname`, `Age`) VALUES
                        (2, 'Test', 'Testsson', 46),
                        (3, 'Markus', 'Johansson', 0),
                        (6, 'Peter', 'Nilsson', 0);

                        ALTER TABLE `person`
                          ADD PRIMARY KEY (`Id`);

                        ALTER TABLE `person`
                          MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
                        COMMIT;";
            return SendToDatabase(sql, connectionString);
        }

        private bool SendToDatabase(string sql,string connectionString)
        {
            using var con = new MySqlConnection(connectionString);
            con.Open();
            var cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
