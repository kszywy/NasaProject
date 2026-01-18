using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nasa
{
    internal class ApodResponse
    {
        [JsonPropertyName("media_type")]
        public string? MediaType { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("hdurl")]
        public string? HdUrl { get; set; }
    }

    internal class APODConnection
    {
        private const string apiKey = "XSMFNpkPKdhGpbcQ5xofcnkcEqzRFyucZatMjd7k";
        private static readonly HttpClient httpClient = new HttpClient();

        public string GetAPODUrl(DateOnly date)
        {
            string formattedDate = date.ToString("yyyy-MM-dd");
            return $"https://api.nasa.gov/planetary/apod?api_key={apiKey}&date={formattedDate}";
        }

        public async Task<string?> GetImageUrlFromAPOD(DateOnly date)
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
