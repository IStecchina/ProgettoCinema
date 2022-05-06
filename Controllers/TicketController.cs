using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgettoCinema.Abstract;
using ProgettoCinema.Domain;
using ProgettoCinema.Exceptions;
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
        private readonly IGateway<Ticket> _gatewayT;
        private readonly IGateway<CinemaRoom> _gatewayR;
        private readonly IGateway<Customer> _gatewayC;

        public TicketController(IGateway<Ticket> gatewayT, IGateway<CinemaRoom> gatewayR, IGateway<Customer> gatewayC)
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
                var partialTicket = t.Ticket;

                if (partialTicket.Price <= 0) throw new Exception();

                var customer = await _gatewayC.GetById(partialTicket.CustomerId);
                var room = await _gatewayR.GetById(partialTicket.RoomId);

                if (customer is null || room is null) throw new Exception();

                if (customer.Ticket is not null) throw new AlreadyHasTicketException();

                var position = room.AddCustomer(customer);

                var finalizedTicket = new Ticket()
                {
                    CustomerId = partialTicket.CustomerId,
                    RoomId = partialTicket.RoomId,
                    Price = partialTicket.Price,

                    Position = position
                };

                await _gatewayT.Create(finalizedTicket);
                return RedirectToAction("Index");
            }
            catch (FullRoomException)
            {
                return View("RoomFullError");
            }
            catch (ForbiddenMovieException)
            {
                return View("TooYoungError");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _gatewayT.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
