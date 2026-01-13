using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa
{
    // KLASA DO ZARZĄDZANIA POŁĄCZENIAMI Z BAZĄ DANYCH
    internal class DBConnection
    {
        private const string ConnectionString = "" + "datasource=127.0.0.1;" + "port=3306;" + "username=root;" + "password=;" + "SsslMode=none;" + "database=SpaceWeather";
        //POŁĄCZENIE Z BAZĄ Z KOSMOSU ABY WYCIĄGNĄC DANE
        List<SpaceWeather> sw_list = new List<SpaceWeather>();
        public List<SpaceWeather> GetEventByDateSpace(DateTime date)
        {
            string ConnectionString = "" + "datasource=127.0.0.1;" + "port=3306;" + "username=root;" + "password=;" + "SsslMode=none;" + "database=SpaceWeather";
            MySqlConnection dbConnection=new MySqlConnection(ConnectionString);
            MySqlCommand dbCommand;
            MySqlDataReader reader;
            try
            {
                dbConnection.Open();
                //ZAPYTANIE O ZWROT KOLUMNY ZE ZJAWISKIEM W KOSMOSIE ORAZ EVENT CLASSIFICATION
                string query = $"SELECT EVENT_TYPE,EVENT_CLASSIFICATION FROM SpaceWeather WHERE date={date}";
                dbCommand = new MySqlCommand(query);
                reader = dbCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sw_list.Add(new SpaceWeather()
                        {
                            EventType = reader.GetString(0),
                            ClassType = reader.GetString(1),
                        });
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sw_list;
        }


        //POŁĄCZENIE Z BAZĄ Z ZIEMI ABY WYCIĄGNĄĆ DANE
        List <EarthWeather> ew_list= new List<EarthWeather>();
        public List<EarthWeather> GetEventByDateEarth(DateTime date)
        {
            string ConnectionString = "" + "datasource=127.0.0.1;" + "port=3306;" + "username=root;" + "password=;" + "SsslMode=none;" + "database=EarthWeather";
            MySqlConnection dbConnection = new MySqlConnection(ConnectionString);
            MySqlCommand dbCommand;
            MySqlDataReader reader;
            try
            {
                dbConnection.Open();
                //ZAPYTANIE O ZWROT KOLUMNY ZE ZJAWISKIEM W KOSMOSIE ORAZ EVENT CLASSIFICATION
                string query = $"SELECT TEMPERATURE_CELSIUS,CONDITION_TEXT FROM EarthWeather WHERE date={date}";
                dbCommand = new MySqlCommand(query);
                reader = dbCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ew_list.Add(new EarthWeather()
                        {
                            TemperatureCelsius = Convert.ToDouble(reader.GetString(0)),
                            ConditionText = reader.GetString(1),
                        });
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ew_list;
        }
        List<CombinedWeather> cw_list=new List<CombinedWeather>();

        // UTWORZENIE TRZECIEJ BAZY DANYCH
        public void CreateNewDB(DateTime date)
        {
            int count=Math.Min(sw_list.Count,ew_list.Count);
            for (int i = 0; i < count; i++)
            {
                cw_list.Add(new CombinedWeather()
                {
                    EventType = sw_list[i].EventType,
                    ClassType = sw_list[i].ClassType,
                    TemperatureCelsius = ew_list[i].TemperatureCelsius,
                    ConditionText = ew_list[i].ConditionText
                });
            }
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;SslMode=none;database=CombinedWeatherDB";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // 4️⃣ Utworzenie tabeli jeśli nie istnieje
                string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS CombinedWeather (
                Id INT AUTO_INCREMENT PRIMARY KEY,
                EventType VARCHAR(255),
                ClassType VARCHAR(255),
                TemperatureCelsius DOUBLE,
                ConditionText VARCHAR(255)
            );";
                using (MySqlCommand cmd = new MySqlCommand(createTableQuery, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                // 5️⃣ Wstawienie rekordów z combinedList
                foreach (var item in cw_list)
                {
                    string insertQuery = @"
                INSERT INTO CombinedWeather (EventType, ClassType, TemperatureCelsius, ConditionText)
                VALUES (@eventType, @classType, @temperature, @condition);";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@eventType", item.EventType);
                        cmd.Parameters.AddWithValue("@classType", item.ClassType);
                        cmd.Parameters.AddWithValue("@temperature", item.TemperatureCelsius);
                        cmd.Parameters.AddWithValue("@condition", item.ConditionText);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Połączone dane zapisane na serwerze!");
        }
    }
}
