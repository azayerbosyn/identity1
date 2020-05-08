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
    public class StudyEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudyEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudyEvents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudyEvent.Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudyEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyEvent = await _context.StudyEvent
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyEvent == null)
            {
                return NotFound();
            }

            return View(studyEvent);
        }

        // GET: StudyEvents/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "Address");
            return View();
        }

        // POST: StudyEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventType,Mark,DescriptionOfEvent,EventDate,StudentId")] StudyEvent studyEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "Address", studyEvent.StudentId);
            return View(studyEvent);
        }

        // GET: StudyEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyEvent = await _context.StudyEvent.FindAsync(id);
            if (studyEvent == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "Address", studyEvent.StudentId);
            return View(studyEvent);
        }

        // POST: StudyEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventType,Mark,DescriptionOfEvent,EventDate,StudentId")] StudyEvent studyEvent)
        {
            if (id != studyEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studyEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyEventExists(studyEvent.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "Address", studyEvent.StudentId);
            return View(studyEvent);
        }

        // GET: StudyEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyEvent = await _context.StudyEvent
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyEvent == null)
            {
                return NotFound();
            }

            return View(studyEvent);
        }

        // POST: StudyEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studyEvent = await _context.StudyEvent.FindAsync(id);
            _context.StudyEvent.Remove(studyEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudyEventExists(int id)
        {
            return _context.StudyEvent.Any(e => e.Id == id);
        }
    }
}
