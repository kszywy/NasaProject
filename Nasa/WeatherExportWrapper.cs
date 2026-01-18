using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nasa
{
    [XmlRoot("AllWeatherData")]
    public class WeatherExportWrapper
    {
        public List<SpaceWeather> SpaceList { get; set; } = new List<SpaceWeather>();
        public List<EarthWeather> EarthList { get; set; } = new List<EarthWeather>();
    }
}
