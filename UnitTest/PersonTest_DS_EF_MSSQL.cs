using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS_MySQL_EF;
using SharedProject.Interfaces;
using SharedProject.DTO;

namespace UnitTest
{
    [TestClass]
    public class PersonTest_DS_EF_MSSQL
    {
        private IDataSource _data = new MSSQL_EF();
        [TestMethod]
        public void GetPersonTest_ShouldReturnTestTestsson ()
        {
            string name = _data.GetPerson(1);
            Assert.AreEqual(name, "Test Testsson");
        }
        [TestMethod]
        [ExpectedException (typeof (IndexOutOfRangeException))]
        public void GetPersonTest_ShouldGetExceptionIndexOutOfBounds()
        {
            string name = _data.GetPerson(8576);
        }
        //TODO Test mot riktig databas kräver att metoden vet det ID´t som lades till i NewPerson
        //
        [TestMethod]
        public void AddPersonAndThenDeletePerson_ShouldReturnSuccessForBoth()
        {
            string answer = _data.NewPerson("Markus Nordin");
            var peopleList = _data.GetAllPeople();
            string answer2 = _data.DeletePerson(peopleList.FirstOrDefault(x => x.Firstname == "Markus").Id);
            Assert.AreEqual(answer, "Success");
            Assert.AreEqual(answer2, "Success");
        }
        [TestMethod]
        public void GetPeopleList_ShouldReceiveAListOfPeople()
        {
            var peopleList = _data.GetAllPeople();
            Assert.IsInstanceOfType(peopleList, typeof(List<dto_people>));
        }
    }
}
