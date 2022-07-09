using System;
using System.Collections.Generic;
using System.Linq;
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

        public string GeneratePerson()
        {
            RandomPerson randomPerson = new RandomPerson();
            if (randomPerson.IsValid())
                return randomPerson.Firstname + " " + randomPerson.Lastname;
            else
                throw new MissingFieldException("Kunde inte generera ett namn");
        }
    }
}
