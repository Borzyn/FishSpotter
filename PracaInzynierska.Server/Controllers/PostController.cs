using FishSpotter.Server.Data;
using FishSpotter.Server.Migrations;
using FishSpotter.Server.Models.AdditionalModels;
using FishSpotter.Server.Models.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
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

            var fish = _context.FishModel.Include(f=> f.Posts).FirstOrDefault(f => f.Name.ToLower() == model.fishname.ToLower());
            if (fish == null) { return BadRequest(); }

            //DO przetestowania TODO
            //var map = _context.MapModel.FirstOrDefault(m => m.Name == mapname && m.Fishes.Contains(fishname));
            //var IsMapValid = _context.MapModel.FirstOrDefault(m=>m.Name.ToLower() == model.mapname.ToLower());
            var IsMapValid = _context.MapModel.Include(map => map.Fishes).Any(map => map.Name == model.mapname && map.Fishes.Any(fish => fish.Name == model.fishname));
            if (IsMapValid == false) { return BadRequest(); }

            var spotCheck = _context.SpotModel.Where(spot => spot.Map.ToLower() == model.mapname.ToLower() && spot.Id.ToLower() == model.spotID.ToLower()).FirstOrDefault();
            if (spotCheck == null) { return BadRequest(); }

            //var method = _context.MethodModel.FirstOrDefault(met => met.Name == model.methodname);
            //if (method == null) { return BadRequest(); }

            var bait = _context.BaitModel.FirstOrDefault(b => b.Name.ToLower() == model.baitname.ToLower());
            if (bait == null ) { return BadRequest(); }
            //var groundbait = _context.GroundbaitModel.FirstOrDefault(g => g.GBName.ToLower() == model.groundbaitid.ToLower());
            //if (groundbait == null) { groundbait = _context.GroundbaitModel.Where(h => h.GBName == "none").FirstOrDefault(); }
            


            var u = new PostModel();
            u.Id = Guid.NewGuid().ToString();
            u.UserId = model.user;
            u.FishName = model.fishname;
            u.MapName = model.mapname;
            //u.Method = method;
            //u.MethodName = method.Name;
            //u.BaitId = bait.Id;
            //u.Bait = bait;
            //    u.groundbaitId = groundbait.GBName;
            //u.groundbait = groundbait;
            u.SpotID = spotCheck.Id; ;
            u.Spot = spotCheck;
                u.AdditionalInfo = model.addInfo;
            u.rateSum = 0;
            u.rateAmount = 0;
            _context.PostModel.Add(u);

            fish.Posts.Add(u);
           
            //_context.SaveChanges();
            editor.PostsCount++;
            editor.Posts.Add(u);
            _context.AccountModel.Update(editor);
            _context.SaveChanges();
            return Ok(u);
        }
        //po co to?
       [HttpGet]
        public IActionResult RateCheck(string PostID, string username)
        {
            var rate = _context.RateModel.FirstOrDefault(x => x.Username == username && x.PostId == PostID);
            if (rate == null)
                return NotFound(new { message = "Rate not found" });
            
            return Ok(new { rate = rate.Rate });
        }

        [HttpPost]
        public async Task<IActionResult> Rate([FromBody] RatePostModel model)
        {
            if (model.rate > 5 || model.rate < 1) { return BadRequest("Wrong rate"); }

            var validUser = _context.AccountModel.FirstOrDefault(u => u.Username == model.user);
            if (validUser == null) { return BadRequest("Invalid user"); }

            var post = _context.PostModel.FirstOrDefault(x => x.Id == model.postId);
            if (post == null || post.UserId == model.user) { return BadRequest("Invalid post"); }
            var author = _context.AccountModel.Where(p => p.Username == post.UserId).FirstOrDefault();
            var ratemodel = _context.RateModel.Where(r => r.Username == model.user && r.PostId == post.Id).FirstOrDefault();
            if (ratemodel != null)
            {
                author.RateSum -= ratemodel.Rate;
                post.rateSum -= ratemodel.Rate;
                ratemodel.Rate = model.rate;
                _context.RateModel.Update(ratemodel);
            }
            else
            {
                post.rateAmount++;
                author.RateAmount++;
                ratemodel = new RateModel();
                ratemodel.PostId = post.Id;
                ratemodel.Username = model.user;
                ratemodel.Id = Guid.NewGuid().ToString();
                ratemodel.Rate = model.rate;

                _context.RateModel.Add(ratemodel);
            }
            author.RateSum += ratemodel.Rate;
            post.rateSum += ratemodel.Rate;

            _context.Update(author);
            _context.Update(post);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Post rated successfully" });
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

        [HttpGet]
        public IActionResult StartCreatingPost()
        {
            var maps = _context.MapModel.Include(m=>m.Spots).ToList();
            //var methods = _context.MethodModel.ToList();
            var result = new
            {
                maps,
               // methods
            };
            return Ok(result.ToJson());
        }
    }
}
