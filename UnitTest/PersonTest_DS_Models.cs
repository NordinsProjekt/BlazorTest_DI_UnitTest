using DataSources;
using SharedProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Interface;

namespace UnitTest
{
    [TestClass]
    public class PersonTest_DS_Models : IPersonTest_DS
    {
        IDataSource _data = new DS_Models();
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
        [TestMethod]
        public void CreateANewPersonNoParameters_ReturnSuccess()
        {
            var answer = _data.NewPerson();
            Assert.AreEqual(answer, "Success");
        }
        [TestMethod]
        public void CreateANewPersonWithoutLastname_ReturnFail()
        {
            var answer = _data.NewPerson("Test");
            Assert.AreEqual(answer, "Fail");
        }
        [TestMethod]
        public void CreateANewPerson_VerifyThatPersonGotAdded()
        {
            string answer = _data.NewPerson("Test Person");
            string person = _data.GetPerson(3);
            Assert.AreEqual("Test Person", person);
        }

        public void ConfirmThatPersonDidntChanged()
        {
            throw new NotImplementedException();
        }

        public void ConfirmThatPersonGotChanged()
        {
            throw new NotImplementedException();
        }

        public void DeletePerson_ReturnFailBelowIndex()
        {
            throw new NotImplementedException();
        }

        public void DeletePerson_ReturnFailOverIndex()
        {
            throw new NotImplementedException();
        }

        public void DeletePerson_ReturnSuccess()
        {
            throw new NotImplementedException();
        }

        public void EditPersonIDOverIndex_ReturnFail()
        {
            throw new NotImplementedException();
        }

        public void EditPersonPersonEmptyString_ReturnFail()
        {
            throw new NotImplementedException();
        }

        public void EditPersonPersonNullValue_ReturnFail()
        {
            throw new NotImplementedException();
        }

        public void EditPerson_ReturnSuccess()
        {
            throw new NotImplementedException();
        }

        public void GetAllPersonsNotNull()
        {
            throw new NotImplementedException();
        }

        public void GetPersonWithID_NotNull()
        {
            throw new NotImplementedException();
        }
    }
}
