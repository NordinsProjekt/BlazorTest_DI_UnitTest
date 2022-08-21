using Rules.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class DTO_PersonRecordTest
    {
        [TestMethod]
        public void TestToStringRecord()
        {
            DTO_PersonRecord _p = new DTO_PersonRecord("Markus", "Nordin");
            Console.WriteLine(_p);
            Assert.AreEqual("DTO_PersonRecord { Firstname = Markus, Lastname = Nordin }",_p.ToString());
        }

        [TestMethod]
        public void TestRecordFullDeclaration_GetFullname()
        {
            DTO_PersonRecordFull _p = new DTO_PersonRecordFull("Markus", "Nordin");
            Console.WriteLine(_p);
            Console.WriteLine(_p.GetFullname());
            Assert.AreEqual( "Markus Nordin",_p.GetFullname());
        }
    }
}
