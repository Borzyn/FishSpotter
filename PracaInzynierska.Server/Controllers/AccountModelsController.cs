﻿using System;
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
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model.login == null || model.password == null) { return BadRequest("Not enough login data"); }
            var account = _context.AccountModel.Where(acc => acc.Username == model.login).FirstOrDefault();
            if (account == null || account.Password != model.password) { return BadRequest("Incorrect login or passowrd"); }
            account.Posts= _context.PostModel.Where(p => p.UserId == model.login).ToList();
            //var acc = _context.AccountModel.FirstOrDefault(ac => ac.Username == login);
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CheckProfile([FromBody] string accountCheckedName)
        {
            var accountToCheck = _context.AccountModel.Include(acc=>acc.Posts).ThenInclude(acc =>acc.Spot).FirstOrDefault(acc => acc.Username == accountCheckedName);
            if (accountToCheck == null || accountCheckedName == null) { return BadRequest("Not logged in or wrong account to check"); }

            return Ok(accountToCheck);
        }


        [HttpPost]
        public async Task<IActionResult> RateProfile([FromBody] RateProfileModel model)
        {
            var u = _context.AccountModel.FirstOrDefault(u => u.Username == model.user);
            if (model.user == null || model.user == model.ratedUser || model.ratedUser == null || u ==null) { return BadRequest("Incorrect user"); }
            int rating;
            if (!int.TryParse(model.rate, out rating) || rating > 5 || rating < 1) { return BadRequest("Wrong rate"); }
            var account = _context.AccountModel.Include(acc => acc.Posts).FirstOrDefault(u => u.Username == model.ratedUser);
            if (account == null) { return BadRequest("Something went wrong"); }
            account.RateSum += rating;
            account.RateAmount++;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public IActionResult ShowPosts([FromBody] string accountName)
        {
            if (accountName == null) { return BadRequest("No account name"); }
            var accountToCheck = _context.AccountModel.Include(acc=>acc.Posts).ThenInclude(a=>a.Spot).FirstOrDefault(acc => acc.Username == accountName);
            if ( accountToCheck == null) { return BadRequest("No account to show posts"); }
            return Ok(accountToCheck.Posts);
        }


        //rejestracja


        [HttpPost]
        public IActionResult registerCheck([FromBody] RegisterModel model)
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

            if (model.Password.Length <8 || model.Password.Length >24)
            {
                model.ErrorCode = ErrorCode.PasswordWrong;
                return BadRequest(model);
            }
            if (model.TermsAccept != true)
            {
                model.ErrorCode = ErrorCode.TermsNotAccepted;
                return BadRequest(model);
            }
            Models.DataBase.AccountModel usero = _context.AccountModel.Where(g => g.Username == model.Username).FirstOrDefault();

            if (usero != null)
            {
                model.ErrorCode = ErrorCode.UsernameUsed;
                return BadRequest(model);
            }
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
