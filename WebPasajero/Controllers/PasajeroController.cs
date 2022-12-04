using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WebPasajero.Data;
using WebPasajero.Models;
using System.Linq;

namespace WebPasajero.Controllers
{
    public class PasajeroController : Controller
    {
        private readonly PasajeroContext _context;

        public PasajeroController(PasajeroContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Pasajeros.ToList());
        }

        [HttpGet("/pasajero/ListaPorCiudad/{city}")]
        public IActionResult ListaPorCiudad(string city)
        {
            List<Pasajero> lista = (from p in _context.Pasajeros
                                  where p.Ciudad == city
                                  select p).ToList();
            return View("index", lista);
        }


        public IActionResult Edit(int id)
        {
            var pasajero = _context.Pasajeros.SingleOrDefault(m => m.PasajeroId == id);
            pasajero.Nombre = "Brandon";
            _context.Update(pasajero);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            Pasajero pasajero = new Pasajero();
            return View("Create", pasajero);
        }

        // POST: /Person/Create
        [HttpPost]
        public IActionResult Create(Pasajero pasajero)
        {
            _context.Add(pasajero);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var pasajero = _context.Pasajeros.SingleOrDefault(m => m.PasajeroId == id);
            _context.Pasajeros.Remove(pasajero);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
