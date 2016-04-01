using System.Xml.Serialization;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Component1
{
    public class Arrays
    {
        internal city[] cities;
        internal string[] countries;

        public ArrsToSer a;

        public Arrays()
        {
            try
            {
                GetArrays();
                //Action a = new Action(GetArrays);
                //Task.Run(a);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void GetArrays()
        {
            var _ser = new XmlSerializer(typeof(ArrsToSer));

            string path = Environment.CurrentDirectory + "\\..\\..\\ClassLibrary1\\gismeteo-All.xml";

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                a = _ser.Deserialize(fs) as ArrsToSer;
            }


            cities = a.cities;
            var query = from i in cities
                        select i.country_name;

            //Удаление поторяющихся стран
            countries = query.Distinct().ToArray<string>();

        }
    }
}
