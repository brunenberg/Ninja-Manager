using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NinjaApplication.Models;
using NinjaProject.Database;

namespace NinjaProject.Controllers
{
    public class GearController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GearController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gear
        public async Task<IActionResult> Index()
        {
              return _context.Gears != null ? 
                          View(await _context.Gears.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Gears'  is null.");
        }

        // GET: Gear/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gears == null)
            {
                return NotFound();
            }

            var gear = await _context.Gears
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gear == null)
            {
                return NotFound();
            }

            return View(gear);
        }

        // GET: Gear/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gear/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GoldValue,Category,Strength,Intelligence,Agility")] Gear gear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gear);
        }

        // GET: Gear/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gears == null)
            {
                return NotFound();
            }

            var gear = await _context.Gears.FindAsync(id);
            if (gear == null)
            {
                return NotFound();
            }
            return View(gear);
        }

        // POST: Gear/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GoldValue,Category,Strength,Intelligence,Agility")] Gear gear)
        {
            if (id != gear.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GearExists(gear.Id))
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
            return View(gear);
        }

        // GET: Gear/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gears == null)
            {
                return NotFound();
            }

            var gear = await _context.Gears
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gear == null)
            {
                return NotFound();
            }

            return View(gear);
        }

        // POST: Gear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gears == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Gears'  is null.");
            }
            var gear = await _context.Gears.FindAsync(id);
            if (gear != null)
            {
                _context.Gears.Remove(gear);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GearExists(int id)
        {
          return (_context.Gears?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
