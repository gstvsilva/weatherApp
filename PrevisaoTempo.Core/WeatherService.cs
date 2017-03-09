using System;

using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Collections.Generic;

namespace PrevisaoTempo.Core
{
    public class CityWeather
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("temperature")]
        public string Temperature { get; set; }

        [JsonProperty("skytext")]
        public string Skytext { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        [JsonProperty("wind")]
        public string Wind { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("day")]
        public string Day { get; set; }
    }
    

    public class WeatherService
	{
        HttpClient httpClient;

        public WeatherService(){
            httpClient = new HttpClient();
        }

        public async Task<CityWeather> GetDataCity(string city) {
            var jsonResponse = await httpClient.GetStringAsync("http://weathers.co/api.php?city="+city);
            var parsedJson = JObject.Parse(jsonResponse)["data"].ToObject<CityWeather>();

            return parsedJson;
        }
	}

}
