using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgettoCinema.Abstract;
using ProgettoCinema.Domain;
using ProgettoCinema.Gateways;
using ProgettoCinema.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace ProgettoCinema.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IGateway<Customer> _gatewayC;

        public CustomerController(IGateway<Customer> gatewayC)
        {
            _gatewayC = gatewayC;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _gatewayC.GetAll();
            return View(customers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var customer = await _gatewayC.GetById(id);
            if (customer is not null)
            {
                return View(customer);
            }
            else
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer c)
        {
            try
            {
                await _gatewayC.Create(c);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
