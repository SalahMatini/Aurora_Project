﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aurora_Project.Data;
using Aurora_Project.Data.Entities;
using AutoMapper;
using Aurora_Project.Models.Customers;

namespace Aurora_Project.Controllers
{

    public class CustomersController : Controller
    {


        #region Data & Constructors
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion


        #region Actions
        public async Task<IActionResult> Index()
        {
            var customers = await _context
                                         .Customers
                                         .ToListAsync();

            var customerVMs = _mapper.Map<List<Customer>, List<CustomerIndexViewModel>>(customers);

            return View(customerVMs);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context
                                        .Customers
                                        .FirstOrDefaultAsync(m => m.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            var customerVM = _mapper.Map<Customer, CustomerDetailsViewModel>(customer);

            return View(customerVM);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateUpdateViewModel customerVM)
        {
            if (ModelState.IsValid)
            {

                var customer = _mapper.Map<CustomerCreateUpdateViewModel, Customer>(customerVM);

                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerVM);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context
                                        .Customers
                                        .FindAsync(id);


            if (customer == null)
            {
                return NotFound();
            }

            var customerVM = _mapper.Map<Customer, CustomerCreateUpdateViewModel>(customer);

            return View(customerVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerCreateUpdateViewModel customerVM)
        {
            if (id != customerVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var customer = _mapper.Map<CustomerCreateUpdateViewModel, Customer>(customerVM);

                    _context.Update(customer);
                    await _context.SaveChangesAsync();

                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customerVM.Id))
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
            return View(customerVM);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Private Methods
        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        } 
        #endregion


    }
}
