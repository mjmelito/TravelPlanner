using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace TravelPlanner.Controllers
{
  // [Authorize]
  public class TripsController : Controller
  {
    private readonly TravelPlannerContext _db;

    public TripsController(TravelPlannerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Trip> model = _db.Trips.ToList();
      return View(model);
    }
     public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Trip trip)
    {
      
      _db.Trips.Add(trip);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
     public ActionResult Details(int id)
{
    Trip thisTrip = _db.Trips
                        .Include(trip => trip.LodgingTrips)
                        .ThenInclude(join =>join.Lodging)
                        .Include(trip => trip.TransportationTrips)
                        .ThenInclude(join =>join.Transportation)
                        .Include(trip => trip.DestinationTrips)
                        .ThenInclude(join => join.Destination)
                        
                        .FirstOrDefault(trip => trip.TripId == id);
    
    return View(thisTrip);
}

public ActionResult AddDestination(int id)
{
    Trip thisTrip = _db.Trips.FirstOrDefault(trip => trip.TripId == id);
    ViewBag.DestinationId = new SelectList(_db.Destinations, "DestinationId", "DestinationName");
    return View(thisTrip);
}

[HttpPost]
public ActionResult AddDestination(Trip trip, int DestinationId)
{
    DestinationTrip joinEntity = _db.DestinationTrips
                                .FirstOrDefault(join => join.TripId == trip.TripId && join.DestinationId == DestinationId);

    if (joinEntity == null && trip.TripId != 0)
    {
        _db.DestinationTrips.Add(new DestinationTrip { TripId = trip.TripId, DestinationId = DestinationId });
        _db.SaveChanges();
    }
    
    return RedirectToAction("Details", new { id = trip.TripId });
}
      public ActionResult Edit(int id)
    {
      Trip thisTrip = _db.Trips
                              .Include(trip => trip.DestinationTrips)
                              .ThenInclude(join => join.Destination)
                              .FirstOrDefault(trip => trip.TripId == id);
      return View(thisTrip);
    }

    [HttpPost]
    public ActionResult Edit(Trip trip)
    {
      _db.Trips.Update(trip);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
     public ActionResult Delete(int id)
    {
      Trip thisTrip = _db.Trips.FirstOrDefault(trips => trips.TripId == id);
      return View(thisTrip);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Trip thisTrip = _db.Trips.FirstOrDefault(trips => trips.TripId == id);
      _db.Trips.Remove(thisTrip);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
       [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      DestinationTrip joinEntry = _db.DestinationTrips.FirstOrDefault(entry => entry.Id == joinId);
      _db.DestinationTrips.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
     }
  }