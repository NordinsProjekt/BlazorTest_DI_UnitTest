using DS_MSSQL_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DS_MSSQL_EF.Models
{
    public class People
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual PersonalInformation Information { get; set; }
    }
}
