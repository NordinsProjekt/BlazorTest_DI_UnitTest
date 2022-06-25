using BlazorWebDI.Classes;
using BlazorWebDI.Interfaces;

namespace UnitTest
{
    [TestClass]
    public class PersonTest_DS_Array
    {
        IDataSource _data = new DS_Array();
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
            Assert.AreEqual(answer,"Success");
        }
    }
}