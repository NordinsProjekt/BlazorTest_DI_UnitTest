using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rules.DTO
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
        //Reflection kontrollerar alla properties i objektet.
        //Skickar false om något inte är satt
        public bool IsValid()
        {
            PropertyInfo[] props = this.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(this, null) == null)
                    return false;
                if (prop.PropertyType == typeof(Int32))
                    if ((int)prop.GetValue(this,null) == 0)
                        return false;
                if (prop.PropertyType == typeof(Double))
                    if ((double)prop.GetValue(this, null) == 0)
                        return false;
            }
            return true;
        }
    }
}
