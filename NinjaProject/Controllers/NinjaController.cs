using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NinjaApplication.Models;
using NinjaLibrary.Database;
using NinjaProject.ViewModels;

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

            ViewData["Categories"] = _context.GearCategories.Select(cat => cat.Category).ToList();

            return View(ninja);
        }

            public IActionResult Shop(int id, string categoryId = "All") {
            var ninja = _context.Ninjas
                .Include(n => n.Inventory)
                .ThenInclude(item => item.Gear)
                .FirstOrDefault(n => n.Id == id);

            if(ninja == null)
            {
                return NotFound();
            }

            var allAvailableItems = _context.Gears.ToList();

            if(categoryId != "All")
            {
                allAvailableItems = allAvailableItems.Where(item => item.CategoryId == categoryId).ToList();
            } 

            var viewModel = new ShopViewModel
            {
                Ninja = ninja,
                GearList = allAvailableItems
            };

            var categories = _context.GearCategories.Select(cat => cat.Category).ToList();
            ViewBag.Categories = categories;

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Sell(int ninjaId, int itemId) {

            var ninja = _context.Ninjas
                .Include(n => n.Inventory)
                .FirstOrDefault(n => n.Id == ninjaId);

            if(ninja == null)
            {
                return NotFound("Ninja not found.");
            }

            Console.WriteLine($"Ninja {ninjaId} Item {itemId}");

            if(ninja.Inventory != null)
            {
                var itemToSell = ninja.Inventory.FirstOrDefault(item => item.GearId == itemId);
                if(itemToSell != null)
                {
                    ninja.Inventory.Remove(itemToSell);                
                    ninja.Gold += itemToSell.PricePaid;
                    _context.SaveChanges();
                    return RedirectToAction("Shop", new { id = ninjaId });

                }
                else
                {
                    return NotFound("Item not found.");
                }
            }
            else
            {
                return NotFound("Ninja inventory is null.");
            }
        }

        [HttpPost]
        public IActionResult Buy(int ninjaId, int itemId) {
            var ninja = _context.Ninjas
                .Include(n => n.Inventory)
                .FirstOrDefault(n => n.Id == ninjaId);

            if(ninja == null)
            {
                return NotFound("Ninja not found.");
            }

            var itemToBuy = _context.Gears.FirstOrDefault(item => item.Id == itemId);

            if(itemToBuy == null)
            {
                return NotFound("Item not found.");
            }

            if(ninja.Gold < itemToBuy.GoldValue)
            {
                TempData["ErrorMessage"] = "You don't have enough gold to buy this item.";
                return RedirectToAction("Shop", new { id = ninjaId });
            }


            foreach(var item in ninja.Inventory)
            {
                var gearId = item.GearId;
                var gear = _context.Gears.FirstOrDefault(g => g.Id == gearId);
                var cat = gear.CategoryId;

                if(cat == itemToBuy.CategoryId)
                {
                    return RedirectToAction("Shop", new { id = ninjaId });
                }
            }
            
            var existingItem = ninja.Inventory.FirstOrDefault(item => item.Gear.CategoryId == itemToBuy.CategoryId);

            var inventoryItem = new InventoryItem
            {
                NinjaId = ninja.Id,
                GearId = itemToBuy.Id,
                PricePaid = itemToBuy.GoldValue
            };

            ninja.Inventory.Add(inventoryItem);
            ninja.Gold -= itemToBuy.GoldValue;

            _context.SaveChanges();

            return RedirectToAction("Shop", new { id = ninjaId });
        }

        [HttpPost]
        public IActionResult clearInventory(int ninjaId) {
            var ninja = _context.Ninjas
                .Include(n => n.Inventory)
                .FirstOrDefault(n => n.Id == ninjaId);

            if(ninja == null)
            {
                return NotFound("Ninja not found.");
            }

            foreach(var item in ninja.Inventory)
            {
                ninja.Gold += item.PricePaid;
            }   
            ninja.Inventory.Clear();
            

            _context.SaveChanges();

            return RedirectToAction("Inventory", new { id = ninjaId });
        }

    }
}
