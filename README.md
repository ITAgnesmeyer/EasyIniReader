# EasyIniReader
small lib for reading and writing INI-Files

```c#
IniReader reader = new IniReader("test.ini");
bool ok = reader.WriteIniValue("App","Name","Guido's APP");
if(!ok)
{
   Console.WriteLine("Could not wirte to Ini-File!");
}
```
