using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyIniReaderTest
{
    [TestClass]
    public class IniReaderTest
    {
        private static EasyIniReader.IniReader Reader;
        private static string Directory;
        private static bool WasCleand = false;
        public IniReaderTest()
        {
            WasCleand = false;
            Directory = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(Directory);
            //CleanUp();
            WasCleand = true;
            Init();
        }
       
        private void Init()
        {
          
            
            
            Reader = new EasyIniReader.IniReader(Path.Combine(Directory,"test.ini"));

        }

        
        private void CleanUp()
        {
            string oldPath = Path.Combine(Directory, "old_test.ini");
            string newPath = Path.Combine(Directory, "test.ini");
            if (File.Exists(oldPath))
                File.Delete(oldPath);
            if (File.Exists(newPath))
                File.Move(newPath, oldPath);


        }

        [TestMethod]
        public void TestWriteString()
        {
            bool retVal = Reader.WriteIniValue("TEST", "STRING", "string value");
            Assert.IsTrue(retVal, "Could not write String to INI");
            
        }

        [TestMethod]
        public void TestWriteInt()
        {
            bool retVal = Reader.WriteIniValue("TEST", "INT", 100);
            Assert.IsTrue(retVal, "Could not write String to INI");
        }

        [TestMethod]
        public void TestWriteBool()
        {
            bool retVal = Reader.WriteIniValue("TEST", "BOOL", true);
            Assert.IsTrue(retVal, "Could not write String to INI");
        }

        [TestMethod]
        public void TestReadString()
        {
            string retVal = Reader.GetIniValueString("TEST", "STRING", "<empty>");
            Assert.AreNotEqual<string>(retVal, "<empty>", "Value is:" + retVal);

        }

        [TestMethod]
        public void TestReadInt()
        {
            int retVal = Reader.GetIniValueInt("TEST", "INT", 0);
            Assert.AreNotEqual<int>(0, retVal);
        }

        [TestMethod]
        public void TestReadBool()
        {
            bool retVal = Reader.GetIniValueBool("TEST","BOOL",false);
            Assert.AreNotEqual<bool>(false, retVal);
        }
    }
}
