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

            if (fish == null) return BadRequest("Incorrect fish name");

            var posts = _context.PostModel.Where(p => p.FishName == fname).ToList();
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> ShowFishMain([FromBody] string fishName)
        {
            //var user = _context.AccountModel.Include(x => x.Posts).Where(x => x.Username == "Admin").FirstOrDefault();
            //var post = _context.PostModel.Include(x => x.Spot).Include(x => x.Method).Include(x => x.Bait).Include(x => x.groundbait).Where(x => x.Id == "15ee7ab4-fd36-4104-869f-f83676d21ea2").FirstOrDefault();
            //var posto = _context.PostModel.Include(x => x.Spot).Include(x => x.Method).Include(x => x.Bait).Include(x => x.groundbait).Where(x => x.Id == "db3b1a2a-a6a8-4d88-bad4-cf9011dac033").FirstOrDefault();

            //user.RatedPosts = new Dictionary<string, string>();
            //var usero = _context.AccountModel.Where(x => x.Username == "test").FirstOrDefault();
            //usero.RatedPosts = new Dictionary<string, string>();
            //_context.AccountModel.Update(user);
            //_context.AccountModel.Update(usero);
            //await _context.SaveChangesAsync();
            //var jazgarz = _context.FishModel.Include(fish => fish.Maps).Where(x => x.Name == "Jazgarz").FirstOrDefault();
            //jazgarz.Maps = new List<MapModel>();
            //jazgarz.Maps.Add(_context.MapModel.Where(y => y.Name == "Jezioro Komarowka").FirstOrDefault());
            //var k = _context.MapModel.Include(f => f.Fishes).Where(x => x.Name == "Stary Grod").FirstOrDefault();


            //var amur = _context.FishModel.Include(x => x.Maps).Where(x => x.Name == "Amur").FirstOrDefault();
            //var bolen = _context.FishModel.Include(x => x.Maps).Where(x => x.Name == "Bolen").FirstOrDefault();
            //var brzana = _context.FishModel.Include(x => x.Maps).Where(x => x.Name == "Brzana Pospolita").FirstOrDefault();
            //var certa = _context.FishModel.Include(x => x.Maps).Where(x => x.Name == "Certa").FirstOrDefault();
            //var ciernik = _context.FishModel.Include(x => x.Maps).Where(x => x.Name == "Ciernik").FirstOrDefault();
            //var ciosa = _context.FishModel.Include(x => x.Maps).Where(x => x.Name == "Ciosa").FirstOrDefault();
            //var czeczuga = _context.FishModel.Include(x => x.Maps).Where(x => x.Name == "Czeczuga").FirstOrDefault();
            //var goleca = _context.FishModel.Include(x => x.Maps).Where(x => x.Name == "Golec Arktyczny").FirstOrDefault();
            //var golecc = _context.FishModel.Include(x => x.Maps).Where(x => x.Name == "Golec Czerwony").FirstOrDefault();
            //var golecs = _context.FishModel.Include(x => x.Maps).Where(x => x.Name == "Golec Szary").FirstOrDefault();

            //var jaz = _context.FishModel.Where(x => x.Name == "Jaz").FirstOrDefault();
            //var jazgarz = _context.FishModel.Include(x=> x.Maps).Include(x=> x.Posts).Where(x => x.Name == "Jazgarz").FirstOrDefault();
            //jazgarz.Posts.Add(post);
            //jazgarz.Posts.Add(posto);
            //var jelec = _context.FishModel.Where(x => x.Name == "Jelec").FirstOrDefault();
            //var jesiotr = _context.FishModel.Where(x => x.Name == "Jesiotr Baltycki").FirstOrDefault();
            //var karas = _context.FishModel.Where(x => x.Name == "Karas").FirstOrDefault();
            //var karp = _context.FishModel.Where(x => x.Name == "Karp").FirstOrDefault();
            //var karpg = _context.FishModel.Where(x => x.Name == "Karp Golec").FirstOrDefault();
            //var karpl = _context.FishModel.Where(x => x.Name == "Karp Lustrzen").FirstOrDefault();
            //var kielb = _context.FishModel.Where(x => x.Name == "Kielb").FirstOrDefault();
            //var klen = _context.FishModel.Where(x => x.Name == "Klen").FirstOrDefault();

            //var leszcz = _context.FishModel.Where(x => x.Name == "Leszcz").FirstOrDefault();
            //var lin = _context.FishModel.Where(x => x.Name == "Lin").FirstOrDefault();
            //var lipien = _context.FishModel.Where(x => x.Name == "Lipien").FirstOrDefault();
            //var mietus = _context.FishModel.Where(x => x.Name == "Mietus").FirstOrDefault();
            //var okon = _context.FishModel.Where(x => x.Name == "Okon").FirstOrDefault();
            //var palia = _context.FishModel.Where(x => x.Name == "Palia Jeziorowa").FirstOrDefault();
            //var piskorz = _context.FishModel.Where(x => x.Name == "Piskorz").FirstOrDefault();
            //var ploc = _context.FishModel.Where(x => x.Name == "Ploc").FirstOrDefault();
            //var pstragp = _context.FishModel.Where(x => x.Name == "Pstrag Potokowy").FirstOrDefault();
            //var pstragt = _context.FishModel.Where(x => x.Name == "Pstrag Teczowy").FirstOrDefault();

            //var sandacz = _context.FishModel.Where(x => x.Name == "Sandacz").FirstOrDefault();
            //var sazan = _context.FishModel.Where(x => x.Name == "Sazan").FirstOrDefault();
            //var siejac = _context.FishModel.Where(x => x.Name == "Sieja Czarna").FirstOrDefault();
            //var siejak = _context.FishModel.Where(x => x.Name == "Sieja Kuori").FirstOrDefault();
            //var sielawa = _context.FishModel.Where(x => x.Name == "Sielawa").FirstOrDefault();
            //var sum = _context.FishModel.Where(x => x.Name == "Sum").FirstOrDefault();
            //var szczupak = _context.FishModel.Where(x => x.Name == "Szczupak").FirstOrDefault();
            //var ukleja = _context.FishModel.Where(x => x.Name == "Ukleja").FirstOrDefault();
            //var wegorz = _context.FishModel.Where(x => x.Name == "Wegorz").FirstOrDefault();
            //var wzdrega = _context.FishModel.Where(x => x.Name == "Wzdrega").FirstOrDefault();
            //k.Fishes.Add(amur);
            //k.Fishes.Add(karas);
            //k.Fishes.Add(karp);
            //k.Fishes.Add(klen);
            //k.Fishes.Add(leszcz);

            //k.Fishes.Add(mietus);
            //k.Fishes.Add(lin);
            //k.Fishes.Add(okon);
            //k.Fishes.Add(szczupak);
            //k.Fishes.Add(ukleja);

            //_context.MapModel.Update(k);
            //await _context.SaveChangesAsync();
            var rates = _context.RateModel.Where(x=> x.Id == "111").FirstOrDefault();
        
            //var k = _context.MapModel.Include(f => f.Fishes).Where(x => x.Name == "Jezioro Kuori").FirstOrDefault();
            //var l = _context.MapModel.Include(f => f.Fishes).Where(x => x.Name == "Jezioro Ladoga").FirstOrDefault();
            //var n = _context.MapModel.Include(f => f.Fishes).Where(x => x.Name == "Jezioro Niedzwiedzie").FirstOrDefault();
            //var ks = _context.MapModel.Include(f => f.Fishes).Where(x => x.Name == "Krety Strumyk").FirstOrDefault();
            //var b = _context.MapModel.Include(f => f.Fishes).Where(x => x.Name == "Rzeka Bielaja").FirstOrDefault();
            //var d = _context.MapModel.Include(f => f.Fishes).Where(x => x.Name == "Rzeka Doniec").FirstOrDefault();
            //var su = _context.MapModel.Include(f => f.Fishes).Where(x => x.Name == "Rzeka Sura").FirstOrDefault();
            //var w = _context.MapModel.Include(f => f.Fishes).Where(x => x.Name == "Rzeka Wolchow").FirstOrDefault();
            //var g = _context.MapModel.Include(f => f.Fishes).Include(x=> x.Spots).Where(x => x.Name == "Stary Grod").FirstOrDefault();
            //var x = _context.RateModel.Where(x=> x.Rate < 10).FirstOrDefault();
            //var user = _context.AccountModel.Include(x => x.Posts).ThenInclude(x => x.Spot).Where(x => x.Username == "test").FirstOrDefault();
            //var post = _context.PostModel.Include(x => x.Spot).Where(x => x.Id == "321").FirstOrDefault();
            //var spot = _context.SpotModel.Where(x => x.Id == "10").FirstOrDefault();
            //var method = _context.MethodModel.Where(x => x.Id == "1").FirstOrDefault();
            //var bait = _context.BaitModel.Where(x => x.Id == post.BaitId).FirstOrDefault();
            //post.Spot = spot;
            //post.Method = method;
            //post.Bait = bait;
            //post.groundbait = _context.GroundbaitModel.Where(x => x.GBName == post.groundbaitId).FirstOrDefault();
            //_context.PostModel.Update(post);
            ////_context.AccountModel.Update(user);
            //_context.FishModel.Update(jazgarz);
            //await _context.SaveChangesAsync();

            string fname = fishName.ToLower();
            var fish = _context.FishModel.Include(h=>h.Maps).Where(fish => fish.Name.ToLower() == fname).FirstOrDefault();
            if (fish == null) return BadRequest("Wrong fish name");
            var maps = fish.Maps;
            if (maps == null) return BadRequest("Wrong map");
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


        [HttpPost]
        public IActionResult ShowPostsWithFishAndMap(FishAndMapModel model )
        {
            var fish = _context.FishModel.FirstOrDefault(f => f.Name == model.fishName);
            var map = _context.MapModel.FirstOrDefault(x => x.Name == model.mapName);
            if (fish == null || map == null) return BadRequest("Some data is wrong!");
            var m= map.Name.ToLower();
            var f = fish.Name.ToLower();
            List<PostModel> posts = _context.PostModel.Where(p => p.FishName.ToLower() == f & p.MapName.ToLower() == m).ToList();
            return Ok(posts);
        }

        [HttpGet]
        public IActionResult ShowFishOnMap(string mapName) // Do przetestowania relacji nowej
        {
            string name = mapName.Replace("%20", " ");
            var map = _context.MapModel.Include(x=> x.Fishes).Include(x=> x.Spots).FirstOrDefault(x => x.Name == name);
            if (map == null) return BadRequest( "Incorrect map");
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
            var map = _context.MapModel.Include(x=> x.Fishes).FirstOrDefault(x => x.Name == model.mapName);
            if (map == null) return BadRequest("Incorrect map");

            string fish = map.Fishes.FirstOrDefault(f => f.Name == model.fishName).Name;
            if (fish == null) return BadRequest("Theres no fish like that");

            return Ok(fish);
        }


    }
}
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