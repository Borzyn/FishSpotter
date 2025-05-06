using FishSpotter.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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
            string name = mapName.Replace("%20", " ");
            var map = _context.MapModel.Include(m => m.Fishes).Where(m=> m.Name == name).FirstOrDefault();
            if (map == null) return BadRequest();
            // var fishes = map.Fishes.Select(fish => new { fishName = fish.Name }).ToList();
            var fishes = map.Fishes;
            //sprawdzić czy to trzeba na dictionary
           // return  //}));
            var result = new
            {
                map.Name,
                Fish = map.Fishes.Select(m => new
                {
                    m.Name
                }).ToList()
            };
            var res = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> GetPostsMapWithFish([FromBody]string mapName, string fishname)
        {
            string name = mapName.Replace("%20", " ");
            var map = _context.MapModel.FirstOrDefault(x => x.Name == name);
            if (map == null) return BadRequest();
            var fish = _context.FishModel.FirstOrDefault(y => y.Name == fishname);
            if (fish == null) return BadRequest();
            var posts = _context.PostModel.Include(p=> p.Spot).Where(f => f.FishName == fishname).Where(m => m.MapName == name).ToList();
            return Ok(posts);
        }
    }
}
