using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasyIniReader;
namespace EasyIniReaderTest
{
    [TestClass]
    public class IniReaderTest
    {
        private static IniReader _reader;
        private static string _directory;
        public IniReaderTest()
        {
            _directory = Directory.GetCurrentDirectory();
            Debug.WriteLine(_directory);
            Init();
        }

        private void Init()
        {
            _reader = new IniReader(Path.Combine(_directory, "test.ini"));
        }


        [Priority(6)]
        [TestMethod]
        public void TestNativeWriteString()
        {
            bool retVal = _reader.WriteIniValue("NATIVE_TEST", "STRING", "\"string value native\"");
            Assert.IsTrue(retVal, "Could not write String to INI");

        }
        [Priority(5)]
        [TestMethod]
        public void TestNativeWriteInt()
        {
            bool retVal = _reader.WriteIniValue("NATIVE_TEST", "INT", 120);
            Assert.IsTrue(retVal, "Could not write Int to INI");
        }
        [Priority(4)]
        [TestMethod]
        public void TestNativeWriteBool()
        {
            bool retVal = _reader.WriteIniValue("NATIVE_TEST", "BOOL", true);
            Assert.IsTrue(retVal, "Could not write BOOL to INI");
        }
        
        [Priority(3)]
        [TestMethod]
        public void TestNativeReadString()
        {
            string retVal = _reader.GetIniValueString("NATIVE_TEST", "STRING","<empty>");
            Assert.AreNotEqual<string>(retVal, "<empty>", "Value is:" + retVal);
        }

        [Priority(2)]
        [TestMethod]
        public void TestNativeReadInt()
        {
            int retVal = _reader.GetIniValueInt("NATIVE_TEST", "INT", 0);
            Assert.AreNotEqual<int>(retVal, 0, "Value is:" + retVal);
        }
        [Priority(1)]
        [TestMethod]
        public void TestNativeReadBool()
        {
            bool retVal = _reader.GetIniValueBool("NATIVE_TEST", "BOOL");
            Assert.AreNotEqual<bool>(retVal, false, "Value is:" + retVal);
        }

    }
}
