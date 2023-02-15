using Microsoft.AspNetCore.Mvc;
using Parcel.Models;

namespace Parcel.Controllers
{
  public class ParcelsController : Controller
  {

    [HttpGet("/parcels/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/parcels")]
    public ActionResult Index(int length, int width, int height, int weight)
    {
      Package newPackage = new Package(length, width, height, weight);
      return View(newPackage);
    }

  }
}