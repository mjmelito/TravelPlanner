namespace TravelPlanner.Models
{
  public class DestinationTrip
    {       
        public int DestinationTripId { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}