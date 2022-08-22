using Rules.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rules
{
    public interface IRules
    {
        public string GeneratePerson();
        public double CalculateSalary(dto_salaryMonth sm);
        public bool PaySalaryToEmployee(DTO_PaySalary ps);
        public bool IsValid(object obj);
    }
}
