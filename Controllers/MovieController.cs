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
    public class MovieController : Controller
    {
        private readonly IGateway<Movie> _gatewayM;

        public MovieController(IGateway<Movie> gatewayM)
        {
            _gatewayM = gatewayM;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _gatewayM.GetAll();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _gatewayM.GetById(id);
            if (movie is not null)
            {
                return View(movie);
            }
            else
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Movie());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie m)
        {
            try
            {
                await _gatewayM.Create(m);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var movie = await _gatewayM.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Movie m)
        {
            try
            {
                await _gatewayM.Update(m);
                return RedirectToAction("Index");
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
                await _gatewayM.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
}
