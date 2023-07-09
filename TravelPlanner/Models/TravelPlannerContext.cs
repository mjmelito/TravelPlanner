using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TravelPlanner.Models 
{
    public class TravelPlannerContext : IdentityDbContext<ApplicationUser>
    {
    public DbSet<Trip> Trips { get; set;}
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Lodging> Lodgings { get; set; }
    public DbSet<Itinerary> Itineraries { get; set; }
    public DbSet<DestinationTrip> DestinationTrips { get; set; }
    public DbSet<LodgingTrip> LodgingTrips { get; set; }
    public TravelPlannerContext(DbContextOptions options) : base(options) { }
    }
}