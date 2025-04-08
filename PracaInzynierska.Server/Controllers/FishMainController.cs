using FishSpotter.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FishSpotter.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FishMainController : ControllerBase
    {
        private readonly FishSpotterServerContext _context;

        public FishMainController(FishSpotterServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ShowPostswithFish(string fishName)
        {
            string fname = fishName.ToLower();

            var fish = _context.FishModel.Where(fish => fish.Name.ToLower() == fname).FirstOrDefault();

            if (fish == null) return BadRequest();

            var posts = _context.PostModel.All(p => p.FishName == fname);
            return Ok(posts);
        }

        [HttpGet]
        public IActionResult ShowPostsWithFishAndMap(string fishName, string mapName)
        {
            var fish = _context.FishModel.FirstOrDefault(f => f.Name == fishName);
            var map = _context.MapModel.FirstOrDefault(x => x.Name == mapName);
            if (fish == null || map == null) return BadRequest();
            var m= map.Name.ToLower();
            var f = fish.Name.ToLower();
            var posts = _context.PostModel.All(p => p.FishName.ToLower() == f & p.MapName.ToLower() == m);
            return Ok(posts);
        }

        [HttpGet]
        public IActionResult ShowFishOnMap(string mapName) // Do przetestowania relacji nowej
        {
            var map = _context.MapModel.FirstOrDefault(x => x.Name == mapName);
            if (map == null) return BadRequest();
            // var fishes = map.Fishes.Select(fish => new { fishName = fish.Name }).ToList();
            var fishes = map.Fishes;
            //sprawdzić czy to trzeba na dictionary
            return Ok(fishes);
        }

    }
}
