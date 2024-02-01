using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using BusinessLogicLayer;

namespace PresentationLayer.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetCustomerAsync();
            return View(customers);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerService.Details(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }



        // the primary difference is that ActionResult is used for synchronous action methods,
        // while Task<ActionResult> is used for asynchronous action methods that return a result
        // asynchronously.


        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //The [Bind] attribute is used to control which properties are set from the incoming data.
        //The [Bind("Id,Name,City")] attribute is used to specify which properties of the
        //incoming HTTP request should be mapped (or bound) to the Customer object.
        //In this case, only the properties Id, Name, and City are allowed to be set from the incoming data.
        public IActionResult Create([Bind("Id,Name,City")] Customer customer)
        {
            if (ModelState.IsValid) // do validation
            {
                _customerService.CreateCustomerAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,City")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _customerService.UpdateCustomerAsync(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var CustomerExists = await _customerService.CheckCustomerExists(customer.Id);
                    if (!CustomerExists)
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerService.Details(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer != null)
            {
                _customerService.DeleteCustomerAsync(customer);
            }

            
            return RedirectToAction(nameof(Index));
        }

       
    
}
}
