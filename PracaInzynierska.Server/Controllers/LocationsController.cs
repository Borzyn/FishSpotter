using Microsoft.AspNetCore.Mvc;

namespace FishSpotter.Server.Controllers
{
    public class LocationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetLocationsForFish(string fish)
        {
            string[] locations = null;

            //
            return View();
        }
    }
}
