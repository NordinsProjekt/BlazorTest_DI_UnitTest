using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject.DTO
{
    public class DTO_PaySalary
    {
        public double RatePerHour { get; set; }
        public double TimeWorked { get; set; }
        public string BankAccountNumber { get; set; }
        public string EmployeeName { get; set; }
    }
}
