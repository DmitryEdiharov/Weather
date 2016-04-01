using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Component1
{
    [XmlRoot(ElementName = "document")]
    public class ArrsToSer
    {
        public ArrsToSer()
        {

        }

        [XmlElement(ElementName ="t")]
        public city[] cities { get; set; }




    }
}
