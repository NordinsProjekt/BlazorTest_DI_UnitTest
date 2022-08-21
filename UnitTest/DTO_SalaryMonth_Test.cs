using Rules.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class DTO_SalaryMonth_Test
    {
        [TestMethod]
        public void Test_DTO_SalaryMonth_ShouldNotBeTrue()
        {
            dto_salaryMonth sm = new dto_salaryMonth() { RatePerHour = 130.30, NumberOfHoursWorked = 2 };
            Assert.IsFalse(sm.IsValid());
        }

        [TestMethod]
        public void Test_DTO_SalaryMonth_OnlyDoubleIsNotSet_ShouldNotBeTrue()
        {
            dto_salaryMonth sm = new dto_salaryMonth() { NumberOfHoursWorked = 2, 
                Firstname = "Markus", Lastname = "Nordin", EmployeeNumber = 2 };
            Assert.IsFalse(sm.IsValid());
        }

        [TestMethod]
        public void Test_DTO_SalaryMonth_ShouldBeTrue()
        {
            dto_salaryMonth sm = new dto_salaryMonth() { RatePerHour = 130.30,
            NumberOfHoursWorked = 2, Firstname = "Markus", Lastname = "Nordin", EmployeeNumber = 2};
            Assert.IsTrue(sm.IsValid());
        }
    }
}
