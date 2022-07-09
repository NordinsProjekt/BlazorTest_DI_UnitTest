using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_MSSQL_EF.Models
{
    public class PersonalInformation
    {
        public int Id   { get; set; }
        [ForeignKey("Person")]
        public int PeopleId { get; set; }
        public string BankAccountNumber { get; set; }
        public string PhoneNumber { get; set; }
        public virtual People People { get; set; }
    }
}
