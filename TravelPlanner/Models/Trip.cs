using System.Collections.Generic;

namespace TravelPlanner.Models
{
    public class Trip
    {
        public int TripId {get; set; }
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
        public int HotelId { get; set; }
        public Lodging Lodging { get; set; }
        public int FlightId { get; set; }
        public Flight Flight {get; set; }
        public int DestinationId {get; set; }
        public Destination Destination {get; set; }
    }
}