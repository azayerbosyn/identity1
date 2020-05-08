using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using identity1.Data;
using identity1.Models;

namespace identity1.Controllers
{
    public class CommandersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommandersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Commanders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Commander.ToListAsync());
        }

        // GET: Commanders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commander = await _context.Commander
                .FirstOrDefaultAsync(m => m.CommanderId == id);
            if (commander == null)
            {
                return NotFound();
            }

            return View(commander);
        }

        // GET: Commanders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Commanders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommanderId,CommanderLogin,CommanderPass")] Commander commander)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commander);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commander);
        }

        // GET: Commanders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commander = await _context.Commander.FindAsync(id);
            if (commander == null)
            {
                return NotFound();
            }
            return View(commander);
        }

        // POST: Commanders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommanderId,CommanderLogin,CommanderPass")] Commander commander)
        {
            if (id != commander.CommanderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commander);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommanderExists(commander.CommanderId))
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
            return View(commander);
        }

        // GET: Commanders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commander = await _context.Commander
                .FirstOrDefaultAsync(m => m.CommanderId == id);
            if (commander == null)
            {
                return NotFound();
            }

            return View(commander);
        }

        // POST: Commanders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commander = await _context.Commander.FindAsync(id);
            _context.Commander.Remove(commander);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommanderExists(int id)
        {
            return _context.Commander.Any(e => e.CommanderId == id);
        }
    }
}
