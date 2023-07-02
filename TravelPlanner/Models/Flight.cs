using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;

namespace TravelPlanner.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Name { get; set; }
        public static List<Flight> GetFlights(string apiKey)
    {
      Task<string> apiCallTask = ApiHelperFlight.ApiCall(apiKey);
      string result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Flight> flightList = JsonConvert.DeserializeObject<List<Flight>>(jsonResponse["results"].ToString());

      return flightList;
    }
    }
}