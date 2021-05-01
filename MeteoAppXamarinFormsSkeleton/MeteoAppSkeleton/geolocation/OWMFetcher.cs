using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MeteoAppSkeleton.geolocation
{
    class OWMFetcher
    {
        private static string KEY = "2ce39100e5b965b227777e0715587cff";

        public static async Task<string> GetLocationFromCoordinates(double lat, double lon)
        {
            Uri uri = new Uri("https://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lon + "&units=metric&lang=it&appid=" + KEY);
            
            var httpClient = new HttpClient();
            return await httpClient.GetStringAsync(uri);

        }

    }
}
