using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravelPlanner.Models;
using System;

namespace TravelPlanner.Controllers
{
  public class FlightsController : Controller
  {
     private readonly string ApiKey;
     public FlightsController()
     {
      ApiKey = EnvironmentVariables.ApiKey;
     }
    public async Task<IActionResult> Index()
    {
     var flights = await Flight.GetFlights(ApiKey);
     return View(flights);
   }
  }
}
