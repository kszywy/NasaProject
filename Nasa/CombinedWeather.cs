using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa
{
    internal class CombinedWeather
    {
        public string EventType { get; set; }
        public string ClassType { get; set; }
        public double TemperatureCelsius { get; set; }
        public string ConditionText { get; set; }

    }
}
