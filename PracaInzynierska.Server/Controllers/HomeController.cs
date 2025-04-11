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

        [HttpGet]
        public IActionResult ShowMaps()
        {
            var maps = _context.MapModel.Include(map =>map.Name).ToList();
            if (maps == null) return BadRequest();
            return Ok(maps);
        }

        [HttpGet]
        public IActionResult ShowFishes()
        {
            var fishes = _context.FishModel.Include(f =>f.Name).ToList();
            if (fishes == null) return BadRequest();
            return Ok(fishes);
        }

        //[HttpGet]
        //public IActionResult SearchFish(string fishname)
        //{
        //    return Ok();
        //}

        //[HttpGet]
        //public IActionResult Searchuser(string userName)
        //{
        //    return Ok();
        //}

    }
}
