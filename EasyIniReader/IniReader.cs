// ReSharper disable UnusedAutoPropertyAccessor.Local

using EasyIniReader.Entities;

namespace EasyIniReader
{
    /// <summary>
    /// Native IniReader
    /// </summary>
    public class IniReader
    {
        private string FileName { get; }
        private readonly IniFunctions _IniFunctions;

        /// <summary>
        /// AutoSave: Enable or disables saving when using the Write-Functions
        /// </summary>
        /// <remarks>
        /// To disable the AutoSave property can increase the performance.
        /// Set write all your values and then finally call Save.
        /// </remarks>
        public bool AutoSave
        {
            get => this._IniFunctions.AutoSave;
            set => this._IniFunctions.AutoSave = value;
        }


       

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">INI-File</param>
        public IniReader(string fileName)
        {
            this.FileName = fileName;
            this._IniFunctions = new IniFunctions(fileName);
        }

        /// <summary>
        /// Save data to INI-File
        /// </summary>
        /// <remarks>
        /// This is only necessary if you disable AutoSave
        /// </remarks>
        /// <returns></returns>
        public bool Save()
        {

            return this._IniFunctions.Save();
        }

        /// <summary>
        /// Get Ini-Value as string
        /// </summary>
        /// <param name="appName">section</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">default value optional ""</param>
        /// <returns>String</returns>
        public string GetIniValueString(string appName, string key, string defaultValue ="")
        {
            return this._IniFunctions.ReadString(appName, key);
        }

        /// <summary>
        /// Get Ini-Value as Int
        /// </summary>
        /// <param name="appName">section</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">default value optional default = 0</param>
        /// <returns>Integer </returns>
        public int GetIniValueInt(string appName, string key, int defaultValue = 0)
        {
            string retVal = this._IniFunctions.ReadString(appName, key, defaultValue.ToString());
            
            if (int.TryParse(retVal, out var intValue))
            {
                return intValue;
            }

            return defaultValue;
        }

        /// <summary>
        /// Get INI-Value as bool
        /// </summary>
        /// <param name="appName">section</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">default value optional false</param>
        /// <returns>true or false</returns>
        public bool GetIniValueBool(string appName, string key, bool defaultValue = false)
        {
            int intDefaultValue = defaultValue ? 1 : 0;
            int retVal = GetIniValueInt(appName, key, intDefaultValue);
            return retVal != 0;
        }

        /// <summary>
        /// Write String to INI-Value
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool WriteIniValue(string appName, string key, string value)
        {
            return this._IniFunctions.WriteString(appName, key, "", value);
        }

        /// <summary>
        /// Write int to INI-Value
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool WriteIniValue(string appName, string key, int value)
        {
            return this._IniFunctions.WriteString(appName, key, "0", value.ToString());
        }

        /// <summary>
        /// Write Bool to INI-Value
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool WriteIniValue(string appName, string key, bool value)
        {
            return WriteIniValue(appName, key, value ? 1 : 0);
        }
    }
}