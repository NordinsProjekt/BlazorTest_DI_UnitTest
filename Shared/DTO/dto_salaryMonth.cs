using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject.DTO
{
    public class dto_salaryMonth
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public double RatePerHour { get; set; }
        public double NumberOfHoursWorked { get; set; }
        public int EmployeeNumber { get; set; }

         public dto_salaryMonth()
         {

         }
        public bool IsValid()
        {
            //Reflection kontrollerar alla properties i objektet.
            //Skickar false om något inte är satt
            PropertyInfo[] props = this.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
                if (prop.GetValue(this, null) == null || prop.GetValue(this, null).Equals(0))
                    return false;
            return true;
        }
    }
}
