using System;
using System.Runtime.InteropServices;

namespace EasyIniReader
{
    internal static class NativeMethods
    {
        /// Return Type: BOOL->int
        ///lpAppName: LPCWSTR->WCHAR*
        ///lpString: LPCWSTR->WCHAR*
        [DllImport("kernel32.dll", EntryPoint = "WriteProfileSectionW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteProfileSection([In, MarshalAs(UnmanagedType.LPWStr)] string lpAppName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpString);


        /// Return Type: BOOL->int
        ///lpAppName: LPCWSTR->WCHAR*
        ///lpKeyName: LPCWSTR->WCHAR*
        ///lpString: LPCWSTR->WCHAR*
        [DllImport("kernel32.dll", EntryPoint = "WriteProfileStringW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteProfileString([In, MarshalAs(UnmanagedType.LPWStr)] string lpAppName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpKeyName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpString);


        /// Return Type: DWORD->unsigned int
        ///lpAppName: LPCWSTR->WCHAR*
        ///lpReturnedString: LPWSTR->WCHAR*
        ///nSize: DWORD->unsigned int
        [DllImport("kernel32.dll", EntryPoint = "GetProfileSectionW", SetLastError = true)]
        public static extern uint GetProfileSection([In] [MarshalAs(UnmanagedType.LPWStr)] string lpAppName,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            System.Text.StringBuilder lpReturnedString, uint nSize);


        /// Return Type: DWORD->unsigned int
        ///lpAppName: LPCWSTR->WCHAR*
        ///lpKeyName: LPCWSTR->WCHAR*
        ///lpDefault: LPCWSTR->WCHAR*
        ///lpReturnedString: LPWSTR->WCHAR*
        ///nSize: DWORD->unsigned int
        [DllImport("kernel32.dll", EntryPoint = "GetProfileStringW", SetLastError = true)]
        public static extern uint GetProfileString([In] [MarshalAs(UnmanagedType.LPWStr)] string lpAppName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpKeyName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpDefault, [Out] [MarshalAs(UnmanagedType.LPWStr)]
            System.Text.StringBuilder lpReturnedString, uint nSize);


        /// Return Type: UINT->unsigned int
        ///lpAppName: LPCWSTR->WCHAR*
        ///lpKeyName: LPCWSTR->WCHAR*
        ///nDefault: INT->int
        [DllImport("kernel32.dll", EntryPoint = "GetProfileIntW", SetLastError = true)]
        public static extern uint GetProfileInt([In] [MarshalAs(UnmanagedType.LPWStr)] string lpAppName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpKeyName, int nDefault);


        /// Return Type: BOOL->int
        ///lpAppName: LPCWSTR->WCHAR*
        ///lpKeyName: LPCWSTR->WCHAR*
        ///lpString: LPCWSTR->WCHAR*
        ///lpFileName: LPCWSTR->WCHAR*
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringW")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WritePrivateProfileString([In] [MarshalAs(UnmanagedType.LPWStr)] string lpAppName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpKeyName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpString,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

        /// Return Type: BOOL->int
        ///lpszSection: LPCWSTR->WCHAR*
        ///lpszKey: LPCWSTR->WCHAR*
        ///lpStruct: LPVOID->void*
        ///uSizeStruct: UINT->unsigned int
        ///szFile: LPCWSTR->WCHAR*
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStructW")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WritePrivateProfileStruct([In] [MarshalAs(UnmanagedType.LPWStr)] string lpszSection,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpszKey, [In] IntPtr lpStruct, uint uSizeStruct,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string szFile);


        /// Return Type: BOOL->int
        ///lpAppName: LPCWSTR->WCHAR*
        ///lpString: LPCWSTR->WCHAR*
        ///lpFileName: LPCWSTR->WCHAR*
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileSectionW")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WritePrivateProfileSection([In] [MarshalAs(UnmanagedType.LPWStr)] string lpAppName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpString,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpFileName);


        /// Return Type: DWORD->unsigned int
        ///lpszReturnBuffer: LPWSTR->WCHAR*
        ///nSize: DWORD->unsigned int
        ///lpFileName: LPCWSTR->WCHAR*
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileSectionNamesW")]
        public static extern uint GetPrivateProfileSectionNamesW([Out] [MarshalAs(UnmanagedType.LPWStr)]
            System.Text.StringBuilder lpszReturnBuffer, uint nSize,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpFileName);


        /// Return Type: DWORD->unsigned int
        ///lpAppName: LPCWSTR->WCHAR*
        ///lpReturnedString: LPWSTR->WCHAR*
        ///nSize: DWORD->unsigned int
        ///lpFileName: LPCWSTR->WCHAR*
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileSectionW")]
        public static extern uint GetPrivateProfileSectionW([In] [MarshalAs(UnmanagedType.LPWStr)] string lpAppName,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            System.Text.StringBuilder lpReturnedString, uint nSize,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpFileName);


        /// Return Type: BOOL->int
        ///lpszSection: LPCWSTR->WCHAR*
        ///lpszKey: LPCWSTR->WCHAR*
        ///lpStruct: LPVOID->void*
        ///uSizeStruct: UINT->unsigned int
        ///szFile: LPCWSTR->WCHAR*
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStructW")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPrivateProfileStructW([In] [MarshalAs(UnmanagedType.LPWStr)] string lpszSection,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpszKey, IntPtr lpStruct, uint uSizeStruct,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string szFile);


        /// Return Type: DWORD->unsigned int
        ///lpAppName: LPCWSTR->WCHAR*
        ///lpKeyName: LPCWSTR->WCHAR*
        ///lpDefault: LPCWSTR->WCHAR*
        ///lpReturnedString: LPWSTR->WCHAR*
        ///nSize: DWORD->unsigned int
        ///lpFileName: LPCWSTR->WCHAR*
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringW")]
        public static extern uint GetPrivateProfileStringW([In] [MarshalAs(UnmanagedType.LPWStr)] string lpAppName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpKeyName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpDefault, [Out] [MarshalAs(UnmanagedType.LPWStr)]
            System.Text.StringBuilder lpReturnedString, uint nSize,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpFileName);


        /// Return Type: UINT->unsigned int
        ///lpAppName: LPCWSTR->WCHAR*
        ///lpKeyName: LPCWSTR->WCHAR*
        ///nDefault: INT->int
        ///lpFileName: LPCWSTR->WCHAR*
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileIntW")]
        public static extern uint GetPrivateProfileIntW([In] [MarshalAs(UnmanagedType.LPWStr)] string lpAppName,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpKeyName, int nDefault,
            [In] [MarshalAs(UnmanagedType.LPWStr)] string lpFileName);


        const uint FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
        const uint FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
        const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
        const uint FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x00002000;
        const uint FORMAT_MESSAGE_FROM_HMODULE = 0x00000800;
        const uint FORMAT_MESSAGE_FROM_STRING = 0x00000400;


        /// Return Type: DWORD->unsigned int
        ///dwFlags: DWORD->unsigned int
        ///lpSource: LPCVOID->void*
        ///dwMessageId: DWORD->unsigned int
        ///dwLanguageId: DWORD->unsigned int
        ///lpBuffer: LPWSTR->WCHAR*
        ///nSize: DWORD->unsigned int
        ///Arguments: va_list*
        [DllImport("kernel32.dll", EntryPoint = "FormatMessageW")]
        public static extern uint FormatMessage(uint dwFlags, IntPtr lpSource,
            uint dwMessageId,
            uint dwLanguageId,
            [MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder lpBuffer,
            uint nSize, ref IntPtr arguments);
    }
}