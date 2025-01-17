using FishSpotter.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FishSpotter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishMainController : ControllerBase
    {
        private readonly FishSpotterServerContext _context;

        public FishMainController(FishSpotterServerContext context)
        {
            _context = context;
        }

        public IActionResult ShowPosts(string fishName)
        {
            var fish = _context.FishModel.FirstOrDefault(f => f.Name == fishName);
            if (fish == null) return BadRequest();
            return Ok();
        }

        public IActionResult ShowPostsWithMap(string fishName, string mapName)
        {
            var fish = _context.FishModel.FirstOrDefault(f => f.Name == fishName);
            var map = _context.MapModel.FirstOrDefault(x => x.Name == mapName);
            if (fish == null || map == null) return BadRequest();
            return Ok();
        }
    }
}
