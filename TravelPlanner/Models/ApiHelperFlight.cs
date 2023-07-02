using System.Threading.Tasks;
using RestSharp;

namespace TravelPlanner.Models
{
  class ApiHelperFlight
  {
    public static async Task<string> ApiCall(string apiKey)
    {
      RestClient client = new RestClient("https://tripadvisor16.p.rapidapi.com/api/v1/flights/searchAirport?query=london");
      RestRequest request = new RestRequest(Method.GET);
      request.AddHeader("X-RapidAPI-Key", apiKey);
      request.AddHeader("X-RapidAPI-Host", "tripadvisor16.p.rapidapi.com");
      IRestResponse response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}

// var client = new RestClient("https://tripadvisor16.p.rapidapi.com/api/v1/flights/searchFlights?sourceAirportCode=BOM&destinationAirportCode=DEL&date=%3CREQUIRED%3E&itineraryType=%3CREQUIRED%3E&sortOrder=%3CREQUIRED%3E&numAdults=1&numSeniors=0&classOfService=%3CREQUIRED%3E&pageNumber=1&currencyCode=USD");
// var request = new RestRequest(Method.GET);
// request.AddHeader("X-RapidAPI-Key", "SIGN-UP-FOR-KEY");
// request.AddHeader("X-RapidAPI-Host", "tripadvisor16.p.rapidapi.com");
// IRestResponse response = client.Execute(request);