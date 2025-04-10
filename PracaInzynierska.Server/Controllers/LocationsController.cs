using FishSpotter.Server.Data;
using FishSpotter.Server.Models.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace FishSpotter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LocationsController : ControllerBase
    {
        private readonly FishSpotterServerContext _context;
        public LocationsController(FishSpotterServerContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult SelectLocation()
        {
            return Ok();
        }
        


    }
}
