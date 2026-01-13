using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa
{
    // KLASA DO PRZECHOWYWANIA DANYCH POGODOWYCH ZIEMI Z JEDNEGO WIERSZA TABELI
    public class EarthWeather
    {
        public string Country { get; set; }
        public string LocationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Timezone { get; set; }
        public long LastUpdatedEpoch { get; set; }
        public DateTime LastUpdated { get; set; }
        public double TemperatureCelsius { get; set; }
        public double TemperatureFahrenheit { get; set; }
        public string ConditionText { get; set; }
        public double WindMph { get; set; }
        public double WindKph { get; set; }
        public int WindDegree { get; set; }
        public string WindDirection { get; set; }
        public double PressureMb { get; set; }
        public double PressureIn { get; set; }
        public double PrecipMm { get; set; }
        public double PrecipIn { get; set; }
        public int Humidity { get; set; }
        public int Cloud { get; set; }
        public double FeelsLikeCelsius { get; set; }
        public double FeelsLikeFahrenheit { get; set; }
        public double VisibilityKm { get; set; }
        public double VisibilityMiles { get; set; }
        public double UvIndex { get; set; }
        public double GustMph { get; set; }
        public double GustKph { get; set; }

        // Air Quality
        public double AirQualityCarbonMonoxide { get; set; }
        public double AirQualityOzone { get; set; }
        public double AirQualityNitrogenDioxide { get; set; }
        public double AirQualitySulphurDioxide { get; set; }
        public double AirQualityPM2_5 { get; set; }
        public double AirQualityPM10 { get; set; }
        public int AirQualityUsEpaIndex { get; set; }
        public int AirQualityGbDefraIndex { get; set; }

        // Astronomy
        public TimeOnly Sunrise { get; set; }
        public TimeOnly Sunset { get; set; }
        public TimeOnly Moonrise { get; set; }
        public TimeOnly Moonset { get; set; }
        public string MoonPhase { get; set; }
        public int MoonIllumination { get; set; }
    }
}
