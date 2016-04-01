using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace Component1
{
    
    public class region
    {
        public region()
        {
                
        }

        public string name { get; set; }

        
        public int region_id { get; set; }

        
        public int country_id { get; set; }

        
        public int city_id { get; set; }
    }
}
