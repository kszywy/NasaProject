using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa
{
    // KLASA DO ZARZĄDZANIA POŁĄCZENIAMI Z BAZĄ DANYCH
    internal class DbConnection
    {
        private const string ConnectionString = "datasource=127.0.0.1;" + "port=3306;" + "username=root;" + "password=;" + "database=weather";

        public MySqlConnection ReturnDBConnection()
        {

            var conn = new MySqlConnection(ConnectionString);

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }

        public MySqlConnection ReturnDBConnectionNoWeather()
        {

            var conn = new MySqlConnection("datasource=127.0.0.1;" + "port=3306;" + "username=root;" + "password=;");

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
