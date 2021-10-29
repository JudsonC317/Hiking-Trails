using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HikingTrails.Data;
using HikingTrails.Models;

namespace HikingTrails.Controllers
{
    public class TrailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trail.ToListAsync());
        }

        // GET: Trails/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // PoST: Trails/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Trail.Where( j => j.trailName.Contains(SearchPhrase) ).ToListAsync());
        }

        // GET: Trails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = await _context.Trail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trail == null)
            {
                return NotFound();
            }

            return View(trail);
        }

        // GET: Trails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,trailName,rating,review")] Trail trail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trail);
        }

        // GET: Trails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = await _context.Trail.FindAsync(id);
            if (trail == null)
            {
                return NotFound();
            }
            return View(trail);
        }

        // POST: Trails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,trailName,rating,review")] Trail trail)
        {
            if (id != trail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrailExists(trail.Id))
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
            return View(trail);
        }

        // GET: Trails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = await _context.Trail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trail == null)
            {
                return NotFound();
            }

            return View(trail);
        }

        // POST: Trails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trail = await _context.Trail.FindAsync(id);
            _context.Trail.Remove(trail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrailExists(int id)
        {
            return _context.Trail.Any(e => e.Id == id);
        }
    }
}
