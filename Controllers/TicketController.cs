using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class TicketController : Controller
    {
        private readonly TicketGateway _gatewayT;
        private readonly RoomGateway _gatewayR;
        private readonly CustomerGateway _gatewayC;

        public TicketController(TicketGateway gatewayT, RoomGateway gatewayR, CustomerGateway gatewayC)
        {
            _gatewayT = gatewayT;
            _gatewayR = gatewayR;
            _gatewayC = gatewayC;
        }
        public async Task<IActionResult> Index()
        {
            var tickets = await _gatewayT.GetAll();
            return View(tickets);
        }

        public async Task<IActionResult> Details(int id)
        {
            var ticket = await _gatewayT.GetById(id);
            if (ticket is not null)
            {
                return View(ticket);
            }
            else
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var rooms = await _gatewayR.GetAll();
            var customers = await _gatewayC.GetAll();
            var model = new TicketCreationModel(new Ticket(), rooms, customers);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketCreationModel t)
        {
            try
            {
                var ticket = t.Ticket;
                await _gatewayT.Create(ticket);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
