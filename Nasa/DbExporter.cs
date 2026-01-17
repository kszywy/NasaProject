using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa
{
    internal class DbExporter
    {
        private readonly DbConnection _connection;

        public DbExporter(DbConnection connection)
        {
            this._connection = connection;
        }

        public void ExportData(string format, string fileName, string filePath)
        {
            using (MySqlConnection _conn = _connection.ReturnDBConnection())
            {
                switch (format.ToUpper())
                {
                    case "JSON":

                        break;

                    case "XML":

                        break;

                    case "SQL":

                        break;
                }
            }
        }
    }
}
