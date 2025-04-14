using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FishSpotter.Server.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FishSpotter.Server.Models.AdditionalModels;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using FishSpotter.Server.Models.DataBase;

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


        //rejestracja


        [HttpPost]
        public IActionResult registercontrol(RegisterModel model)
        {
            if (model.Password == null || model.PasswordConfirmed == null || model.Username == null)
            {
                model.ErrorCode = ErrorCode.EmptySpace;
                return BadRequest(model);
            }
            if (model.Username.Length < 4 || model.Username.Length > 22)
            {
                model.ErrorCode = ErrorCode.UsernameWrong;
                return BadRequest(model);
            }
            if (model.Password != model.PasswordConfirmed)
            {
                model.ErrorCode = ErrorCode.PasswordsDifference;
                return BadRequest(model);
            }

            //if (!model.Email.Contains("@"))
            //{
            //    model.ErrorCode = ErrorCode.EmailWrong;
            //    return BadRequest(model);
            //}
            if (model.TermsAccept != true)
            {
                model.ErrorCode = ErrorCode.TermsNotAccepted;
                return BadRequest(model);
            }
            Models.DataBase.AccountModel user = _context.AccountModel.Where(g => g.Username == model.Username).FirstOrDefault();

            if (user != null)
            {
                model.ErrorCode = ErrorCode.UsernameUsed;
                return BadRequest(model);
            }
            //Models.DataBase.AccountModel usere = _context.User.Where(g => g.PhoneNumber == model.PhoneNumber).FirstOrDefault();
            //if (usere != null)
            //{
            //    model.ErrorCode = ErrorCode.PhoneUsed;
            //    return View("/Views/MainPage/MainContent/Register/RegisterPage.cshtml", model);
            //}

            return RedirectToAction("register", "AccountModels", model);

        }

        [HttpPost]
        public IActionResult register (RegisterModel model)
        {
            AccountModel user = new AccountModel();

            user.Username = model.Username;
            user.Password = model.Password;
            user.RateSum = 0;
            user.RateAmount = 0;
            user.PostsCount = 0;
            user.Posts = new List<PostModel>();

            _context.AccountModel.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

    }
}
