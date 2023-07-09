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
  public class TransportationsController : Controller
  {
    private readonly TravelPlannerContext _db;

    public TransportationsController(TravelPlannerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Transportation> model = _db.Transportations.ToList();
      return View(model);
    }
     public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Transportation Transportation)
    {
      
      _db.Transportations.Add(Transportation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
     public ActionResult Details(int id)
    {
      Transportation thisTransportation = _db.Transportations
                                  .Include(Transportation => Transportation.TransportationTrips)
                                  .ThenInclude(join => join.Trip)
                                  .FirstOrDefault(Transportation => Transportation.TransportationId == id);
      return View(thisTransportation);
    }
     public ActionResult AddTrip(int id)
    {
      Transportation thisTransportation = _db.Transportations.FirstOrDefault(Transportations => Transportations.TransportationId == id);
      ViewBag.TripId = new SelectList(_db.Trips, "TripId", "Name");
      return View(thisTransportation);
    }

  [HttpPost]
    public ActionResult AddTrip(Transportation transportation, int tripId)
    {
#nullable enable
      TransportationTrip? joinEntity = _db.TransportationTrips.FirstOrDefault(join => (join.TripId == tripId && join.TransportationId == transportation.TransportationId));
#nullable disable
      if (joinEntity == null && tripId != 0)
      {
        _db.TransportationTrips.Add(new TransportationTrip() { TripId = tripId, TransportationId = transportation.TransportationId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = transportation.TransportationId });
    }
      public ActionResult Edit(int id)
    {
      Transportation thisTransportation = _db.Transportations
                              .Include(Transportation => Transportation.TransportationTrips)
                              .ThenInclude(join => join.Trip)
                              .FirstOrDefault(Transportation => Transportation.TransportationId == id);
      return View(thisTransportation);
    }
    [HttpPost]
    public ActionResult Edit(Transportation Transportation)
    {
      _db.Transportations.Update(Transportation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
     public ActionResult Delete(int id)
    {
      Transportation thisTransportation = _db.Transportations.FirstOrDefault(Transportations => Transportations.TransportationId == id);
      return View(thisTransportation);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Transportation thisTransportation = _db.Transportations.FirstOrDefault(Transportations => Transportations.TransportationId == id);
      _db.Transportations.Remove(thisTransportation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
       [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      TransportationTrip joinEntry = _db.TransportationTrips.FirstOrDefault(entry => entry.Id == joinId);
      _db.TransportationTrips.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
     }
  }