using System;
using System.Xml.Serialization;

namespace Component1
{
    [XmlRoot(ElementName ="t")]
    public class city
    {
        public city()
        {

        }

        [XmlAttribute(AttributeName = "i")]
        public string city_id { get; set; }

        [XmlAttribute(AttributeName = "c")]
        public string country_name { get; set; }

        [XmlAttribute(AttributeName = "n")]
        public string name { get; set; }

    }
}
