using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aurora_Project.Data;
using Aurora_Project.Data.Entities;
using AutoMapper;
using Aurora_Project.Models.Orders;

namespace Aurora_Project.Controllers
{
    public class OrdersController : Controller
    {
        #region Data & Constructors

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrdersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            var orders = await _context
                                      .Orders
                                      .Include(orders => orders.Customer)
                                      .ToListAsync();

            var orderVMs = _mapper.Map<List<Order>, List<OrderIndexViewModel>>(orders);

            return View(orderVMs);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                                            .Include(order => order.Customer)
                                            .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            var orderVM = _mapper.Map<Order, OrderCreateUpdateViewModel>(order);

            return View(orderVM);
        }


        public IActionResult Create()
        {
            var orderVM = new OrderCreateUpdateViewModel();

            orderVM.CustomersSelectList = new SelectList(_context.Customers, "Id", "FullName");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderCreateUpdateViewModel orderVM)
        {
            if (ModelState.IsValid)
            {

                var order = _mapper.Map<OrderCreateUpdateViewModel, Order>(orderVM);

                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            orderVM.CustomersSelectList = new SelectList(_context.Customers, "Id", "FullName", orderVM.CustomerId);


            return View(orderVM);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Address", order.CustomerId);
            return View(order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderDate,OrderStatus,ShippingAddress,CustomerId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Address", order.CustomerId);
            return View(order);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Private Methods
        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        } 
        #endregion
    }
}
