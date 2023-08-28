using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aurora_Project.Data;
using Aurora_Project.Data.Entities;
using AutoMapper;
using Aurora_Project.Models.Bikes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aurora_Project.Controllers
{
    public class BikesController : Controller
    {
        #region Data & Constructors
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BikesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion


        #region Actions
        public async Task<IActionResult> Index()
        {
            var bikes = await _context
                                     .Bikes
                                     .ToListAsync();

            var bikeVMs = _mapper.Map<List<Bike>, List<BikeIndexViewModel>>(bikes);


            return View(bikeVMs);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context
                                    .Bikes
                                    .FirstOrDefaultAsync(m => m.Id == id);
            if (bike == null)
            {
                return NotFound();
            }

            var bikeVM = _mapper.Map<Bike, BikeDetailsViewModel>(bike);


            return View(bikeVM);
        }


        public IActionResult Create()
        {
            var bikeTypes = _context
                                   .BikeTypes
                                   .ToList();

            var bikeTypeSelectList = new SelectList(bikeTypes, "Id", "Type");

            var bikeVM = new BikeCreateUpdateViewModel
            {
                BikeTypeSelectList = bikeTypeSelectList
            };

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BikeCreateUpdateViewModel bikeVM)
        {
            if (ModelState.IsValid)
            {
                var bike = _mapper.Map<BikeCreateUpdateViewModel, Bike>(bikeVM);
                bike.BikeType = await _context.BikeTypes.FindAsync(bikeVM.BikeTypeId);

                _context.Add(bike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            bikeVM.BikeTypeSelectList = new SelectList(_context.BikeTypes, "Id", "Type", bikeVM.BikeTypeId);

            return View(bikeVM);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context
                                    .Bikes
                                    .FindAsync(id);


            if (bike == null)
            {
                return NotFound();
            }

            var bikeVM = _mapper.Map<Bike, BikeCreateUpdateViewModel>(bike);

            return View(bikeVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Year,Color")] BikeCreateUpdateViewModel bikeVM)
        {
            if (id != bikeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var bike = _mapper.Map<BikeCreateUpdateViewModel, Bike>(bikeVM);

                    _context.Update(bike);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeExists(bikeVM.Id))
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
            return View(bikeVM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bike = await _context
                                    .Bikes
                                    .FindAsync(id);

            if (bike != null)
            {
                _context.Bikes.Remove(bike);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
        #endregion


        #region Private Methods
        private bool BikeExists(int id)
        {
            return (_context.Bikes?.Any(e => e.Id == id)).GetValueOrDefault();
        } 
        #endregion
    }
}
