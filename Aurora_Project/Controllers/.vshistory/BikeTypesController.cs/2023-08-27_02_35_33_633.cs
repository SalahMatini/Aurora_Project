using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aurora_Project.Data;
using Aurora_Project.Data.Entities;

namespace Aurora_Project.Controllers
{
    public class BikeTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BikeTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BikeTypes
        public async Task<IActionResult> Index()
        {
              return _context.BikeType != null ? 
                          View(await _context.BikeType.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BikeType'  is null.");
        }

        // GET: BikeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BikeType == null)
            {
                return NotFound();
            }

            var bikeType = await _context.BikeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bikeType == null)
            {
                return NotFound();
            }

            return View(bikeType);
        }

        // GET: BikeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BikeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] BikeType bikeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bikeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bikeType);
        }

        // GET: BikeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BikeType == null)
            {
                return NotFound();
            }

            var bikeType = await _context.BikeType.FindAsync(id);
            if (bikeType == null)
            {
                return NotFound();
            }
            return View(bikeType);
        }

        // POST: BikeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] BikeType bikeType)
        {
            if (id != bikeType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bikeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeTypeExists(bikeType.Id))
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
            return View(bikeType);
        }

        // GET: BikeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BikeType == null)
            {
                return NotFound();
            }

            var bikeType = await _context.BikeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bikeType == null)
            {
                return NotFound();
            }

            return View(bikeType);
        }

        // POST: BikeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BikeType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BikeType'  is null.");
            }
            var bikeType = await _context.BikeType.FindAsync(id);
            if (bikeType != null)
            {
                _context.BikeType.Remove(bikeType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikeTypeExists(int id)
        {
          return (_context.BikeType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
