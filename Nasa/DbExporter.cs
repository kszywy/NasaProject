using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Nasa
{
    internal class DbExporter
    {
        private readonly DbConnection _connection;

        public DbExporter(DbConnection connection)
        {
            this._connection = connection;
        }

        private List<SpaceWeather> _spaceList = new List<SpaceWeather>();
        private List<EarthWeather> _earthList = new List<EarthWeather>();

        private void GetSpaceWeatherData()
        {
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                // Pobieranie SpaceWeather
                string query = "SELECT * FROM spaceweather;";
                MySqlCommand cmd = new MySqlCommand(query, _conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this._spaceList.Add(new SpaceWeather() {
                            IdSpace = reader.GetInt32(0),                                       // IdSpace
                            EventId = reader.GetString(1),                                      // EventId
                            EventType = reader.IsDBNull(2) ? null : reader.GetString(2),        // EventType
                            BeginTime = reader.IsDBNull(3) ? null : reader.GetString(3),        // BeginTime
                            PeakTime = reader.IsDBNull(4) ? null : reader.GetString(4),         // PeakTime
                            EndTime = reader.IsDBNull(5) ? null : reader.GetString(5),          // EndTime
                            ClassType = reader.IsDBNull(6) ? null : reader.GetString(6),        // ClassType
                            SourceLocation = reader.IsDBNull(7) ? null : reader.GetString(7),   // SourceLocation
                            ActiveRegion = reader.IsDBNull(8) ? null : reader.GetString(8),     // ActiveRegion
                            Instruments = reader.IsDBNull(9) ? null : reader.GetString(9),      // Instruments
                            Note = reader.IsDBNull(10) ? null : reader.GetString(10),           // Note (nullable)
                            KpIndex = reader.IsDBNull(11) ? null : reader.GetString(11),        // KpIndex
                            ObservedTime = reader.IsDBNull(12) ? null : reader.GetString(12),   // Note (nullable)
                            Source = reader.IsDBNull(13) ? null : reader.GetString(13),         // Note (nullable)
                            Date = DateOnly.FromDateTime(reader.GetDateTime(14)),               // Date
                            Year = reader.IsDBNull(15) ? null : reader.GetInt32(15),            // Year
                            Month = reader.IsDBNull(16) ? null : reader.GetInt32(16),           // Month
                            Day = reader.IsDBNull(17) ? null : reader.GetInt32(17),             // Day
                            Hour = reader.IsDBNull(18) ? null : reader.GetInt32(18),            // Hour
                        });
                    }
                    reader.Close();
                }
            }

        }

        private void GetEarthWeatherData()
        {
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                // Pobieranie SpaceWeather
                string query = "SELECT * FROM earthweather;";
                MySqlCommand cmd = new MySqlCommand(query, _conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this._earthList.Add(new EarthWeather() { 
                            IdEarth = reader.GetInt32(0),                                                           // IdEarth
                            Country = reader.IsDBNull(1) ? null : reader.GetString(1),                              // Country
                            LocationName = reader.IsDBNull(2) ? null : reader.GetString(2),                         // LocationName
                            Latitude = reader.IsDBNull(3) ? null : reader.GetDouble(3),                             // Latitude
                            Longitude = reader.IsDBNull(4) ? null : reader.GetDouble(4),                            // Longitude
                            Timezone = reader.IsDBNull(5) ? null : reader.GetString(5),                             // Timezone
                            Date = DateOnly.FromDateTime(reader.GetDateTime(6)),                                    // Date
                            LastUpdatedEpoch = reader.IsDBNull(7) ? null : reader.GetInt64(7),                      // LastUpdatedEpoch
                            LastUpdated = reader.GetDateTime(8),                                                    // LastUpdated
                            TemperatureCelsius = reader.IsDBNull(9) ? null : reader.GetDouble(9),                   // TemperatureCelsius
                            TemperatureFahrenheit = reader.IsDBNull(10) ? null : reader.GetDouble(10),              // TemperatureFahrenheit
                            ConditionText = reader.IsDBNull(11) ? null : reader.GetString(11),                      // ConditionText
                            WindMph = reader.IsDBNull(12) ? null : reader.GetDouble(12),                            // WindMph
                            WindKph = reader.IsDBNull(13) ? null : reader.GetDouble(13),                            // WindKph
                            WindDegree = reader.IsDBNull(14) ? null : reader.GetInt32(14),                          // WindDegree
                            WindDirection = reader.IsDBNull(15) ? null : reader.GetString(15),                      // WindDirection
                            PressureMb = reader.IsDBNull(16) ? null : reader.GetDouble(16),                         // PressureMb
                            PressureIn = reader.IsDBNull(17) ? null : reader.GetDouble(17),                         // PressureIn
                            PrecipMm = reader.IsDBNull(19) ? null : reader.GetDouble(18),                           // PrecipMm
                            PrecipIn = reader.IsDBNull(19) ? null : reader.GetDouble(19),                           // PrecipIN
                            Humidity = reader.IsDBNull(20) ? null : reader.GetInt32(20),                            // Humidity
                            Cloud = reader.IsDBNull(21) ? null : reader.GetInt32(21),                               // Cloud
                            FeelsLikeCelsius = reader.IsDBNull(22) ? null : reader.GetDouble(22),                   // FeelsLikeCelsius
                            FeelsLikeFahrenheit = reader.IsDBNull(23) ? null : reader.GetDouble(23),                // FeelsLikeFahrenheit
                            VisibilityKm = reader.IsDBNull(24) ? null : reader.GetDouble(24),                       // VisibilityKm
                            VisibilityMiles = reader.IsDBNull(25) ? null : reader.GetDouble(25),                    // VisibilityMiles
                            UvIndex = reader.IsDBNull(26) ? null : reader.GetDouble(26),                            // UvIndex
                            GustMph = reader.IsDBNull(27) ? null : reader.GetDouble(27),                            // GustMph
                            GustKph = reader.IsDBNull(28) ? null : reader.GetDouble(28),                            // GustKph
                            AirQualityCarbonMonoxide = reader.IsDBNull(29) ? null : reader.GetDouble(29),           // AirQualityCarbonMonoxide
                            AirQualityOzone = reader.IsDBNull(30) ? null : reader.GetDouble(30),                    // AirQualityOzone
                            AirQualityNitrogenDioxide = reader.IsDBNull(31) ? null : reader.GetDouble(31),          // AirQualityNitrogenDioxide
                            AirQualitySulphurDioxide = reader.IsDBNull(32) ? null : reader.GetDouble(32),           // AirQualitySulphurDioxide
                            AirQualityPM2_5 = reader.IsDBNull(33) ? null : reader.GetDouble(33),                    // AirQualityPM2_5
                            AirQualityPM10 = reader.IsDBNull(34) ? null : reader.GetDouble(34),                     // AirQualityPM10
                            AirQualityUsEpaIndex = reader.IsDBNull(35) ? null : reader.GetInt32(35),                // AirQualityUsEpaIndex
                            AirQualityGbDefraIndex = reader.IsDBNull(36) ? null : reader.GetInt32(36),              // AirQualityGbDefraIndex
                            Sunrise = reader.IsDBNull(37) ? null : reader.GetFieldValue<TimeSpan>(37),              // Sunrise
                            Sunset = reader.IsDBNull(38) ? null : reader.GetFieldValue<TimeSpan>(38),               // Sunset
                            Moonrise = reader.IsDBNull(39) ? null : reader.GetFieldValue<TimeSpan>(39),             // Moonrise
                            Moonset = reader.IsDBNull(40) ? null : reader.GetFieldValue<TimeSpan>(40),              // Moonset
                            MoonPhase = reader.IsDBNull(41) ? null : reader.GetString(41),                          // MoonPhase
                            MoonIllumination = reader.IsDBNull(42) ? null : reader.GetInt32(42)                     // MoonIllumination
                        });
                    }
                    reader.Close();
                }
            }

        }

        private void GetAllData()
        {
            GetEarthWeatherData();
            GetSpaceWeatherData();
        }
        

        public void ExportData(string format, string filePath)
        {
            GetAllData();

            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                switch (format.ToUpper())
                {
                    case "JSON":
                        var jsonData = new { SpaceList = _spaceList, EarthList = _earthList };
                        string jsonString = System.Text.Json.JsonSerializer.Serialize(jsonData, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                        File.WriteAllText(filePath, jsonString);

                        break;

                    case "XML":

                        var dataToExport = new WeatherExportWrapper
                        {
                            SpaceList = _spaceList,
                            EarthList = _earthList
                        };

                        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(WeatherExportWrapper));

                        using (var writer = new StreamWriter(filePath))
                        {
                            serializer.Serialize(writer, dataToExport);
                        }


                        break;

                    // Nie ma potrzeby eksportu do SQL, jednak jeśli znajdzie się chwila można zrobić
                    //case "SQL":
                    //    break;

                    default:

                        break;
                }
            }
            // Czyszczenie tablic po eksporcie
            this._spaceList = [];
            this._earthList = [];
        }
    }
}
