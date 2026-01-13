using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa
{
    internal class APODConnection
    {
        private const string apiKey = "XSMFNpkPKdhGpbcQ5xofcnkcEqzRFyucZatMjd7k";

        public string GetAPODUrl(DateTime date)
        {
            string formattedDate = date.ToString("yyyy-MM-dd");
            return $"https://api.nasa.gov/planetary/apod?api_key={apiKey}&date={formattedDate}";
        }
    }
}
