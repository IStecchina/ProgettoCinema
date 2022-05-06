﻿using Microsoft.AspNetCore.Mvc;
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
    public class CinemaController : Controller
    {
        private readonly ILogger<CinemaController> _logger;
        private readonly CinemaGateway _gatewayC;

        public CinemaController(ILogger<CinemaController> logger, CinemaGateway gatewayC)
        {
            _logger = logger;
            _gatewayC = gatewayC;
        }

        public async Task<IActionResult> Index()
        {
            var cinemas = await _gatewayC.GetAll();
            return View(cinemas);
        }

        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _gatewayC.GetById(id);
            if (cinema is not null)
            {
                return View(cinema);
            }
            else
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Cinema());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cinema c)
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
