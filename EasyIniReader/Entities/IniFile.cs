using System.Collections.Generic;

namespace EasyIniReader.Entities
{
    internal class IniFile
    {
        public IniFile()
        {
            this.Comments = new List<IValue>();
            this.Sections = new List<Section>();
        }
        public List<IValue> Comments{get;set;}
        public List<Section> Sections{get;set;}
    }
}