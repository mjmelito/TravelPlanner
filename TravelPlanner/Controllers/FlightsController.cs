using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelPlanner.Models;

namespace TravelPlanner.Controllers
{
  public class FlightController : Controller
  {
    private readonly HttpClient _httpClient;
    
    public FlightController()
    {
     
    }
  }
}
