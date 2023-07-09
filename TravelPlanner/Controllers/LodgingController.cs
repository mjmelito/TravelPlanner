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
  public class LodgingsController : Controller
  {
    private readonly TravelPlannerContext _db;

    public LodgingsController(TravelPlannerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Lodging> model = _db.Lodgings.ToList();
      return View(model);
    }
     public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Lodging Lodging)
    {
      
      _db.Lodgings.Add(Lodging);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
     public ActionResult Details(int id)
    {
      Lodging thisLodging = _db.Lodgings
                                  .Include(Lodging => Lodging.LodgingTrips)
                                  .ThenInclude(join => join.Trip)
                                  .FirstOrDefault(Lodging => Lodging.LodgingId == id);
      return View(thisLodging);
    }
     public ActionResult AddTrip(int id)
    {
      Lodging thisLodging = _db.Lodgings.FirstOrDefault(Lodgings => Lodgings.LodgingId == id);
      ViewBag.TripId = new SelectList(_db.Trips, "TripId", "Name");
      return View(thisLodging);
    }

    [HttpPost]
    public ActionResult AddTrip(Lodging Lodging, int tripId)
    {
#nullable enable
      LodgingTrip? joinEntity = _db.LodgingTrips.FirstOrDefault(join => (join.TripId == tripId && join.LodgingId == Lodging.LodgingId));
#nullable disable
      if (joinEntity == null && tripId != 0)
      {
        _db.LodgingTrips.Add(new LodgingTrip() { TripId = tripId, LodgingId = Lodging.LodgingId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = Lodging.LodgingId });
    }
      public ActionResult Edit(int id)
    {
      Lodging thisLodging = _db.Lodgings
                              .Include(Lodging => Lodging.LodgingTrips)
                              .ThenInclude(join => join.Trip)
                              .FirstOrDefault(Lodging => Lodging.LodgingId == id);
      return View(thisLodging);
    }
    [HttpPost]
    public ActionResult Edit(Lodging Lodging)
    {
      _db.Lodgings.Update(Lodging);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
     public ActionResult Delete(int id)
    {
      Lodging thisLodging = _db.Lodgings.FirstOrDefault(Lodgings => Lodgings.LodgingId == id);
      return View(thisLodging);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Lodging thisLodging = _db.Lodgings.FirstOrDefault(Lodgings => Lodgings.LodgingId == id);
      _db.Lodgings.Remove(thisLodging);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
       [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      LodgingTrip joinEntry = _db.LodgingTrips.FirstOrDefault(entry => entry.Id == joinId);
      _db.LodgingTrips.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
     }
  }