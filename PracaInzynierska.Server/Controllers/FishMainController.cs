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

            //FishModel ukleja = new FishModel();
            //ukleja.Name = "Ukleja";

            //FishModel karp = new FishModel();
            //karp.Name = "Karp";

            //FishModel szczupak = new FishModel();
            //szczupak.Name = "szczupak";

            //FishModel sandacz = new FishModel();    
            //sandacz.Name = "sandacz";

            //MapModel komarowka = new MapModel();
            //komarowka.Name = "Jezioro Komarówka";

            //MapModel krety = new MapModel();
            //krety.Name = "Kręty Strumyk";

            //_context.FishModel.Add(ukleja);
            //_context.SaveChanges();


            //var jazgarz = _context.FishModel.Include(fish => fish.Maps).Where(x => x.Name == "Jazgarz").FirstOrDefault();
            //jazgarz.Maps = new List<MapModel>();
            //jazgarz.Maps.Add(_context.MapModel.Where(y => y.Name == "Jezioro Komarowka").FirstOrDefault());

            //jazgarz.Maps.Add(_context.MapModel.Where(t => t.Name == "Krety Strumyk").FirstOrDefault());
            //jazgarz.Spots.Add(_context.SpotModel.Where(z => z.Id == "1").FirstOrDefault());
            //_context.FishModel.Update(jazgarz);
            ////_context.FishModel.Add(jazgarz);
            //await _context.SaveChangesAsync();

            //var truskawka = _context.GroundbaitModel.Include(x => x.Ingredients).Where( y=> y.GBName == "Karp Truskawka").FirstOrDefault();
            //truskawka.Ingredients.Add(_context.IngredientModel.Where(j => j.Id == "1001").FirstOrDefault());
            //truskawka.Ingredients.Add(_context.IngredientModel.Where(j => j.Id == "3").FirstOrDefault());
            //truskawka.Ingredients.Add(_context.IngredientModel.Where(j => j.Id == "4").FirstOrDefault());
            //truskawka.Ingredients.Add(_context.IngredientModel.Where(j => j.Id == "5").FirstOrDefault());
            //_context.Update(truskawka);


            //var u = new PostModel();
            //u.Id = Guid.NewGuid().ToString();
            ////u.UserId = UserID ;
            //u.UserId = "test";
            //u.FishName = "Jazgarz";
            //u.MapName = "Jezioro Komarowka";
            //u.SpotID = "1";
            //u.Spot = _context.SpotModel.Where(i => i.Id == "1").FirstOrDefault();
            //u.MethodName = "Splawik staly";
            //u.Method = _context.MethodModel.Where(i => i.Id == "1").FirstOrDefault();
            //u.BaitId = "2";

            //u.Bait = _context.BaitModel.Where(i => i.Id == "2").FirstOrDefault(); ;
            //u.groundbait = _context.GroundbaitModel.Include(y => y.Ingredients).Where(h => h.GBName == "none").FirstOrDefault();
            //u.groundbaitId = "none";
            //u.rateSum = 0;
            //u.rateAmount = 0;

            //_context.PostModel.Add(u);
            //await _context.SaveChangesAsync();
            //var post = _context.PostModel.Include(f => f.Spot).Include(f =>f.Method).Include(f=>f.Bait).Include(f=>f.groundbait).Where(u => u.UserId == "test").FirstOrDefault();
            ////post.Spot 
            //var user = _context.AccountModel.Include(p => p.Posts).Where(a => a.Username == "test").FirstOrDefault();
            //user.Posts.Add(u);
            //user.PostsCount++;
            //_context.AccountModel.Update(user);

            //await _context.SaveChangesAsync();


            //var foka = _context.FishModel.Include(h => h.Maps).ThenInclude(j => j.Spots).Where(fish => "jazgarz" == fname).FirstOrDefault();


            string fname = fishName.ToLower();

            var fish = _context.FishModel.Include(h=>h.Maps).Where(fish => fish.Name.ToLower() == fname).FirstOrDefault();
            
            if (fish == null) return BadRequest();

            //to do naprawienia żeby dawało mapy dla danej ryby
            var maps = fish.Maps;

            //if (maps == null) return BadRequest();
            //var maps = _context.MapModel.Select(map => map.Name).ToList();
            if (maps == null) return BadRequest();
            return Ok(maps.ToJson());
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
            return Ok(fishes.ToJson);
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
