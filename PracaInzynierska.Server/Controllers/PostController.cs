using FishSpotter.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FishSpotter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly FishSpotterServerContext _context;

        public PostController(FishSpotterServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create(string user)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Rate(string user, string postId)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Remove(string user, string postId)
        {
            return Ok();
        }

    }
}
