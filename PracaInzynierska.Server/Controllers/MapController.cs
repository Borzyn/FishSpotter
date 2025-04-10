using FishSpotter.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FishSpotter.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly FishSpotterServerContext _context;

        public MapController(FishSpotterServerContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult showMapMain(string mapName)
        {
            var map = _context.MapModel.FirstOrDefault(x => x.Name == mapName);
            if (map == null) return BadRequest();
            return Ok(map);
        }
    }
}
