using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Nasa
{
    // KLASA DO PRZECHOWYWANIA DANYCH POGODOWYCH ZIEMI Z JEDNEGO WIERSZA TABELI
    public class EarthWeather
    {
        public int IdEarth { get; set; }
        public string? Country { get; set; }
        public string? LocationName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Timezone { get; set; }

        [XmlIgnore]
        public DateOnly Date { get; set; }

        [JsonIgnore]
        [XmlElement("Date")]
        public string DateString
        {
            get { return Date.ToString("yyyy-MM-dd"); }
            set
            {
                if (DateOnly.TryParse(value, out var result))
                    Date = result;
            }
        }
        public long? LastUpdatedEpoch { get; set; }
        public DateTime LastUpdated { get; set; }
        public double? TemperatureCelsius { get; set; }
        public double? TemperatureFahrenheit { get; set; }
        public string? ConditionText { get; set; }
        public double? WindMph { get; set; }
        public double? WindKph { get; set; }
        public int? WindDegree { get; set; }
        public string? WindDirection { get; set; }
        public double? PressureMb { get; set; }
        public double? PressureIn { get; set; }
        public double? PrecipMm { get; set; }
        public double? PrecipIn { get; set; }
        public int? Humidity { get; set; }
        public int? Cloud { get; set; }
        public double? FeelsLikeCelsius { get; set; }
        public double? FeelsLikeFahrenheit { get; set; }
        public double? VisibilityKm { get; set; }
        public double? VisibilityMiles { get; set; }
        public double? UvIndex { get; set; }
        public double? GustMph { get; set; }
        public double? GustKph { get; set; }

        // Air Quality
        public double? AirQualityCarbonMonoxide { get; set; }
        public double? AirQualityOzone { get; set; }
        public double? AirQualityNitrogenDioxide { get; set; }
        public double? AirQualitySulphurDioxide { get; set; }
        public double? AirQualityPM2_5 { get; set; }
        public double? AirQualityPM10 { get; set; }
        public int? AirQualityUsEpaIndex { get; set; }
        public int? AirQualityGbDefraIndex { get; set; }

        // Astronomy
        public TimeSpan? Sunrise { get; set; }
        public TimeSpan? Sunset { get; set; }
        public TimeSpan? Moonrise { get; set; }
        public TimeSpan? Moonset { get; set; }
        public string? MoonPhase { get; set; }
        public int? MoonIllumination { get; set; }
    }

    // Rekord reprezentujący jeden wiersz z tabeli earthweathercombined
    public record EarthWeatherCombined(
        int IdEarth,
        string? Country,
        string? LocationName,
        string? Timezone,
        DateOnly Date,
        double? TemperatureCelsius,
        string? ConditionText,
        double? WindKph ,
        double? PressureMb,
        int? Humidity,
        int? Cloud,
        double? FeelsLikeCelsius
    );
}
