using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Rules.BuisnessModels;
using SharedProject.DTO;
namespace Rules
{
    public class B_Rules : IRules
    {
        public B_Rules()
        {

        }

        public double CalculateSalary(dto_salaryMonth sm)
        {
            return sm.RatePerHour * sm.NumberOfHoursWorked;
        }
        public double CalculateSalary(DTO_PaySalary ps)
        {
            return ps.RatePerHour * ps.TimeWorked;
        }

        public string GeneratePerson()
        {
            RandomPerson randomPerson = new RandomPerson();
            if (randomPerson.IsValid())
                return randomPerson.Firstname + " " + randomPerson.Lastname;
            else
                throw new MissingFieldException("Kunde inte generera ett namn");
        }

        public bool PaySalaryToEmployee(DTO_PaySalary ps)
        {
            if (IsValid(ps))
            {
                var salary = CalculateSalary(ps);
                Console.WriteLine("Employee name: " + ps.EmployeeName);
                Console.WriteLine("Paid: " + salary + "kr");
                //Process payment to bankaccount
                return true;
            }
            return false;
        }

        public bool IsValid(Object obj)
        {
            PropertyInfo[] props = obj.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(obj, null) == null)
                    return false;
                if (prop.PropertyType == typeof(Int32))
                    if ((int)prop.GetValue(obj, null) == 0)
                        return false;
                if (prop.PropertyType == typeof(Double))
                    if ((double)prop.GetValue(obj, null) == 0)
                        return false;
                if (prop.PropertyType == typeof(String))
                    if ((String)prop.GetValue(obj, null) == "")
                        return false;
            }
            return true;
        }
    }
}
