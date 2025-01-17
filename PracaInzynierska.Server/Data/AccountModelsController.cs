using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FishSpotter.Server.Models.AccountModels;

namespace FishSpotter.Server.Data
{
    public class AccountModelsController : Controller
    {
        private readonly FishSpotterServerContext _context;

        public AccountModelsController(FishSpotterServerContext context)
        {
            _context = context;
        }

        // GET: AccountModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountModel.ToListAsync());
        }

        // GET: AccountModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountModel = await _context.AccountModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountModel == null)
            {
                return NotFound();
            }

            return View(accountModel);
        }

        // GET: AccountModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Score,Posts,Password")] AccountModel accountModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountModel);
        }

        // GET: AccountModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountModel = await _context.AccountModel.FindAsync(id);
            if (accountModel == null)
            {
                return NotFound();
            }
            return View(accountModel);
        }

        // POST: AccountModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Username,Score,Posts,Password")] AccountModel accountModel)
        {
            if (id != accountModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountModelExists(accountModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(accountModel);
        }

        // GET: AccountModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountModel = await _context.AccountModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountModel == null)
            {
                return NotFound();
            }

            return View(accountModel);
        }

        // POST: AccountModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var accountModel = await _context.AccountModel.FindAsync(id);
            if (accountModel != null)
            {
                _context.AccountModel.Remove(accountModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountModelExists(string id)
        {
            return _context.AccountModel.Any(e => e.Id == id);
        }
    }
}
