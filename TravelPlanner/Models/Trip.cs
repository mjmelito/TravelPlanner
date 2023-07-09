using System.Collections.Generic;

namespace TravelPlanner.Models
{
    public class Trip
    {
        public int TripId {get; set; }
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
        public Lodging Lodging { get; set; }
        public Transportation Transportation { get; set; }
        public List<DestinationTrip> DestinationTrips { get; set; }
        public List<LodgingTrip> LodgingTrips { get; set; }
        public List<TransportationTrip> TransportationTrips { get; set; }
    }
}