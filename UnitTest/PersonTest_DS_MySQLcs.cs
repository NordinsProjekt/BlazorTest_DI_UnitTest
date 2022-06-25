using BlazorWebDI.Classes;
using BlazorWebDI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class PersonTest_DS_MySQLcs
    {
        IDataSource _data = new DS_MySQL();
        [TestMethod]
        public void GetAllPersonNotNull()
        {
            var arrPeople = _data.GetAllPeople();
            Assert.IsNotNull(arrPeople);
        }
        [TestMethod]
        public void GetAllPerson_GetListObjectBack()
        {
            var arrPeople = _data.GetAllPeople();
            Assert.IsInstanceOfType(arrPeople, typeof(List<string>));
        }
        [TestMethod]
        public void CreateANewPerson_ReturnSuccess()
        {
            var answer = _data.NewPerson("Test Person");
            Assert.AreEqual(answer, "Success");
        }
    }
}
