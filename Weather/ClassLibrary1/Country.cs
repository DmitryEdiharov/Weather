using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace Component1
{
    public class country
    {
        public country()
        {

        }

        public string country_id { get; set; }

        public string city_id { get; set; }

        public string name { get; set; }
    }
}
