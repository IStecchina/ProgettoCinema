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
    public class RoomController : Controller
    {
        private readonly IGateway<CinemaRoom> _gatewayR;
        private readonly IGateway<Cinema> _gatewayC;
        private readonly IGateway<Movie> _gatewayM;
        private readonly IGateway<Ticket> _gatewayT;

        public RoomController(IGateway<CinemaRoom> gatewayR, IGateway<Cinema> gatewayC, IGateway<Movie> gatewayM, IGateway<Ticket> gatewayT)
        {
            _gatewayR = gatewayR;
            _gatewayC = gatewayC;
            _gatewayM = gatewayM;
            _gatewayT = gatewayT;
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

        public async Task<IActionResult> EmptyRoom(int id)
        {
            try
            {
                var room = await _gatewayR.GetById(id);
                var IdList = new List<int>();
                //Can't delete items from the collection you're iterating on
                foreach (var t in room.OccupiedSeats)
                {
                    IdList.Add(t.ID);
                }
                foreach (int tId in IdList)
                {
                    await _gatewayT.Delete(tId);
                }


                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
            }
        }
    }
}
