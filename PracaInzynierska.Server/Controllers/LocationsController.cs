using FishSpotter.Server.Data;
using FishSpotter.Server.Models.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace FishSpotter.Server.Controllers
{
    [ApiController]
    public class LocationsController : Controller
    {
        private readonly FishSpotterServerContext _context;
        public LocationsController(FishSpotterServerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SelectLocation()
        {
            return Ok();
        }
        


    }
}
