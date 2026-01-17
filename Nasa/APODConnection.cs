using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace Nasa
{
    internal class ApodResponse
    {
        public string? MediaType { get; set; }
        public string? Url { get; set; }
        public string? HdUrl { get; set; }
    }

    internal class APODConnection
    {
        private const string apiKey = "XSMFNpkPKdhGpbcQ5xofcnkcEqzRFyucZatMjd7k";
        private static readonly HttpClient httpClient = new HttpClient();

        public string GetAPODUrl(DateTime date)
        {
            string formattedDate = date.ToString("yyyy-MM-dd");
            return $"https://api.nasa.gov/planetary/apod?api_key={apiKey}&date={formattedDate}";
        }

        public async Task<string?> GetImageFromAPODUrl(DateTime date)
        {
            string url = GetAPODUrl(date);

            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            var apod = JsonSerializer.Deserialize<ApodResponse>(json);

            // APOD czasem zwraca video
            if (apod?.MediaType != "image")
                return null;

            // Preferuj HD jeśli istnieje
            return apod.HdUrl ?? apod.Url;
        }
    }
}
