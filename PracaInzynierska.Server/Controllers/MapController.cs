using FishSpotter.Server.Data;
using FishSpotter.Server.Models.AdditionalModels;
using FishSpotter.Server.Models.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Diagnostics;
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
           
            var map = _context.MapModel.Include(x=>x.Spots).FirstOrDefault(x => x.Name == mapName);
            if (map == null) return BadRequest("Incorrect map");
            return Ok(map);
        }


        [HttpPost]
        public IActionResult ShowFishOnMap(string mapName) // Do przetestowania relacji nowej
        {
            
            string name = mapName.Replace("%20", " ");
            var map = _context.MapModel.Include(m => m.Fishes).ThenInclude(m=>m.Posts).Where(m=> m.Name == name).FirstOrDefault();
            if (map == null) return BadRequest("Incorrect map");
            var fishes = map.Fishes;
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

        //to jest to na co przekierowuje z ekranu głównego po wybraniu mapy
        [HttpGet]
        public async  Task<IActionResult> GetPostsMapWithFish([FromQuery] string fishName, [FromQuery] string mapName)
        {
            string name = mapName.Replace("%20", " ");

            //if (!_context.MapModel.Any(y => y.Name == name)) return BadRequest("Map not found");
            //if (!_context.FishModel.Any(y => y.Name == fishName)) return BadRequest("Fish not found "+ fishName);

            var posts = await _context.PostModel
                .Include(p => p.Spot)
                .Include(p => p.Bait)
                //.Include(p => p.groundbait)
                //.Include(p => p.Method)
                .Where(f => f.FishName == fishName && f.MapName == name).Take(1)
                .ToListAsync();
            Debug.WriteLine(fishName);
            return Ok(posts);
        }
        
        class Point
        {
            public string x, y;
            public Point(string a, string b)
            {
                x = a;
                y = b;
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetPointsOnMap([FromQuery] string mapName)
        {

            var map = _context.MapModel.Include(x=> x.Spots).FirstOrDefault(p => p.Name == mapName);
            if (map == null) return BadRequest("Wrong map name");
            var spots = map.Spots.ToArray();
            string help;
            string[] strings;
            Point[] points = new Point[spots.Length];
            for (int i = 0; i < spots.Length; i++)
            {
                help = spots[i].XY;
                strings = help.Split(":");
                points[i] = new Point(strings[0], strings[1]);
            }
            return Ok(points.ToJson());
        }
    }
}
