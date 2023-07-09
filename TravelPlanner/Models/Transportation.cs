
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Models
{
  public class Transportation
  {
    public int TransportationId { get; set; }

    // [Required(ErrorMessage = "Please enter transportation name.")]
    public string TransportationName { get; set; }

    public string Mode { get; set; }
    public string Company { get; set; }
    public string DepartureLocation { get; set; }
    public string ArrivalLocation { get; set; }

    public List<TransportationTrip> TransportationTrips { get; set; }
  }
}