using System.Collections.Generic;
using System.IO;

namespace EasyIniReader.Entities
{
    internal class IniFunctions
    {
        public string FileName { get; }
        //private const char Nl = '\0';
        //private const char Apostrophe = '"';
        private const char Equal = '=';
        private const string BracketOpen = "[";
        private const string BracketClose = "]";
        private static readonly string[] Comment = {"#",";"};
        private List<string> _IniLines;
        private readonly IniFile _IniFile;
        public bool AutoSave{get;set;} = true;
        public IniFunctions(string fileName)
        {
            this._IniFile = new IniFile();
            this.FileName = fileName;
            Read();
        }

        private static bool IsComment(string line)
        {
            string trimmedLine = line.Trim();
            bool isComment = false;
            foreach (string c in Comment)
            {
                isComment = trimmedLine.StartsWith(c);
                if (isComment) break;
            }

            return isComment;

        }

        private static bool IsSection(string line)
        {
            string trimmedLine = line.Trim();
            bool isSection = trimmedLine.StartsWith(BracketOpen);
            return isSection;
        }

        private void Read()
        {
            FillLinesFromFile();
            Section lastSection = null;
            int lineNr = 1;
            foreach (string line in this._IniLines)
            {
                
                if (IsSection(line))
                {

                    var section = new Section {Name = line.Trim().Replace(BracketOpen, "").Replace(BracketClose, "")};

                    this._IniFile.Sections.Add(section);
                    lastSection = section;
                }
                else
                {
                    if (IsComment(line))
                    {
                        if (lastSection == null)
                        {
                            this._IniFile.Comments.Add(new Comment(){Value=line});
                        }
                        else
                        {
                            lastSection.Values.Add(new Comment() {Value = line});
                        }
                    }
                    else
                    {
                        int index = line.IndexOf(Equal);
                        KeyValue keyValue = new KeyValue();

                        if (index == -1)
                        {
                            keyValue.Key = line;
                            keyValue.Value = line;
                        }
                        else
                        {
                            keyValue.Key = line.Substring(0, index);
                            keyValue.Value = line.Substring(index + 1);

                        }

                        
                        if (lastSection == null)
                            throw new InvalidDataException("Values out of Section! Line:" + lineNr  );

                        lastSection.Values.Add(keyValue);
                    }
                }

                lineNr += 1;
            }
        }

        private void FillLinesFromFile()
        {
            if (!File.Exists(this.FileName))
            {
                var file =File.Create(this.FileName);
                file.Close();
            }

            this._IniLines = new List<string>(File.ReadAllLines(this.FileName));
        }


        private Section FindSection(string section)
        {
            foreach (Section iniFileSection in this._IniFile.Sections)
            {
                if (iniFileSection.Name == section)
                {
                    return iniFileSection;
                }
            }
            return null;
        }

        //public KeyValue FindValue(string section, string key)
        //{
        //    Section iniFileSection = FindSection(section);
        //    if(iniFileSection == null) return null;

        //    foreach (var value in iniFileSection.Values)
        //    {
        //        var keyValue = (KeyValue) value;
        //        if (keyValue.Key == key)
        //        {
        //            return keyValue;
        //        }
        //    }
        //    return null;
        //}

        private KeyValue FindValue(Section section, string key)
        {
            foreach (var value in section.Values)
            {
                if (value is KeyValue kv)
                {
                    if (kv.Key == key)
                    {
                        return kv;
                    }

                }
            }

            return null;
        }


        public string ReadString(string section, string key, string defaultValue = "")
        {
            Section iniFileSection = FindSection(section);
            if (iniFileSection == null)
                return defaultValue;
            KeyValue keyValue = FindValue(iniFileSection, key);
            if (keyValue == null) return defaultValue;
            return keyValue.Value;
        }

        public bool WriteString(string section, string key, string defaultValue, string value)
        {
            Section iniFileSection = FindSection(section);
            KeyValue keyValue;
            if (string.IsNullOrEmpty(value))
                value = defaultValue;
            if (iniFileSection != null)
            {
                keyValue = FindValue(iniFileSection, key);
                if (keyValue == null)
                {
                    keyValue = new KeyValue() {Key = key, Value = value};
                    iniFileSection.Values.Add(keyValue);

                }
                else
                {
                    keyValue.Value = value;
                }
                if(this.AutoSave)
                    return Save();
                return true;
            }
           
            iniFileSection = new Section() {Name = section};
            keyValue = new KeyValue() {Key = key, Value = value};
            iniFileSection.Values.Add(keyValue);
            this._IniFile.Sections.Add(iniFileSection);
            if(this.AutoSave)
                return Save();
            return true;
       

            
        }

        public bool Save()
        {
            this._IniLines.Clear();
            foreach (var value in this._IniFile.Comments)
            {
                var iniFileComment = (Comment) value;
                this._IniLines.Add(iniFileComment.Value);
            }

            foreach (Section section in this._IniFile.Sections)
            {
                this._IniLines.Add(BracketOpen + section.Name + BracketClose);
                foreach (IValue value in section.Values)
                {
                    if (value is KeyValue kv)
                    {
                        if (string.IsNullOrEmpty(kv.Key) && string.IsNullOrEmpty(kv.Value))
                            this._IniLines.Add(kv.Value);
                        else
                            this._IniLines.Add(kv.Key + Equal + kv.Value);
                    }

                    if (value is Comment)
                    {
                        this._IniLines.Add(value.Value);
                    }
                    
                }

            }

            File.WriteAllLines(this.FileName, this._IniLines);
            return true;
        }
    }
}