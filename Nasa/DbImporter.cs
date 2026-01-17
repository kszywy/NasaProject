using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Serialization;

namespace Nasa
{
    internal class DbImporter
    {
        private readonly DbConnection _connection;
        private List<SpaceWeather> _spaceList = new List<SpaceWeather>();
        private List<EarthWeather> _earthList = new List<EarthWeather>();

        public DbImporter(DbConnection connection)
        {
            _connection = connection;
        }

        public void LoadFromFile(string format, string filePath)
        {
            string content = File.ReadAllText(filePath);

            if (format.ToUpper() == "JSON")
            {
                // Przykład dla SpaceWeather (analogicznie dla Earth)
                _spaceList = JsonSerializer.Deserialize<List<SpaceWeather>>(content) ?? new();
                // Przykład dla EarthWeather
                _earthList = JsonSerializer.Deserialize<List<EarthWeather>>(content) ?? new();
            }
            else if (format.ToUpper() == "XML")
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<SpaceWeather>));
                using (StringReader reader = new StringReader(content))
                {
                    _spaceList = (List<SpaceWeather>)serializer.Deserialize(reader);
                }

                serializer = new XmlSerializer(typeof(List<EarthWeather>));
                using (StringReader reader = new StringReader(content))
                {
                    _earthList = (List<EarthWeather>)serializer.Deserialize(reader);
                }
            }
        }

        public void SaveToDatabase()
        {
            using (MySqlConnection conn = _connection.ReturnDBConnection())
            {
                string query;

                foreach (var item in _spaceList)
                {
                    query = "INSERT INTO spaceweather" +
                            "VALUES (@IdSpace, @EventId, @EventType, @BeginTime, @PeakTime, @EndTime, @ClassType, " +
                            "@SourceLocation, @ActiveRegion, @Instruments, @Note, @KpIndex, @ObservedTime, @Source, " +
                            "@Date, @Year, @Month, @Day, @Hour)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdSpace", item.IdSpace);
                        cmd.Parameters.AddWithValue("@EventId", item.EventId);
                        cmd.Parameters.AddWithValue("@EventType", item.EventType);
                        cmd.Parameters.AddWithValue("@BeginTime", item.BeginTime);
                        cmd.Parameters.AddWithValue("@PeakTime", item.PeakTime);
                        cmd.Parameters.AddWithValue("@EndTime", item.EndTime);
                        cmd.Parameters.AddWithValue("@ClassType", item.ClassType);
                        cmd.Parameters.AddWithValue("@SourceLocation", item.SourceLocation);
                        cmd.Parameters.AddWithValue("@ActiveRegion", item.ActiveRegion);
                        cmd.Parameters.AddWithValue("@Instruments", item.Instruments);
                        cmd.Parameters.AddWithValue("@Note", item.Note);
                        cmd.Parameters.AddWithValue("@KpIndex", item.KpIndex);
                        cmd.Parameters.AddWithValue("@ObservedTime", item.ObservedTime);
                        cmd.Parameters.AddWithValue("@Source", item.Source);
                        cmd.Parameters.AddWithValue("@Date", item.Date.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Year", item.Year);
                        cmd.Parameters.AddWithValue("@Month", item.Month);
                        cmd.Parameters.AddWithValue("@Day", item.Day);
                        cmd.Parameters.AddWithValue("@Hour", item.Hour);
                        cmd.ExecuteNonQuery();
                    }
                }

                foreach (var item in _earthList)
                {
                    query = "INSERT INTO earthweather" +
                            "VALUES (@IdEarth, @Country, @LocationName, @Latitude, @Longitude, @Timezone, @Date," +
                            "@LastUpdatedEpoch, @LastUpdated,@TemperatureCelsius, @TemperatureFahrenheit, @ConditionText," +
                            "@WindMph, @WindKph, @WindDegree, @WindDirection,@PressureMb, @PressureIn, @PrecipMm, @PrecipIn," +
                            "@Humidity, @Cloud, @FeelsLikeCelsius, @FeelsLikeFahrenheit,@VisibilityKm, @VisibilityMiles," +
                            "@UvIndex, @GustMph, @GustKph,@AirQualityCarbonMonoxide, @AirQualityOzone," +
                            "@AirQualityNitrogenDioxide, @AirQualitySulphurDioxide, @AirQualityPM2_5, @AirQualityPM10," +
                            "@AirQualityUsEpaIndex, @AirQualityGbDefraIndex,@Sunrise, @Sunset, @Moonrise, @Moonset," +
                            "@MoonPhase, @MoonIllumination)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdEarth", item.IdEarth);
                        cmd.Parameters.AddWithValue("@Country", item.Country);
                        cmd.Parameters.AddWithValue("@LocationName", item.LocationName);
                        cmd.Parameters.AddWithValue("@Latitude", item.Latitude);
                        cmd.Parameters.AddWithValue("@Longitude", item.Longitude);
                        cmd.Parameters.AddWithValue("@Timezone", item.Timezone);
                        cmd.Parameters.AddWithValue("@Date", item.Date);
                        cmd.Parameters.AddWithValue("@LastUpdatedEpoch", item.LastUpdatedEpoch);
                        cmd.Parameters.AddWithValue("@LastUpdated", item.LastUpdated);
                        cmd.Parameters.AddWithValue("@TemperatureCelsius", item.TemperatureCelsius);
                        cmd.Parameters.AddWithValue("@TemperatureFahrenheit", item.TemperatureFahrenheit);
                        cmd.Parameters.AddWithValue("@ConditionText", item.ConditionText);
                        cmd.Parameters.AddWithValue("@WindMph", item.WindMph);
                        cmd.Parameters.AddWithValue("@WindKph", item.WindKph);
                        cmd.Parameters.AddWithValue("@WindDegree", item.WindDegree);
                        cmd.Parameters.AddWithValue("@WindDirection", item.WindDirection);
                        cmd.Parameters.AddWithValue("@PressureMb", item.PressureMb);
                        cmd.Parameters.AddWithValue("@PressureIn", item.PressureIn);
                        cmd.Parameters.AddWithValue("@PrecipMm", item.PrecipMm);
                        cmd.Parameters.AddWithValue("@PrecipIn", item.PrecipIn);
                        cmd.Parameters.AddWithValue("@Humidity", item.Humidity);
                        cmd.Parameters.AddWithValue("@Cloud", item.Cloud);
                        cmd.Parameters.AddWithValue("@FeelsLikeCelsius", item.FeelsLikeCelsius);
                        cmd.Parameters.AddWithValue("@FeelsLikeFahrenheit", item.FeelsLikeFahrenheit);
                        cmd.Parameters.AddWithValue("@VisibilityKm", item.VisibilityKm);
                        cmd.Parameters.AddWithValue("@VisibilityMiles", item.VisibilityMiles);
                        cmd.Parameters.AddWithValue("@UvIndex", item.UvIndex);
                        cmd.Parameters.AddWithValue("@GustMph", item.GustMph);
                        cmd.Parameters.AddWithValue("@GustKph", item.GustKph);

                        // Air Quality
                        cmd.Parameters.AddWithValue("@AirQualityCarbonMonoxide", item.AirQualityCarbonMonoxide);
                        cmd.Parameters.AddWithValue("@AirQualityOzone", item.AirQualityOzone);
                        cmd.Parameters.AddWithValue("@AirQualityNitrogenDioxide", item.AirQualityNitrogenDioxide);
                        cmd.Parameters.AddWithValue("@AirQualitySulphurDioxide", item.AirQualitySulphurDioxide);
                        cmd.Parameters.AddWithValue("@AirQualityPM2_5", item.AirQualityPM2_5);
                        cmd.Parameters.AddWithValue("@AirQualityPM10", item.AirQualityPM10);
                        cmd.Parameters.AddWithValue("@AirQualityUsEpaIndex", item.AirQualityUsEpaIndex);
                        cmd.Parameters.AddWithValue("@AirQualityGbDefraIndex", item.AirQualityGbDefraIndex);

                        // Astronomy
                        cmd.Parameters.AddWithValue("@Sunrise", item.Sunrise);
                        cmd.Parameters.AddWithValue("@Sunset", item.Sunset);
                        cmd.Parameters.AddWithValue("@Moonrise", item.Moonrise);
                        cmd.Parameters.AddWithValue("@Moonset", item.Moonset);
                        cmd.Parameters.AddWithValue("@MoonPhase", item.MoonPhase);
                        cmd.Parameters.AddWithValue("@MoonIllumination", item.MoonIllumination);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
