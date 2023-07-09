using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

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
    public DateTime Arrival { get; set; }
    public DateTime Departure { get; set; }
    public List<LodgingTrip> LodgingTrips { get; set; }
  }
}