using FishSpotter.Server.Data;
using FishSpotter.Server.Models.AdditionalModels;
using FishSpotter.Server.Models.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var editor = _context.AccountModel.Include(x=> x.Posts).Where(u=> u.Username == model.user).FirstOrDefault();
            if (model.user == null || editor == null) { return BadRequest(); }

            //    public IActionResult Create(string fishname, string mapname, string xyname, string addInfo,string methodname,string groundbaitid)
            //{
            //    string UserID = Request.Cookies["Username"];
            //    if (UserID == null || UserID == "0") { return BadRequest() ; }


            var fish = _context.FishModel.FirstOrDefault(f => f.Name == model.fishname);
            if (fish == null) { return BadRequest(); }

            //DO przetestowania TODO
            //var map = _context.MapModel.FirstOrDefault(m => m.Name == mapname && m.Fishes.Contains(fishname));
            var IsMapValid = _context.MapModel.Any(map => map.Name == model.mapname && map.Fishes.Any(fish => fish.Name == model.fishname));
            if (!IsMapValid) { return BadRequest(); }

            //string info;
            //if (!int.TryParse(model.addInfo, out info)) { return BadRequest(); }
            //////var spot = _context.SpotModel.FirstOrDefault(s => s.Map == model.mapname && s.XY == model.xyname && s.AdditionalInfo == model.addInfo);
            //////if (spot == null)
            //////{
            //////    spot = new SpotModel();
            //////    spot.Id = Guid.NewGuid().ToString();
            //////    //spot.XY = model.xyname;
            //////    spot.AdditionalInfo = model.addInfo;
            //////    //spot.Map = model.mapname;
            //////}

            var method = _context.MethodModel.FirstOrDefault(met => met.Name == model.methodname);
            if (method == null) { return BadRequest(); }

            var bait = _context.BaitModel.FirstOrDefault(b => b.Name == model.methodname);
            if (bait == null || !bait.Methods.Contains(method)) { return BadRequest(); }

            var groundbait = _context.GroundbaitModel.FirstOrDefault(g => g.GBName == model.groundbaitid);
            //if (  groundbait != null! && !groundbait.Methods.Contains(method)) { return BadRequest(); }
            if (groundbait == null) { groundbait = _context.GroundbaitModel.Where(h => h.GBName == "none").FirstOrDefault(); }



            var u = new PostModel();
            u.Id = Guid.NewGuid().ToString();
            //u.UserId = UserID ;
            u.UserId = model.user;
            u.FishName = model.fishname;
            u.MapName = model.mapname;
            //u.Spot = spot;
            u.Method = method;
            u.BaitId = bait.Id;
            u.Bait = bait;
            u.groundbaitId = groundbait.GBName;
            u.groundbait = groundbait;

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

        //public IActionResult Rate(string postId, int rate)
        //{
        //    string UserID = Request.Cookies["Username"];
        //    if (UserID == null || UserID == "0") { return BadRequest(); }
        //    if (rate >5 || rate<1) { return BadRequest(); }

        //    var validUser = _context.AccountModel.FirstOrDefault(u => u.Username == UserID);
        //    if (validUser == null) { return BadRequest(); }

        //    var post = _context.PostModel.FirstOrDefault(x => x.Id == postId);
        //    if (post == null || post.UserId == UserID) { return BadRequest(); }
        //    post.rateSum += rate;
        //    post.rateAmount++;

        //    _context.SaveChanges();

        //    return Ok();
        //}
        public IActionResult Rate([FromBody] RatePostModel model)
        {
            if (model.rate > 5 || model.rate < 1) { return BadRequest(); }

            var validUser = _context.AccountModel.FirstOrDefault(u => u.Username == model.user);
            if (validUser == null) { return BadRequest(); }

            var post = _context.PostModel.FirstOrDefault(x => x.Id == model.postId);
            if (post == null || post.UserId == model.user) { return BadRequest(); }
            post.rateSum += model.rate;
            post.rateAmount++;

            _context.SaveChanges();

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

        //[HttpPost]
        //public IActionResult Remove( string postId)
        //{
        //    string UserID = Request.Cookies["Username"];
        //    if (UserID == null || UserID == "0") { return BadRequest(); }
        //    var post = _context.PostModel.FirstOrDefault(x => x.Id == postId);
        //    if (post == null) { return BadRequest(); }
        //    if (post.UserId != UserID) { return BadRequest(); }
        //    var correctuser = _context.AccountModel.Where(x => x.Username == UserID).FirstOrDefault();
        //    correctuser.Posts.Remove(post);
        //    _context.PostModel.Remove(post);
        //    _context.SaveChanges();    
        //    return Ok();
        //}

    }
}
