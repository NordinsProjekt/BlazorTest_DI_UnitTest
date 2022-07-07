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
        public void Test_DTO_SalaryMonth_ShouldNotBeTrue()
        {
            dto_salaryMonth sm = new dto_salaryMonth();
            sm.RatePerHour = 130.30;
            sm.NumberOfHoursWorked = 2;
            Assert.IsFalse(sm.IsValid());
        }
        [TestMethod]
        public void Test_DTO_SalaryMonth_ShouldBeTrue()
        {
            dto_salaryMonth sm = new dto_salaryMonth();
            sm.RatePerHour = 130.30;
            sm.NumberOfHoursWorked = 2;
            sm.Firstname = "Markus";
            sm.Lastname = "Nordin";
            sm.EmployeeNumber = 2;
            Assert.IsTrue(sm.IsValid());
        }
    }
}
