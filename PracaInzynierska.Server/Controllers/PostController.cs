using FishSpotter.Server.Data;
using FishSpotter.Server.Migrations;
using FishSpotter.Server.Models.AdditionalModels;
using FishSpotter.Server.Models.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Text.Json;

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

        public IActionResult Create([FromBody] CreatePostModel model)
        {
            var editor = _context.AccountModel.Include(x => x.Posts).Where(u => u.Username == model.user).FirstOrDefault();
            if (model.user == null || editor == null) { return BadRequest(); }

            var fish = _context.FishModel.FirstOrDefault(f => f.Name == model.fishname);
            if (fish == null) { return BadRequest(); }

            //DO przetestowania TODO
            //var map = _context.MapModel.FirstOrDefault(m => m.Name == mapname && m.Fishes.Contains(fishname));
            var IsMapValid = _context.MapModel.Include(map => map.Fishes).Any(map => map.Name == model.mapname && map.Fishes.Any(fish => fish.Name == model.fishname));
            if (IsMapValid == null) { return BadRequest(); }

            var spotCheck = _context.SpotModel.Include(x => x.Map).Where(spot => spot.Map == model.mapname && spot.XY == model.spotXY).FirstOrDefault();
            if (spotCheck == null) { return BadRequest(); }

            var method = _context.MethodModel.FirstOrDefault(met => met.Name == model.methodname);
            if (method == null) { return BadRequest(); }

            var bait = _context.BaitModel.FirstOrDefault(b => b.Name == model.methodname);
            if (bait == null || !bait.Methods.Contains(method)) { return BadRequest(); }

            var groundbait = _context.GroundbaitModel.FirstOrDefault(g => g.GBName == model.groundbaitid);
            if (groundbait == null) { groundbait = _context.GroundbaitModel.Where(h => h.GBName == "none").FirstOrDefault(); }



            var u = new PostModel();
            u.Id = Guid.NewGuid().ToString();
            u.UserId = model.user;
            u.FishName = model.fishname;
            u.MapName = model.mapname;
            u.Method = method;
            u.BaitId = bait.Id;
            u.Bait = bait;
            u.groundbaitId = groundbait.GBName;
            u.groundbait = groundbait;
            u.SpotID = spotCheck.Id; ;
            u.Spot = spotCheck;
            u.AdditionalInfo = model.addInfo;

            u.rateSum = 0;
            u.rateAmount = 0;
            _context.PostModel.Add(u);

            _context.SaveChangesAsync();
            editor.PostsCount++;
            editor.Posts.Add(u);
            _context.AccountModel.Update(editor);
            _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public IActionResult Rate([FromBody] RatePostModel model)
        {
           
            if (model.rate > 5 || model.rate < 1) { return BadRequest(); }

            var validUser = _context.AccountModel.FirstOrDefault(u => u.Username == model.user);
            if (validUser == null) { return BadRequest(); }

            var post = _context.PostModel.FirstOrDefault(x => x.Id == model.postId);
            if (post == null || post.UserId == model.user) { return BadRequest(); }
            var author = _context.AccountModel.Where(p => p.Username == post.UserId).FirstOrDefault();
            var ratemodel = _context.RateModel.Where(r => r.Username == model.user && r.PostId == post.Id).FirstOrDefault();
            if (ratemodel != null)
            {
                author.RateSum -= ratemodel.Rate;
                post.rateSum -= ratemodel.Rate;
            }
            else
            {
                post.rateAmount++;
                author.RateAmount++;
                ratemodel = new RateModel();
                ratemodel.PostId = post.Id;
                ratemodel.Username = model.user;
                ratemodel.Id = Guid.NewGuid().ToString();
            }
            ratemodel.Rate = model.rate;
            author.RateSum += ratemodel.Rate;
            post.rateSum += ratemodel.Rate;
            _context.Update(ratemodel);
            _context.Update(author);
            _context.Update(post);
            _context.SaveChangesAsync();


            return Ok();
        }

        [HttpPost]
        public IActionResult Remove(string user, string postId)
        {
            var post = _context.PostModel.FirstOrDefault(x => x.Id == postId);
            if (post == null) { return BadRequest(); }
            var correctuser = _context.AccountModel.FirstOrDefault(y => y.Username == post.UserId);
            if (correctuser == null || user != correctuser.Username) { return BadRequest(); }
            _context.PostModel.Remove(post);
            correctuser.PostsCount--;
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult StartCreatingPost()
        {
            var maps = _context.MapModel.Include(m=>m.Spots).ToList();
            var methods = _context.MethodModel.ToList();
            var result = new
            {
                maps,
                methods
            };
            return Ok(result.ToJson());
        }
    }
}
