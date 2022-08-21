using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS_MySQL;
using Rules.Interfaces;

namespace UnitTest
{
    [TestClass]
    public class PersonTest_MySQL
    {
        IDataSource _data = new MySQL();
        [TestMethod]
        public void GetSpecificPerson()
        {
           string person = _data.GetPerson(2);
           Assert.IsNotNull(person);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetSpecifikPerson_OverIndex()
        {
            string person = _data.GetPerson(10);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetSpecifikPerson_UnderIndex()
        {
            string person = _data.GetPerson(-2);
        }
    }
}
