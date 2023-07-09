using System.Collections.Generic;

namespace TravelPlanner.Models
{
    public class Trip
    {
        public int TripId {get; set; }
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
        // public int LodgingId { get; set; }
        // public Lodging Lodging { get; set; }
        // public int TransportationId { get; set; }
        // public Transportation Transportation {get; set; }
        public List<DestinationTrip> DestinationTrips { get; set; }
    }
}