using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rules;
using Rules.DTO;

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
        [TestMethod]
        public void TestIsValidWithPersonModel_ShouldReturnFalse()
        {
            dto_people p = new() { Age = 25, Firstname = "", Lastname = "Johansson",Id = 2 };
            Assert.IsFalse(_rules.IsValid(p));
        }
        [TestMethod]
        public void TestIsValidWithPersonModel_ShouldReturnTrue()
        {
            dto_people p = new() { Age = 25, Firstname = "d", Lastname = "Johansson", Id = 2 };
            Assert.IsTrue(_rules.IsValid(p));
        }

        [TestMethod]
        public void TestIsValidPersonRecord_ShouldReturnTrue()
        {
            DTO_PersonRecord pr = new DTO_PersonRecord("Markus", "Andersson");
            Assert.IsTrue(_rules.IsValid(pr));
        }

        [TestMethod]
        public void TestIsValidPersonRecord_ShouldReturnFalse()
        {
            DTO_PersonRecord pr = new DTO_PersonRecord("Markus", "");
            Assert.IsFalse(_rules.IsValid(pr));
        }
    }
}
