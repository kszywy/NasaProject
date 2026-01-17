using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa
{
    internal class DbCreator
    {
        private readonly DbConnection _connection;

        public DbCreator(DbConnection connection)
        {
            this._connection = connection;
        }

        // Baza powinna być już stworzona przez użytkownika, ale na wszelki wypadek istnieje ta metoda
        public void CreateDatabase()
        {
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS weather; USE weather;", _conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateSpaceWeather()
        {
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                string query = "CREATE TABLE `spaceweather` (\r\n  `id_space` int(11) NOT NULL,\r\n  `event_id` varchar(27) DEFAULT NULL,\r\n  `event_type` varchar(17) DEFAULT NULL,\r\n  `begin_time` varchar(25) DEFAULT NULL,\r\n  `peak_time` varchar(25) DEFAULT NULL,\r\n  `end_time` varchar(25) DEFAULT NULL,\r\n  `class_type` varchar(4) DEFAULT NULL,\r\n  `source_location` varchar(7) DEFAULT NULL,\r\n  `active_region` varchar(5) DEFAULT NULL,\r\n  `instruments` varchar(38) DEFAULT NULL,\r\n  `note` varchar(930) DEFAULT NULL,\r\n  `kp_index` varchar(3) DEFAULT NULL,\r\n  `observed_time` varchar(25) DEFAULT NULL,\r\n  `source` varchar(4) DEFAULT NULL,\r\n  `date` date DEFAULT NULL,\r\n  `year` int(4) DEFAULT NULL,\r\n  `month` int(2) DEFAULT NULL,\r\n  `day` int(2) DEFAULT NULL,\r\n  `hour` int(2) DEFAULT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;";
                MySqlCommand cmd = new MySqlCommand(query, _conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateEarthWeather()
        {
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                string query = "CREATE TABLE `earthweather` (\r\n  `id_earth` int(11) NOT NULL,\r\n  `country` varchar(32) DEFAULT NULL,\r\n  `location_name` varchar(21) DEFAULT NULL,\r\n  `latitude` decimal(7,4) DEFAULT NULL,\r\n  `longitude` decimal(8,4) DEFAULT NULL,\r\n  `timezone` varchar(30) DEFAULT NULL,\r\n  `date` date DEFAULT NULL,\r\n  `last_updated_epoch` int(10) DEFAULT NULL,\r\n  `last_updated` varchar(16) DEFAULT NULL,\r\n  `temperature_celsius` decimal(4,1) DEFAULT NULL,\r\n  `temperature_fahrenheit` decimal(4,1) DEFAULT NULL,\r\n  `condition_text` varchar(43) DEFAULT NULL,\r\n  `wind_mph` decimal(5,1) DEFAULT NULL,\r\n  `wind_kph` decimal(5,1) DEFAULT NULL,\r\n  `wind_degree` int(3) DEFAULT NULL,\r\n  `wind_direction` varchar(3) DEFAULT NULL,\r\n  `pressure_mb` decimal(5,1) DEFAULT NULL,\r\n  `pressure_in` decimal(4,2) DEFAULT NULL,\r\n  `precip_mm` decimal(4,2) DEFAULT NULL,\r\n  `precip_in` decimal(3,2) DEFAULT NULL,\r\n  `humidity` int(3) DEFAULT NULL,\r\n  `cloud` int(3) DEFAULT NULL,\r\n  `feels_like_celsius` decimal(4,1) DEFAULT NULL,\r\n  `feels_like_fahrenheit` decimal(4,1) DEFAULT NULL,\r\n  `visibility_km` decimal(3,1) DEFAULT NULL,\r\n  `visibility_miles` decimal(3,1) DEFAULT NULL,\r\n  `uv_index` decimal(3,1) DEFAULT NULL,\r\n  `gust_mph` decimal(5,1) DEFAULT NULL,\r\n  `gust_kph` decimal(5,1) DEFAULT NULL,\r\n  `air_quality_Carbon_Monoxide` decimal(8,3) DEFAULT NULL,\r\n  `air_quality_Ozone` decimal(4,1) DEFAULT NULL,\r\n  `air_quality_Nitrogen_dioxide` decimal(6,3) DEFAULT NULL,\r\n  `air_quality_Sulphur_dioxide` decimal(6,3) DEFAULT NULL,\r\n  `air_quality_PM2.5` decimal(6,3) DEFAULT NULL,\r\n  `air_quality_PM10` decimal(7,3) DEFAULT NULL,\r\n  `air_quality_us-epa-index` int(1) DEFAULT NULL,\r\n  `air_quality_gb-defra-index` int(2) DEFAULT NULL,\r\n  `sunrise` varchar(8) DEFAULT NULL,\r\n  `sunset` varchar(8) DEFAULT NULL,\r\n  `moonrise` varchar(11) DEFAULT NULL,\r\n  `moonset` varchar(10) DEFAULT NULL,\r\n  `moon_phase` varchar(15) DEFAULT NULL,\r\n  `moon_illumination` int(3) DEFAULT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;";
                MySqlCommand cmd = new MySqlCommand(query, _conn);
                cmd.ExecuteNonQuery();
            }

        }

        public void CreateSpaceWeatherCombined()
        {
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                string query = "CREATE TABLE `spaceweathercombined` (\r\n  `id_space` int(11) NOT NULL,\r\n  `event_id` varchar(27) DEFAULT NULL,\r\n  `event_type` varchar(17) DEFAULT NULL,\r\n  `begin_time` varchar(25) DEFAULT NULL,\r\n  `peak_time` varchar(25) DEFAULT NULL,\r\n  `end_time` varchar(25) DEFAULT NULL,\r\n  `class_type` varchar(4) DEFAULT NULL,\r\n  `source_location` varchar(7) DEFAULT NULL,\r\n  `active_region` varchar(5) DEFAULT NULL,\r\n  `instruments` varchar(38) DEFAULT NULL,\r\n  `note` varchar(930) DEFAULT NULL,\r\n  `date` date DEFAULT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;";
                MySqlCommand cmd = new MySqlCommand(query, _conn);
                cmd.ExecuteNonQuery();
            }

        }

        public void CreateEarthWeatherCombined()
        {
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                string query = "CREATE TABLE `earthweathercombined` (\r\n  `id_earth` int(11) NOT NULL,\r\n  `country` varchar(32) DEFAULT NULL,\r\n  `location_name` varchar(21) DEFAULT NULL,\r\n  `timezone` varchar(30) DEFAULT NULL,\r\n  `date` date DEFAULT NULL,\r\n  `temperature_celsius` decimal(4,1) DEFAULT NULL,\r\n  `condition_text` varchar(43) DEFAULT NULL,\r\n  `wind_kph` decimal(5,1) DEFAULT NULL,\r\n  `pressure_mb` decimal(5,1) DEFAULT NULL,\r\n  `humidity` int(3) DEFAULT NULL,\r\n  `cloud` int(3) DEFAULT NULL,\r\n  `feels_like_celsius` decimal(4,1) DEFAULT NULL,\r\n  `air_quality_us-epa-index` int(1) DEFAULT NULL,\r\n  `air_quality_gb-defra-index` int(2) DEFAULT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;";
                MySqlCommand cmd = new MySqlCommand(query, _conn);
                cmd.ExecuteNonQuery();
            }

        }

        public void CreateDates()
        {
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                // Utworzenie dat
                MySqlCommand cmd = new MySqlCommand("CREATE TABLE `dates` (`date_id` date NOT NULL) DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;", _conn);
                cmd.ExecuteNonQuery();

                // Zapchanie tabeli datami
                cmd = new MySqlCommand(@"
                    INSERT INTO dates (date_id)
                    WITH RECURSIVE calendar AS
                        (SELECT '2023-07-11' AS dt
                            UNION ALL
                            SELECT dt + INTERVAL 1 DAY
                            FROM calendar
                            WHERE dt < '2025-12-21')
                    SELECT dt FROM calendar;",
                    _conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void createRelations()
        {
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                string[] queries =
                {
                    "ALTER TABLE `earthweather`\r\n  MODIFY `id_earth` int(11) NOT NULL AUTO_INCREMENT;",
                    "ALTER TABLE `earthweathercombined`\r\n  MODIFY `id_earth` int(11) NOT NULL AUTO_INCREMENT;",
                    "ALTER TABLE `spaceweather`\r\n  MODIFY `id_space` int(11) NOT NULL AUTO_INCREMENT;",
                    "ALTER TABLE `spaceweathercombined`\r\n  MODIFY `id_space` int(11) NOT NULL AUTO_INCREMENT;",
                    "ALTER TABLE `earthweather`\r\n  ADD CONSTRAINT `earthweather_ibfk_1` FOREIGN KEY (`date`) REFERENCES `dates` (`date_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;",
                    "ALTER TABLE `spaceweather`\r\n  ADD CONSTRAINT `spaceweather_ibfk_1` FOREIGN KEY (`date`) REFERENCES `dates` (`date_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;"
                };

                foreach (var query in queries)
                {
                    MySqlCommand cmd = new MySqlCommand(query, _conn);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void InitializeAll()
        {
            try
            {
                //CreateDatabase();
                CreateDates();
                CreateSpaceWeather();
                CreateEarthWeather();
                CreateSpaceWeatherCombined();
                CreateEarthWeatherCombined();
                createRelations();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nastąpił błąd przy tworzeniu bazy danych:\n" + ex.Message);

            }
        }
    }
}
