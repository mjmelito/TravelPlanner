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
        public static async Task<List<Flight>> GetFlights(string ApiKey)
        {
            List<Flight> flightList = new List<Flight>();

            string result = await ApiHelperFlight.ApiCall(ApiKey);

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(jsonResponse["results"].ToString());

            return flights;
    }
}

}