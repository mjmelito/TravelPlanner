using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelPlanner.Models
{
  public class Destination
  {
    public int DestinationId { get; set; }

    // [Required(ErrorMessage = "Please enter a destination name.")]
    public string DestinationName { get; set; }

    public string City { get; set; }
    public string Country { get; set; }
    
  }
}