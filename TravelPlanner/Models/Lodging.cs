using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Models
{
  public class Lodging
  {
    public int LodgingId { get; set; }

    // [Required(ErrorMessage = "Please enter a lodging name.")]
    public string LodgingName { get; set; }
    public string LodgingType { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public List<LodgingTrip> LodgingTrips { get; set; }
  }
}