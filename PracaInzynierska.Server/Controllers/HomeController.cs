using FishSpotter.Server.Data;
using FishSpotter.Server.Models.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace FishSpotter.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly FishSpotterServerContext _context;

        public HomeController(FishSpotterServerContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult login(string userId)
        {
            return Ok(userId);
        }
        [HttpPost]
        public IActionResult logout(string userid)
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult ShowMaps()
        {
            var maps = _context.MapModel.Select(map => map.Name).ToList();
            if (maps == null) return BadRequest();
            return Ok(maps);
        }

        [HttpGet]
        public IActionResult ShowFishes()
        {
            var fishes = _context.FishModel.Select(fish => fish.Name).ToList();
            if (fishes == null) return BadRequest();
            return Ok(fishes);
        }

        [HttpPost]
        public IActionResult SearchFish(string fishname)
        {
            var fish = _context.FishModel.Where(fishh => fishh.Name == fishname).FirstOrDefault();
            if (fish == null) return BadRequest();
            return Ok(fish);
        }

        [HttpPost]
        public IActionResult Searchuser(string userName)
        {
            var user = _context.AccountModel.Where(usero => usero.Username == userName).FirstOrDefault();
            if  (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

    }
}
