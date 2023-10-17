﻿using System;
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
    public class NinjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NinjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ninja
        public async Task<IActionResult> Index()
        {
              return _context.Ninjas != null ? 
                          View(await _context.Ninjas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Ninjas'  is null.");
        }

        // GET: Ninja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ninjas == null)
            {
                return NotFound();
            }

            var ninja = await _context.Ninjas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ninja == null)
            {
                return NotFound();
            }

            return View(ninja);
        }

        // GET: Ninja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ninja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gold")] Ninja ninja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ninja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ninja);
        }

        // GET: Ninja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ninjas == null)
            {
                return NotFound();
            }

            var ninja = await _context.Ninjas.FindAsync(id);
            if (ninja == null)
            {
                return NotFound();
            }
            return View(ninja);
        }

        // POST: Ninja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gold")] Ninja ninja)
        {
            if (id != ninja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ninja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NinjaExists(ninja.Id))
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
            return View(ninja);
        }

        // GET: Ninja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ninjas == null)
            {
                return NotFound();
            }

            var ninja = await _context.Ninjas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ninja == null)
            {
                return NotFound();
            }

            return View(ninja);
        }

        // POST: Ninja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ninjas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ninjas'  is null.");
            }
            var ninja = await _context.Ninjas.FindAsync(id);
            if (ninja != null)
            {
                _context.Ninjas.Remove(ninja);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NinjaExists(int id)
        {
          return (_context.Ninjas?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult Inventory(int id) {
            var ninja = _context.Ninjas
                .Include(n => n.Inventory) 
                .ThenInclude(item => item.Gear)
                .FirstOrDefault(n => n.Id == id);

            if(ninja == null)
            {
                return NotFound(); 
            }

            int totalStrength = ninja.Inventory.Sum(item => item.Gear.Strength);
            int totalAgility = ninja.Inventory.Sum(item => item.Gear.Agility);
            int totalIntelligence = ninja.Inventory.Sum(item => item.Gear.Intelligence);

            int totalGearValue = ninja.Inventory.Sum(item => item.Gear.GoldValue);

            ViewData["TotalStrength"] = totalStrength;
            ViewData["TotalAgility"] = totalAgility;
            ViewData["TotalIntelligence"] = totalIntelligence;
            ViewData["TotalGearValue"] = totalGearValue;


            return View(ninja);
        }

    }
}
