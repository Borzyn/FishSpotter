using FishSpotter.Server.Data;
using FishSpotter.Server.Models.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FishSpotter.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly FishSpotterServerContext _context;

        public PostController(FishSpotterServerContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(string user, string fishname, string mapname, string xyname, string addInfo,string methodname,string groundbaitid)
        {
            var editor = _context.AccountModel.FirstOrDefault(x => x.Username == user);
            if (user == null || editor == null) { return BadRequest(); }


            var fish = _context.FishModel.FirstOrDefault(f => f.Name == fishname);
            if (fish == null) { return BadRequest(); }

            //DO przetestowania TODO
            //var map = _context.MapModel.FirstOrDefault(m => m.Name == mapname && m.Fishes.Contains(fishname));
            var IsMapValid = _context.MapModel.Any(map =>  map.Name == mapname && map.Fishes.Any(fish => fish.Name == fishname));
            if (!IsMapValid) {return BadRequest(); }

            int info;
            if (!int.TryParse(addInfo, out info)) { return BadRequest(); }
            var spot = _context.SpotModel.FirstOrDefault(s => s.Map == mapname &&  s.XY == xyname && s.AdditionalInfo == info);
            if (spot == null) 
            {
                spot = new SpotModel();
                spot.Id = Guid.NewGuid().ToString();
                spot.XY = xyname;
                spot.AdditionalInfo = info;
                spot.Map = mapname;  
            }

            var method = _context.MethodModel.FirstOrDefault(met => met.Name == methodname);
            if (method == null) { return BadRequest(); }

            var bait = _context.BaitModel.FirstOrDefault(b => b.Name == methodname);
            if (bait == null || !bait.Methods.Contains(method)) { return BadRequest(); }

            var groundbait = _context.GroundbaitModel.FirstOrDefault(g => g.Id == groundbaitid);
            if (  groundbait != null! && !groundbait.Methods.Contains(method)) { return BadRequest(); }



            var u = new PostModel();
            u.Id = Guid.NewGuid().ToString();
            u.UserId = user;
            u.FishName = fishname;
            u.MapName = mapname;
            u.Spot = spot;
            u.Method = method;
            u.BaitId = bait.Id;
            u.Bait = bait;
            if (groundbait != null)
            {
                u.groundbaitId = groundbait.Id;
                u.groundbait = groundbait;
            }
            u.rateSum = 0;
            u.rateAmount = 0;

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult Rate(string user, string postId, int rate)
        {
            if (rate >5 || rate<1) { return BadRequest(); }

            var validUser = _context.AccountModel.FirstOrDefault(u => u.Username == user);
            if (validUser == null) { return BadRequest(); }

            var post = _context.PostModel.FirstOrDefault(x => x.Id == postId);
            if (post == null || post.UserId == user) { return BadRequest(); }
            post.rateSum += rate;
            post.rateAmount++;

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult Remove(string user, string postId)
        {
            var post = _context.PostModel.FirstOrDefault(x => x.Id == postId);
            if (post == null) { return BadRequest(); }
            var correctuser = _context.AccountModel.FirstOrDefault(y=> y.Username == post.UserId);
            if(correctuser == null || user != correctuser.Username) { return BadRequest(); }
            _context.PostModel.Remove(post);
            correctuser.PostsCount--;
            _context.SaveChanges();    
            return Ok();
        }

    }
}
