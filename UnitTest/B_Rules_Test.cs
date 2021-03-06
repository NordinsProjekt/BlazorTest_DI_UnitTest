using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rules;
using SharedProject.DTO;

namespace UnitTest
{

    [TestClass]
    public class B_Rules_Test
    {
        private IRules _rules = new B_Rules();
        [TestMethod]
        public void TestCalculateSalaryMonth_ShouldBeEqual()
        {
            dto_salaryMonth sm = new dto_salaryMonth();
            sm.RatePerHour = 130.30;
            sm.NumberOfHoursWorked = 2;
            double salary = _rules.CalculateSalary(sm);
            Assert.AreEqual(salary, 260.60);
        }
        [TestMethod]
        public void TestPaymentFunction_ShouldReturnTrue()
        {
            DTO_PaySalary ps = new()
            {
                EmployeeName = "Markus Nordin",
                BankAccountNumber = "e309ur34r",
                RatePerHour = 270.54,
                TimeWorked = 145.45
            };
            Assert.IsTrue(_rules.PaySalaryToEmployee(ps));
        }
        [TestMethod]
        public void TestPaymentFunctionWithIncompleteDTO_ShouldReturnFalse()
        {
            DTO_PaySalary ps = new()
            {
                EmployeeName = "Markus Nordin",
                BankAccountNumber = "e309ur34r",
                RatePerHour = 270.54,
            };
            Assert.IsFalse(_rules.PaySalaryToEmployee(ps));
        }
    }
}
