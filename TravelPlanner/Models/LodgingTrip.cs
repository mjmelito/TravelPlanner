using System.Collections.Generic;
namespace TravelPlanner.Models
{
  public class LodgingTrip
    {       
        public int Id { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int LodgingId { get; set; }
        public Lodging Lodging { get; set; }
        public List<LodgingTrip> LodgingTrips { get; set; }
  }
}