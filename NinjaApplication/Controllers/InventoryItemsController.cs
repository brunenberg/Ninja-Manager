using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NinjaApplication.Data;
using NinjaApplication.Models;

namespace NinjaApplication.Controllers
{
    public class InventoryItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InventoryItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InventoryItem.Include(i => i.Gear).Include(i => i.Ninja);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InventoryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InventoryItem == null)
            {
                return NotFound();
            }

            var inventoryItem = await _context.InventoryItem
                .Include(i => i.Gear)
                .Include(i => i.Ninja)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            return View(inventoryItem);
        }

        // GET: InventoryItems/Create
        public IActionResult Create()
        {
            ViewData["GearId"] = new SelectList(_context.Gear, "Id", "Name");
            ViewData["NinjaId"] = new SelectList(_context.Ninja, "Id", "Name");
            return View();
        }

        // POST: InventoryItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NinjaId,GearId")] InventoryItem inventoryItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GearId"] = new SelectList(_context.Gear, "Id", "Name", inventoryItem.GearId);
            ViewData["NinjaId"] = new SelectList(_context.Ninja, "Id", "Name", inventoryItem.NinjaId);
            return View(inventoryItem);
        }

        // GET: InventoryItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InventoryItem == null)
            {
                return NotFound();
            }

            var inventoryItem = await _context.InventoryItem.FindAsync(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }
            ViewData["GearId"] = new SelectList(_context.Gear, "Id", "Name", inventoryItem.GearId);
            ViewData["NinjaId"] = new SelectList(_context.Ninja, "Id", "Name", inventoryItem.NinjaId);
            return View(inventoryItem);
        }

        // POST: InventoryItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NinjaId,GearId")] InventoryItem inventoryItem)
        {
            if (id != inventoryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryItemExists(inventoryItem.Id))
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
            ViewData["GearId"] = new SelectList(_context.Gear, "Id", "Name", inventoryItem.GearId);
            ViewData["NinjaId"] = new SelectList(_context.Ninja, "Id", "Name", inventoryItem.NinjaId);
            return View(inventoryItem);
        }

        // GET: InventoryItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InventoryItem == null)
            {
                return NotFound();
            }

            var inventoryItem = await _context.InventoryItem
                .Include(i => i.Gear)
                .Include(i => i.Ninja)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            return View(inventoryItem);
        }

        // POST: InventoryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InventoryItem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.InventoryItem'  is null.");
            }
            var inventoryItem = await _context.InventoryItem.FindAsync(id);
            if (inventoryItem != null)
            {
                _context.InventoryItem.Remove(inventoryItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryItemExists(int id)
        {
          return (_context.InventoryItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
