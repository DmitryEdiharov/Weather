using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component1
{
    public class Weather
    {
        //Данные о дне недели и времени показа данных о погоде
        public string day { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string hour { get; set; }
        public string weekday { get; set; }

        //Данные о погоде (облачность, осадки )
        public string cloudiness { get; set; }
        public string precipitation { get; set; }

        //Данные о давлении
        public string pressure_max { get; set; }
        public string pressure_min { get; set; }

        //данные о температуре
        public string temperature_max { get; set; }
        public string temperature_min { get; set; }

        //Данные о ветре(сила, направление)
        public string wind_max { get; set; }
        public string wind_min{ get; set; }
        public string wind_dir { get; set; }

    //данные о влажности
        public string relwet_max { get; set; }
        public string relwet_min { get; set; }

        //данные о температуре
        public string heat_max { get; set; }
        public string heat_min { get; set; }
    }
   // <FORECAST day = "31" month="03" year="2016" hour="14" tod="2" predict="0" weekday="5">
			//	<!-- погодные явления-->
			//	<PHENOMENA cloudiness = "3" precipitation="10"/> 
			//	<!-- давление-->
			//	<PRESSURE max = "760" min="758"/>
			//	<!-- температура-->
			//	<TEMPERATURE max = "10" min="8"/>
			//	<!-- ветер-->  <!-- 6 - южный, 1 - северный, 3- -->
			//	<WIND min = "2" max="4" direction="6"/>
			//	<!-- влажность(рт.ст.)-->
			//	<RELWET max = "61" min="59"/>
			//	<!-- жара-->
			//	<HEAT min = "7" max="9"/>
			//</FORECAST>
}
