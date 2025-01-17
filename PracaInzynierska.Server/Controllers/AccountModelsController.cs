using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FishSpotter.Server.Data;

namespace FishSpotter.Server.Controllers
{
    [ApiController]

    public class AccountModelsController : Controller
    {
        private readonly FishSpotterServerContext _context;

        public AccountModelsController(FishSpotterServerContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Login([Bind("login,password")] string login, string password)
        {
            var account = _context.AccountModel.FirstOrDefault(acc => acc.Username == login);
            if (account == null || account.Password != password) { return BadRequest(); }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> CheckProfile (string user, string accountName)
        {
            var accountToCheck = _context.AccountModel.FirstOrDefault(acc => acc.Username == accountName);
            if (accountToCheck == null || accountName == null) { return BadRequest(); }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> RateProfile(string user, string accountName)
        {
            if (user == null || user == accountName) { return BadRequest(); }
            return Ok();
        }

        public IActionResult ShowPosts (string user, string accountName)
        {
            var accountToCheck = _context.AccountModel.FirstOrDefault(acc => acc.Username == accountName);
            if (accountName == null || accountToCheck == null) { return BadRequest(); }
            return Ok();
        }
    }
}
