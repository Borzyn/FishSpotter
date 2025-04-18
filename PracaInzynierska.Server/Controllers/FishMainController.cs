using FishSpotter.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public IActionResult ShowPostswithFish(string fishName)
        {
            string fname = fishName.ToLower();

            var fish = _context.FishModel.Where(fish => fish.Name.ToLower() == fname).FirstOrDefault();

            if (fish == null) return BadRequest();

            var posts = _context.PostModel.Where(p => p.FishName == fname).ToList();
            return Ok(posts);
        }

        [HttpPost]
        public IActionResult ShowFishMain([FromBody] string fishName)
        {
            string fname = fishName.ToLower();

            var fish = _context.FishModel.Where(fish => fish.Name.ToLower() == fname).FirstOrDefault();
            
            if (fish == null) return BadRequest();

            var maps = fish.Maps;

            if (maps == null) return BadRequest();

            return Ok(maps);
        }

        //[HttpPost]
        //public IActionResult ShowPostsAmountOnMap(string fishName,string mapName)
        //{
        //    var fish = _context.FishModel.FirstOrDefault(f => f.Name == fishName);
        //    var map = _context.MapModel.FirstOrDefault(x => x.Name == mapName);
        //    if (fish == null || map == null) return BadRequest();
        //    var m = map.Name.ToLower();
        //    var f = fish.Name.ToLower();
        //    var posts = _context.PostModel.Where(p => p.FishName.ToLower() == f & p.MapName.ToLower() == m).Count;
        //    return Ok(posts);

        //}

        [HttpPost]
        public IActionResult ShowPostsWithFishAndMap(string fishName, string mapName)
        {
            var fish = _context.FishModel.FirstOrDefault(f => f.Name == fishName);
            var map = _context.MapModel.FirstOrDefault(x => x.Name == mapName);
            if (fish == null || map == null) return BadRequest();
            var m= map.Name.ToLower();
            var f = fish.Name.ToLower();
            var posts = _context.PostModel.Where(p => p.FishName.ToLower() == f & p.MapName.ToLower() == m);
            return Ok(posts);
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
        public IActionResult GetFishName(string fishName, string mapName)
        {
            var map = _context.MapModel.FirstOrDefault(x => x.Name == mapName);
            if (map == null) return BadRequest();

            string fish = map.Fishes.FirstOrDefault(f => f.Name == fishName).Name;
            if (fish == null) return BadRequest();

            return Ok(fish);
        }


    }
}
