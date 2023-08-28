using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aurora_Project.Data;
using Aurora_Project.Data.Entities;
using AutoMapper;

namespace Aurora_Project.Controllers
{
    public class BikeTypesController : Controller
    {
        #region Data % Constructors
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BikeTypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion


        #region Actions
        public async Task<IActionResult> Index()
        {
           var bikeTypes = await _context.
        }


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


        public IActionResult Create()
        {
            return View();
        }


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
        #endregion


        #region Private Methods
        private bool BikeTypeExists(int id)
        {
            return (_context.BikeType?.Any(e => e.Id == id)).GetValueOrDefault();
        } 
        #endregion
    }
}
