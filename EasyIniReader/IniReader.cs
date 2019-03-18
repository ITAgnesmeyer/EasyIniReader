using System;
using System.Text;

namespace EasyIniReader
{
    /// <summary>
    /// Reader fo private Ini Files
    /// </summary>
    public class IniReader
    {
        private readonly string _FileName;

        /// <summary>
        /// CTOR: You must give a File
        /// </summary>
        /// <param name="fileName">Ini-File name</param>
        public IniReader(string fileName)
        {
            this._FileName = fileName;
        }


        private void TestFile()
        {
            if (string.IsNullOrEmpty(this._FileName))
                throw new MissingFieldException("Missing File");
        }

        /// <summary>
        /// Get Ini-Value as string
        /// </summary>
        /// <param name="appName">Section</param>
        /// <param name="key">Key</param>
        /// <param name="defaultValue">default Value</param>
        /// <returns>Ini-Value as string</returns>
        public string GetIniValueString(string appName, string key, string defaultValue = "")
        {
            TestFile();
            StringBuilder sb = new StringBuilder(255);
            uint len = NativeMethods.GetPrivateProfileStringW(appName, key, defaultValue, sb, 255, this._FileName);
            return sb.ToString();
        }

        /// <summary>
        /// Get Ini-Value as int
        /// </summary>
        /// <param name="appName">section</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>Ini-Value as string</returns>
        public int GetIniValueInt(string appName, string key, int defaultValue = 0)
        {
            TestFile();
            return (int) NativeMethods.GetPrivateProfileIntW(appName, key, defaultValue, this._FileName);
        }

        /// <summary>
        /// Get Ini-Value as bool 
        /// </summary>
        /// <remarks>
        /// Bool - Values are 1 for true and 0 for false
        /// </remarks>
        /// <param name="appName">section Name</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">default Value</param>
        /// <returns>true or false</returns>
        public bool GetIniValueBool(string appName, string key, bool defaultValue = false)
        {
            int value = GetIniValueInt(appName, key, defaultValue ? 1 : 0);
            return value != 0;
        }

        /// <summary>
        /// Write Ini-Value as string 
        /// </summary>
        /// <param name="appName">section</param>
        /// <param name="key">key</param>
        /// <param name="value">Value as string</param>
        /// <returns>true or false</returns>
        public bool WriteIniValue(string appName, string key, string value)
        {
            TestFile();
            return NativeMethods.WritePrivateProfileString(appName, key, value, this._FileName);
        }

        /// <summary>
        /// Write IniValue as int
        /// </summary>
        /// <param name="appName">section</param>
        /// <param name="key">key</param>
        /// <param name="value">value as int</param>
        /// <returns>true or flase</returns>
        public bool WriteIniValue(string appName, string key, int value)
        {
            return WriteIniValue(appName, key, value.ToString());
        }

        /// <summary>
        /// Write ini-Value as bool
        /// </summary>
        /// <remarks>
        /// true => 1
        /// false => 0
        /// </remarks>
        /// <param name="appName">section</param>
        /// <param name="key">key</param>
        /// <param name="value">value as bool</param>
        /// <returns>true or false</returns>
        public bool WriteIniValue(string appName, string key, bool value)
        {
            int intValue = value ? 1 : 0;
            return WriteIniValue(appName, key, intValue);
        }
    }
}
