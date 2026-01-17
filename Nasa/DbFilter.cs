using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa
{
    internal class DbFilter
    {
        private readonly DbConnection _connection;

        public DbFilter(DbConnection connection)
        {
            this._connection = connection;
        }

        private List<SpaceWeatherCombined> filteredSpaceList = new List<SpaceWeatherCombined>();
        private List<EarthWeatherCombined> filteredEarthList = new List<EarthWeatherCombined>();

        public void FilterSpaceWeather(DateOnly date)
        {
            MySqlCommand cmd;
            MySqlDataReader reader;
            // Formatowanie daty do standardu bazy danych
            var _date = date.ToString("o", CultureInfo.InvariantCulture);
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                string query = $"SELECT id_space, event_id, event_type, begin_time, peak_time, end_time, class_type, source_location, active_region, instruments, note, date FROM spaceweather WHERE date=\"{date}\";";
                cmd = new MySqlCommand(query);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.filteredSpaceList.Add(new SpaceWeatherCombined(
                            reader.GetInt32(0), // IdSpace
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(1), // EventId
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(2), // EventType
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(3), // BeginTime
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(4), // PeakTime
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(5), // EndTime
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(6), // ClassType
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(7), // SourceLocation
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(8), // ActiveRegion
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(9), // Instruments
                            reader.IsDBNull(10) ? string.Empty : reader.GetString(10), // Note (nullable)
                            DateOnly.FromDateTime(reader.GetDateTime(11)) // Date
                        ));
                    }
                    reader.Close();
                }
            }
        }

        public void FilterEarthWeather(DateOnly date)
        {
            MySqlCommand cmd;
            MySqlDataReader reader;
            // Formatowanie daty do standardu bazy danych
            var _date = date.ToString("o", CultureInfo.InvariantCulture);
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                string query = $"SELECT id_earth, country, location_name, timezone, date, temperature_celsius, condition_text, wind_kph, pressure_mb, humidity, cloud, feels_like_celsius FROM earthweather WHERE date=\"{date}\";";
                cmd = new MySqlCommand(query);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.filteredEarthList.Add(new EarthWeatherCombined(
                            reader.GetInt32(0), // IdEarth
                            reader.IsDBNull(1) ? string.Empty : reader.GetString(1), // Country
                            reader.IsDBNull(2) ? string.Empty : reader.GetString(2), // LocationName
                            reader.IsDBNull(3) ? string.Empty : reader.GetString(3), // Timezone
                            reader.IsDBNull(4) ? DateOnly.MinValue : DateOnly.FromDateTime(reader.GetDateTime(4)), // date
                            reader.IsDBNull(5) ? 0.0 : reader.GetDouble(5), // TemperatureCelsius
                            reader.IsDBNull(6) ? string.Empty : reader.GetString(6), // ConditionText
                            reader.IsDBNull(7) ? 0.0 : reader.GetDouble(7), // WindKph
                            reader.IsDBNull(8) ? 0.0 : reader.GetDouble(8), // PressureMb
                            reader.IsDBNull(9) ? 0 : reader.GetInt32(9), // Humidity
                            reader.IsDBNull(10) ? 0 : reader.GetInt32(10), // Cloud
                            reader.IsDBNull(11) ? 0.0 : reader.GetDouble(11) // FeelsLikeCelsius
                        ));
                    }
                    reader.Close();
                }
            }
        }

        public void EnterFilteredSpaceWeatherToCombined()
        {
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                foreach (var item in this.filteredSpaceList)
                {
                    string query = $"INSERT INTO spaceweathercombined (id_space, event_id, event_type, begin_time, peak_time, end_time, class_type, source_location, active_region, instruments, note, date) VALUES ({item.IdSpace}, \"{item.EventId}\", \"{item.EventType}\", \"{item.BeginTime}\", \"{item.PeakTime}\", \"{item.EndTime}\", \"{item.ClassType}\", \"{item.SourceLocation}\", \"{item.ActiveRegion}\", \"{item.Instruments}\", \"{item.Note}\", \"{item.Date}\");";
                    MySqlCommand cmd = new MySqlCommand(query, _conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EnterFilteredEarthWeatherToCombined()
        {
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                foreach (var item in this.filteredEarthList)
                {
                    string query = $"INSERT INTO earthweathercombined (id_earth, country, location_name, timezone, date, temperature_celsius, condition_text, wind_kph, pressure_mb, humidity, cloud, feels_like_celsius) VALUES ({item.IdEarth}, \"{item.Country}\", \"{item.LocationName}\", \"{item.Timezone}\", \"{item.date}\", {item.TemperatureCelsius}, \"{item.ConditionText}\", {item.WindKph}, {item.PressureMb}, {item.Humidity}, {item.Cloud}, {item.FeelsLikeCelsius});";
                    MySqlCommand cmd = new MySqlCommand(query, _conn);
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
