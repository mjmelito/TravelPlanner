using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TravelPlanner.Models;
using TravelPlanner.ViewModels;

namespace TravelPlanner.Controllers
{
  public class HomeController : Controller
  {
    private readonly TravelPlannerContext _db;

    public HomeController(TravelPlannerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {

    var viewModel = new LoginViewModel();
    return View(viewModel);
    }
  }
}