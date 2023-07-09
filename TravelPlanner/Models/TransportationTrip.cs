using System.Collections.Generic;
namespace TravelPlanner.Models
{
  public class TransportationTrip
    {       
        public int Id { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int TransportationId { get; set; }
        public Transportation Transportation { get; set; }
        public List<TransportationTrip> TransportationTrips { get; set; }
  }
}