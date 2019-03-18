using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyIniReaderTest
{
    [TestClass]
    public class IniReaderFailTest
    {
        private readonly EasyIniReader.IniReader _Reader = new EasyIniReader.IniReader(string.Empty);

        [TestMethod]
        public void TestReadFalseWithException()
        {
            Assert.ThrowsException<MissingFieldException>((Action) TestException);


        }

        private void TestException()
        {
            string retVal = this._Reader.GetIniValueString("TEST", "STRING", "<empty>");

        }
        

    }
}