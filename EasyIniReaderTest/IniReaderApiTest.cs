using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasyIniReader;
namespace EasyIniReaderTest
{
    [TestClass]
    public class IniReaderApiTest
    {
        private static IniReaderApi _reader;
        private static string _directory;
        private static bool _wasCleaned = false;
        public IniReaderApiTest()
        {
            _wasCleaned = false;
            _directory = Directory.GetCurrentDirectory();
            Console.WriteLine(_directory);
            //CleanUp();
            _wasCleaned = true;
            Init();
        }
       
        private void Init()
        {
          
            
            
            _reader = new IniReaderApi(Path.Combine(_directory,"test.ini"));
         


        }

        
        private void CleanUp()
        {
            string oldPath = Path.Combine(_directory, "old_test.ini");
            string newPath = Path.Combine(_directory, "test.ini");
            if (File.Exists(oldPath))
                File.Delete(oldPath);
            if (File.Exists(newPath))
                File.Move(newPath, oldPath);


        }
        [Priority(6)]
        [TestMethod]
        public void TestWriteString()
        {
            bool retVal = _reader.WriteIniValue("TEST", "STRING", "string value");
            Assert.IsTrue(retVal, "Could not write String to INI");
            
        }
        [Priority(5)]
        [TestMethod]
        public void TestWriteInt()
        {
            bool retVal = _reader.WriteIniValue("TEST", "INT", 100);
            Assert.IsTrue(retVal, "Could not write String to INI");
        }
        [Priority(4)]
        [TestMethod]
        public void TestWriteBool()
        {
            bool retVal = _reader.WriteIniValue("TEST", "BOOL", true);
            Assert.IsTrue(retVal, "Could not write String to INI");
        }
        [Priority(3)]
        [TestMethod]
        public void TestReadString()
        {
            string retVal = _reader.GetIniValueString("TEST", "STRING", "<empty>");
            Assert.AreNotEqual<string>(retVal, "<empty>", "Value is:" + retVal);

        }
        [Priority(2)]
        [TestMethod]
        public void TestReadInt()
        {
            int retVal = _reader.GetIniValueInt("TEST", "INT", 0);
            Assert.AreNotEqual<int>(0, retVal);
        }
        [Priority(1)]
        [TestMethod]
        public void TestReadBool()
        {
            bool retVal = _reader.GetIniValueBool("TEST","BOOL",false);
            Assert.AreNotEqual<bool>(false, retVal);
        }

       
    }
}
