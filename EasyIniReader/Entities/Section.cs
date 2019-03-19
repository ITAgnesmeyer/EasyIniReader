using System.Collections.Generic;

namespace EasyIniReader.Entities
{
    internal class Section
    {
        public Section()
        {
            this.Values = new List<IValue>();
            
        }
        public string Name{get;set;}
        public List<IValue> Values{get;set;}
        
    }
}