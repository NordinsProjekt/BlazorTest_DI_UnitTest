using DataSources;
namespace UnitTest
{
    [TestClass]
    public class PersonTest_DS_Array
    {
        IDataSource _data = new DS_Array();
        [TestMethod]
        public void GetAllPersonsNotNull()
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
            Assert.AreEqual(answer,"Success");
        }
        [TestMethod]
        public void GetPersonWithID_NotNull()
        {
            var person = _data.GetPerson(1);
            Assert.IsNotNull(person);
        }
        [TestMethod]
        [ExpectedException (typeof(IndexOutOfRangeException))]
        public void GetPersonWithOutOfIndex_OverIndex_ReturnIndexOutOfBounds()
        {
            var person = _data.GetPerson(9999);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetPersonWithOutOfIndex_UnderIndex_ReturnIndexOutOfBounds()
        {
            var person = _data.GetPerson(-8);
        }
        [TestMethod]
        public void DeletePerson_ReturnSuccess()
        {
            var answer = _data.DeletePerson(1);
            Assert.AreEqual(answer, "Success");
        }
        [TestMethod]
        public void DeletePerson_ReturnFailBelowIndex()
        {
            var answer = _data.DeletePerson(-1);
            Assert.AreEqual(answer, "Fail");
        }
        [TestMethod]
        public void DeletePerson_ReturnFailOverIndex()
        {
            var answer = _data.DeletePerson(9999);
            Assert.AreEqual(answer, "Fail");
        }
        [TestMethod]
        public void EditPerson_ReturnSuccess()
        {
            var answer = _data.SetPerson("Hej2", 1);
            Assert.AreEqual(answer,"Success");
        }
        [TestMethod]
        public void EditPersonIDOverIndex_ReturnFail()
        {
            var answer = _data.SetPerson("Peter K", 9999);
            Assert.AreEqual(answer, "Fail");
        }
        [TestMethod]
        public void EditPersonPersonNullValue_ReturnFail()
        {
            var answer = _data.SetPerson(null, 2);
            Assert.AreEqual(answer, "Fail");
        }
        [TestMethod]
        public void EditPersonPersonEmptyString_ReturnFail()
        {
            var answer = _data.SetPerson("", 2);
            Assert.AreEqual(answer, "Fail");
        }
        [TestMethod]
        public void ConfirmThatPersonGotChanged()
        {
            var personBeforeChange = _data.GetPerson(1);
            _data.SetPerson("Testperson1", 1);
            var personAfterChange = _data.GetPerson(1);
            Assert.AreNotEqual(personBeforeChange, personAfterChange);
        }
        [TestMethod]
        public void ConfirmThatPersonDidntChanged()
        {
            var personBeforeChange = _data.GetPerson(1);
            _data.SetPerson(personBeforeChange, 1);
            var personAfterChange = _data.GetPerson(1);
            Assert.AreEqual(personBeforeChange, personAfterChange);
        }
    }
}