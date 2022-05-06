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
    public class RoomController : Controller
    {
        private readonly RoomGateway _gatewayR;
        private readonly CinemaGateway _gatewayC;
        private readonly MovieGateway _gatewayM;

        public RoomController(RoomGateway gatewayR, CinemaGateway gatewayC, MovieGateway gatewayM)
        {
            _gatewayR = gatewayR;
            _gatewayC = gatewayC;
            _gatewayM = gatewayM;
        }
        public async Task<IActionResult> Index()
        {
            var rooms = await _gatewayR.GetAll();
            return View(rooms);
        }

        public async Task<IActionResult> Details(int id)
        {
            var room = await _gatewayR.GetById(id);
            if (room is not null)
            {
                return View(room);
            }
            else
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var cinemas = await _gatewayC.GetAll();
            var movies = await _gatewayM.GetAll();
            var model = new RoomCreationModel(new CinemaRoom(), cinemas, movies);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomCreationModel r)
        {
            try
            {
                var room = r.Room;
                await _gatewayR.Create(room);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
