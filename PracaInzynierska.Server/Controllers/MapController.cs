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


        [HttpPost]
        public IActionResult ShowFishOnMap(string mapName) // Do przetestowania relacji nowej
        {
            var map = _context.MapModel.FirstOrDefault(x => x.Name == mapName);
            if (map == null) return BadRequest();
            // var fishes = map.Fishes.Select(fish => new { fishName = fish.Name }).ToList();
            var fishes = map.Fishes;
            //sprawdzić czy to trzeba na dictionary
            return Ok(fishes);
        }

        [HttpPost]
        public IActionResult GetPostsMapWithFish(string mapName, string fishname)
        {
            var map = _context.MapModel.FirstOrDefault(x => x.Name == mapName);
            if (map == null) return BadRequest();
            var fish = _context.FishModel.FirstOrDefault(y => y.Name == fishname);
            if (fish == null) return BadRequest();
            var posts = _context.PostModel.Where(f => f.FishName == fishname).Where(m => m.MapName == mapName).ToList();
            return Ok(posts);
        }
    }
}
