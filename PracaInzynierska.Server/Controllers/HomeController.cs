using FishSpotter.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult login(string userId)
        {
                return Ok(userId);
        }

        [HttpGet]
        public IActionResult ShowMaps()
        {
            return Ok();
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
