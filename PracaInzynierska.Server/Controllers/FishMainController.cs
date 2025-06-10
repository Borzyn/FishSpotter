using FishSpotter.Server.Data;
using FishSpotter.Server.Migrations;
using FishSpotter.Server.Models.AdditionalModels;
using FishSpotter.Server.Models.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public async Task<IActionResult> ShowFishMain([FromBody] string fishName)
        {


            //var user = _context.AccountModel.Where(x => x.Username == "Admin").FirstOrDefault();
            //user.RatedPosts = new Dictionary<string, string>();
            //var usero = _context.AccountModel.Where(x => x.Username == "test").FirstOrDefault();
            //usero.RatedPosts = new Dictionary<string, string>();
            //_context.AccountModel.Update(user);
            //_context.AccountModel.Update(usero);
            //await _context.SaveChangesAsync();
            //var jazgarz = _context.FishModel.Include(fish => fish.Maps).Where(x => x.Name == "Jazgarz").FirstOrDefault();
            //jazgarz.Maps = new List<MapModel>();
            //jazgarz.Maps.Add(_context.MapModel.Where(y => y.Name == "Jezioro Komarowka").FirstOrDefault());

            //jazgarz.Maps.Add(_context.MapModel.Where(t => t.Name == "Krety Strumyk").FirstOrDefault());
            //jazgarz.Spots.Add(_context.SpotModel.Where(z => z.Id == "1").FirstOrDefault());
            //_context.FishModel.Update(jazgarz);
            ////_context.FishModel.Add(jazgarz);
            //await _context.SaveChangesAsync();
            //splawik 1 , spin 2 , grunt 3
            //var truskawka = _context.GroundbaitModel.Include(x => x.Ingredients).Where( y=> y.GBName == "Karp Truskawka").FirstOrDefault();
            //truskawka.Ingredients.Add(_context.IngredientModel.Where(j => j.Id == "1001").FirstOrDefault());
            //truskawka.Ingredients.Add(_context.IngredientModel.Where(j => j.Id == "3").FirstOrDefault());
            //truskawka.Ingredients.Add(_context.IngredientModel.Where(j => j.Id == "4").FirstOrDefault());
            //truskawka.Ingredients.Add(_context.IngredientModel.Where(j => j.Id == "5").FirstOrDefault());
            //_context.Update(truskawka);



            string fname = fishName.ToLower();
            var fish = _context.FishModel.Include(h=>h.Maps).Where(fish => fish.Name.ToLower() == fname).FirstOrDefault();
            if (fish == null) return BadRequest();
            var maps = fish.Maps;
            if (maps == null) return BadRequest();
            // return Ok(maps.ToJson());
            //return Ok(JsonSerializer.Serialize(maps, new JsonSerializerOptions
            //{
            //    ReferenceHandler = ReferenceHandler.Preserve,
            //    WriteIndented = true
            //}));
            var result = new
            {
                fish.Name,
                Maps = fish.Maps.Select(m => new
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
        public IActionResult ShowPostsWithFishAndMap(FishAndMapModel model )
        {
            var fish = _context.FishModel.FirstOrDefault(f => f.Name == model.fishName);
            var map = _context.MapModel.FirstOrDefault(x => x.Name == model.mapName);
            if (fish == null || map == null) return BadRequest();
            var m= map.Name.ToLower();
            var f = fish.Name.ToLower();
            var posts = _context.PostModel.Where(p => p.FishName.ToLower() == f & p.MapName.ToLower() == m);
            return Ok(posts);
        }

        [HttpGet]
        public IActionResult ShowFishOnMap(string mapName) // Do przetestowania relacji nowej
        {
            string name = mapName.Replace("%20", " ");
            var map = _context.MapModel.Include(x=> x.Fishes).Include(x=> x.Spots).FirstOrDefault(x => x.Name == name);
            if (map == null) return BadRequest();
            // var fishes = map.Fishes.Select(fish => new { fishName = fish.Name }).ToList();
            var fishes = map.Fishes;
            //sprawdzić czy to trzeba na dictionary
            // return Ok(fishes.ToJson());
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
        public IActionResult GetFishName(FishAndMapModel model)
        {
            var map = _context.MapModel.FirstOrDefault(x => x.Name == model.mapName);
            if (map == null) return BadRequest();

            string fish = map.Fishes.FirstOrDefault(f => f.Name == model.fishName).Name;
            if (fish == null) return BadRequest();

            return Ok(fish);
        }


    }
}
