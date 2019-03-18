using System.Text;

namespace EasyIniReader
{
    /// <summary>
    /// IniReader for System-INI
    /// </summary>
    public class SystemIniReader
    {
        /// <summary>
        /// Write a section
        /// </summary>
        /// <param name="appName">application Name</param>
        /// <param name="sectionName">section</param>
        /// <returns>true or false</returns>
        public bool WriteIniSection(string appName, string sectionName)
        {
            return NativeMethods.WriteProfileSection(appName, sectionName);
        }

        /// <summary>
        /// Reads as Section
        /// </summary>
        /// <param name="appName"></param>
        /// <returns>true or false</returns>
        public string ReadIniSection(string appName)
        {
            StringBuilder retBuffer = new StringBuilder(255);
            var retVal = NativeMethods.GetProfileSection(appName, retBuffer, 255);
            return retBuffer.ToString();
        }

        /// <summary>
        /// Write ini-value as string
        /// </summary>
        /// <param name="appName">section</param>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <returns></returns>
        public bool WriteIniValue(string appName, string key, string value)
        {
            return NativeMethods.WriteProfileString(appName, key, value);
        }

        /// <summary>
        /// Write ini-value as int
        /// </summary>
        /// <param name="appName">section</param>
        /// <param name="key">key</param>
        /// <param name="value">value as int</param>
        /// <returns>true or false</returns>
        public bool WriteIniValue(string appName, string key, int value)
        {
            return WriteIniValue(appName, key, value.ToString());
        }

        /// <summary>
        /// Writes Ini-Value as bool 
        /// </summary>
        /// <remarks>
        /// true = 1
        /// false = 0
        /// </remarks>
        /// <param name="appName">section</param>
        /// <param name="key">key</param>
        /// <param name="value">value as bool </param>
        /// <returns>true or false</returns>
        public bool WriteIniValue(string appName, string key, bool value)
        {
            return WriteIniValue(appName, key, value ? "1" : "0");
        }

        /// <summary>
        /// Get Ini-Value as string
        /// </summary>
        /// <param name="appName">section</param>
        /// <param name="key">key</param>
        /// <returns>ini-value as string</returns>
        public string GetIniValue(string appName, string key)
        {
            StringBuilder sb = new StringBuilder(255);
            NativeMethods.GetProfileString(appName, key, "", sb, 255);
            return sb.ToString();
        }

        /// <summary>
        /// Get Ini-Value as int
        /// </summary>
        /// <param name="appName">section</param>
        /// <param name="key">key</param>
        /// <returns>true or false</returns>
        public int GetIniIntValue(string appName, string key)
        {
            return (int) NativeMethods.GetProfileInt(appName, key, 0);
        }
    }
}
