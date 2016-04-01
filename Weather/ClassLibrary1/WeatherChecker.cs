using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Component1
{
    public class WeatherChecker
    {
        public WeatherChecker()
        {

        }

        
        public string id { get; set; }
        private Arrays Arrays { get; set; } = null;
        public Weather Today { get; set; }
        public Weather Tomorrow { get; set; }
        public Weather Today_Night { get; set; }
        public Weather Tomorrow_Night { get; set; }

        /// <summary>
        /// Инициализирует массивы городов, стран и регионов
        /// </summary>
        public void InitializeArrays()
        {           
                Arrays = new Arrays();     
        }

        public async void BeginGetWeatherById()
        {
            Action act = new Action(GetWeatherByCityId);
            await Task.Run(act);
        }

        /// <summary>
        /// Выполняет поиск по сайту и получает данные о погоде
        /// </summary>
        /// <param name="id">номер города</param>
        public void GetWeatherByCityId()
        {
            XmlDocument doc = new XmlDocument();

            string url = @"http://informer.gismeteo.ua/xml/" + id + "_1.xml";
            try
            {
                doc.Load(url);
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new System.IO.FileNotFoundException("По данному городу прогноза не обнаружено. Попробуйте ввести другой город");                    
            }
            

            int i = 0;
            Weather[] w = new Weather[0];
            XmlNodeList node = doc.GetElementsByTagName("FORECAST");
            foreach (XmlElement item in node)
            {
                Array.Resize<Weather>(ref w, w.Length + 1);
                w[w.Length - 1] = new Weather();
                    w[w.Length-1].day = item.GetAttribute("day");
                    w[i].month = item.GetAttribute("month");
                    w[i].year = item.GetAttribute("year");
                    w[i].hour = item.GetAttribute("hour");
                    w[i].weekday = item.GetAttribute("weekday");                    
                


                var sub_element = item.GetElementsByTagName("PHENOMENA");
                foreach (XmlElement att in sub_element)
                {
                    w[i].cloudiness = att.GetAttribute("cloudiness");
                    w[i].precipitation = att.GetAttribute("precipitation");
                }

                sub_element = item.GetElementsByTagName("PRESSURE");
                foreach (XmlElement att in sub_element)
                {
                    w[i].pressure_max = att.GetAttribute("max");
                    w[i].pressure_min = att.GetAttribute("min");
                }

                sub_element = item.GetElementsByTagName("TEMPERATURE");
                foreach (XmlElement att in sub_element)
                {
                    w[i].temperature_max = att.GetAttribute("max");
                    w[i].temperature_min = att.GetAttribute("min");
                }

                sub_element = item.GetElementsByTagName("WIND");
                foreach (XmlElement att in sub_element)
                {
                    w[i].wind_max = att.GetAttribute("max");
                    w[i].wind_min = att.GetAttribute("min");
                    w[i].wind_dir = att.GetAttribute("direction");
                    switch (w[i].wind_dir)
                    {
                        case "0": w[i].wind_dir = "Нет ветра";
                            break;
                        case "1": w[i].wind_dir = "Северный";
                            break;
                        case "2": w[i].wind_dir = "Северо-восточный";
                            break;
                        case "3": w[i].wind_dir = "Восточный";
                            break;
                        case "4": w[i].wind_dir = "Юго-восточный";
                            break;
                        case "5": w[i].wind_dir = "Южный";
                            break;
                        case "6": w[i].wind_dir = "Юго-западный";
                            break;
                        case "7": w[i].wind_dir = "Западный";
                            break;
                        case "8": w[i].wind_dir = "Северо-западный";
                            break;
                        default:
                            break;
                    }
                }

                sub_element = item.GetElementsByTagName("RELWET");
                foreach (XmlElement att in sub_element)
                {
                    w[i].relwet_max = att.GetAttribute("max");
                    w[i].relwet_min = att.GetAttribute("min");
                }

                sub_element = item.GetElementsByTagName("HEAT");
                foreach (XmlElement att in sub_element)
                {
                    w[i].heat_max = att.GetAttribute("max");
                    w[i].heat_min = att.GetAttribute("min");
                }

                i++;
            }

            Today = w[0];// 15 00
            Today_Night = w[1];//21 00


            Tomorrow = w[3];//09 00
            Tomorrow_Night = w[2];//03 00
        }

        /// <summary>
        /// Возвращает номер города для дальнейней работы с ним по имени
        /// </summary>
        /// <param name="city_name">Имя города</param>
        /// <returns>идентификационный номер города</returns>
        public string GetCityIdByName(string city_name)
        {
            if (Arrays != null)
            {
                var query = from i in Arrays.cities
                            where i.name == city_name
                            select new {
                                i.city_id,
                                i.country_name,
                                i.name
                            };
                city tmp = new city();
                foreach (var item in query)
                {
                    tmp = new city()
                    {
                        city_id = item.city_id,
                        country_name = item.country_name,
                        name = item.name
                    };
                }

                return tmp.city_id;
            }
            throw new NullReferenceException("прграмма ссылаетс на неинициализированный массив данных.");
        }

        /// <summary>
        /// Возвращает массив городов
        /// </summary>
        /// <returns>Масив городов</returns>
        public city[] GetCities()
        {
            if (Arrays != null)
                return Arrays.cities;

            throw new NullReferenceException("Невозможно плучить данные из неинициализированного обьекта. сначала инициализируйте обьект \"Arrays\"");
        }

        /// <summary>
        /// Возвращает города указанной страны
        /// </summary>
        /// <param name="country_id">Номер страны</param>
        /// <returns>Массив городов запрошенной страны;</returns>
        public city[] GetCitiesByCountry(string country_name)
        {
            if (Arrays != null)
            {
                var query = from i in Arrays.cities
                            where i.country_name == country_name
                            select new
                            {
                                i.city_id,
                                i.country_name,
                                i.name,
                            };

                city[] c = new city[0];
                foreach (var item in query)
                {
                    Array.Resize(ref c, c.Length + 1);
                    city i = new city()
                    {
                        city_id = item.city_id,
                        country_name = item.country_name,
                        name = item.name,
                    };
                    c[c.Length - 1] = i;
                }
                return c;
            }
            else
            {
                throw new NullReferenceException("Невозможно плучить данные из неинициализированного обьекта. сначала инициализируйте обьект \"Arrays\"");
            }
        }        

        /// <summary>
        /// Возвращает массив стран
        /// </summary>
        /// <returns>Масив стран</returns>
        public string[] GetCountries()
        {
            if (Arrays != null)
                return Arrays.countries;

            throw new NullReferenceException("Невозможно плучить данные из неинициализированного обьекта. сначала инициализируйте обьект \"Arrays\"");
        }          


    }
}
