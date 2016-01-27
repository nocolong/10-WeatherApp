using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Domain;

namespace WeatherApp.Core.Services
{
    public class WeatherService

    {
        //Storing API key into a string variable
        private static string apiKey = "26f28af21b4c34b0";

        public static ConditionsResult GetWeatherFor(string zipCode)
        {
            //WebClient class is a built in class to get data from a url
            //"using" terminates use of WebClient after this one block runs
            using (WebClient wc = new WebClient())
            {

                //Downloads the URL as a string, and stores into string json
                string json = wc.DownloadString($"http://api.wunderground.com/api/{apiKey}/conditions/q/CA/{zipCode}.json");

                //Search for json documentation to understand JObject
                var o = JObject.Parse(json);

                //Extracts the "current_observation" part of the json data, and stores it into currentObservationJson
                string currentObservationJson = o["current_observation"].ToString();

                //Research Json deserialize..
                var result = JsonConvert.DeserializeObject<ConditionsResult>(currentObservationJson);

                return result;

            }
        }
    }
}
