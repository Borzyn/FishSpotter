using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FishSpotter.Server.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FishSpotter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class AccountModelsController : ControllerBase
    {
        private readonly FishSpotterServerContext _context;

        public AccountModelsController(FishSpotterServerContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Login([Bind("login,password")] string login, string password)
        {
            if (login ==null || password == null) {  return BadRequest(); }
            var account = _context.AccountModel.FirstOrDefault(acc => acc.Username == login);
            if (account == null || account.Password != password) { return BadRequest(); }
            var acc = _context.AccountModel.FirstOrDefault(ac => ac.Username == login);
            return Ok(acc);
        }

        [HttpPost]
        public async Task<IActionResult> CheckProfile (string accountCheckedName)
        {
            var accountToCheck = _context.AccountModel.FirstOrDefault(acc => acc.Username == accountCheckedName);
            if (accountToCheck == null || accountCheckedName == null) { return BadRequest(); }

            return Ok(accountToCheck);
        }


        [HttpPost]
        public async Task<IActionResult> RateProfile(string user, string accountRatedName, string rate)
        {
            if (user == null || user == accountRatedName || accountRatedName==null) { return BadRequest(); }
            int rating;
            if (!int.TryParse(rate, out rating) || rating >5 || rating <1) { return BadRequest(); }
            var account = _context.AccountModel.FirstOrDefault(u => u.Username == accountRatedName);
            if (account == null) { return BadRequest(); }
            account.RateSum += rating;
            account.RateAmount++;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public IActionResult ShowPosts ( string accountName)
        {
            var accountToCheck = _context.AccountModel.FirstOrDefault(acc => acc.Username == accountName);
            if (accountName == null || accountToCheck == null) { return BadRequest(); }

            var posts = _context.PostModel.Where(id => id.UserId == accountName).ToList();
            return Ok(posts);
        }

    }
}
