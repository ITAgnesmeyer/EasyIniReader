using System.Diagnostics;
using System.IO;
using EasyIniReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyIniReaderTest
{
    [TestClass]
    public class IniReaderDisabledAutoSave
    {
        private static IniReader _reader;
        private static string _directory;
        public IniReaderDisabledAutoSave()
        {
            _directory = Directory.GetCurrentDirectory();
            Debug.WriteLine(_directory);
            Init();
        }

        private void Init()
        {
            if (_reader == null)
            {
                _reader = new IniReader(Path.Combine(_directory, "test.ini")) {AutoSave = false};

            }
        }


        [Priority(7)]
        [TestMethod]
        public void TestNativeWriteString()
        {
            bool retVal = _reader.WriteIniValue("NATIVE_TEST", "STRING", "\"string value native\"");
            Assert.IsTrue(retVal, "Could not write String to INI");

        }
        [Priority(6)]
        [TestMethod]
        public void TestNativeWriteInt()
        {
            bool retVal = _reader.WriteIniValue("NATIVE_TEST", "INT", 120);
            Assert.IsTrue(retVal, "Could not write Int to INI");
        }
        [Priority(5)]
        [TestMethod]
        public void TestNativeWriteBool()
        {
            bool retVal = _reader.WriteIniValue("NATIVE_TEST", "BOOL", true);
            Assert.IsTrue(retVal, "Could not write BOOL to INI");
        }

        [Priority(4)]
        [TestMethod]
        public void TestNativeReadString()
        {
            string retVal = _reader.GetIniValueString("NATIVE_TEST", "STRING","<empty>");
            Assert.AreNotEqual<string>(retVal, "<empty>", "Value is:" + retVal);
        }

        [Priority(3)]
        [TestMethod]
        public void TestNativeReadInt()
        {
            int retVal = _reader.GetIniValueInt("NATIVE_TEST", "INT", 0);
            Assert.AreNotEqual<int>(retVal, 0, "Value is:" + retVal);
        }
        [Priority(2)]
        [TestMethod]
        public void TestNativeReadBool()
        {
            bool retVal = _reader.GetIniValueBool("NATIVE_TEST", "BOOL");
            Assert.AreNotEqual<bool>(retVal, false, "Value is:" + retVal);
        }
        
        [Priority(1)]
        [TestMethod]
        public void TestNativeSave()
        {
            bool retVal = _reader.Save();
            Assert.IsTrue(retVal, "Could not save Values to INI");
        }
    }
}