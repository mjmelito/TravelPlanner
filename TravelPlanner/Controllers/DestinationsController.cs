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
  public class DestinationsController : Controller
  {
    private readonly TravelPlannerContext _db;

    public DestinationsController(TravelPlannerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Destination> model = _db.Destinations.ToList();
      return View(model);
    }
     public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Destination destination)
    {
      
      _db.Destinations.Add(destination);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
     public ActionResult Details(int id)
    {
      Destination thisDestination = _db.Destinations
                                  .Include(destination => destination.DestinationTrips)
                                  .ThenInclude(join => join.Trip)
                                  .FirstOrDefault(destination => destination.DestinationId == id);
      return View(thisDestination);
    }
     public ActionResult AddTrip(int id)
    {
      Destination thisDestination = _db.Destinations.FirstOrDefault(destinations => destinations.DestinationId == id);
      ViewBag.TripId = new SelectList(_db.Trips, "TreatId", "Name");
      return View(thisDestination);
    }

    [HttpPost]
    public ActionResult AddTrip(Destination destination, int tripId)
    {
#nullable enable
      DestinationTrip? joinEntity = _db.DestinationTrips.FirstOrDefault(join => (join.TripId == tripId && join.DestinationId == destination.DestinationId));
#nullable disable
      if (joinEntity == null && tripId != 0)
      {
        _db.DestinationTrips.Add(new DestinationTrip() { TripId = tripId, DestinationId = destination.DestinationId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = destination.DestinationId });
    }
      public ActionResult Edit(int id)
    {
      Destination thisDestination = _db.Destinations
                              .Include(destination => destination.DestinationTrips)
                              .ThenInclude(join => join.Trip)
                              .FirstOrDefault(destination => destination.DestinationId == id);
      return View(thisDestination);
    }
    [HttpPost]
    public ActionResult Edit(Destination destination)
    {
      _db.Destinations.Update(destination);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
     public ActionResult Delete(int id)
    {
      Destination thisDestination = _db.Destinations.FirstOrDefault(destinations => destinations.DestinationId == id);
      return View(thisDestination);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Destination thisDestination = _db.Destinations.FirstOrDefault(destinations => destinations.DestinationId == id);
      _db.Destinations.Remove(thisDestination);
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