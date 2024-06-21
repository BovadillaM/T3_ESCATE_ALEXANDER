using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using T2_ESCATE_ALEXANDER.Datos;
using T2_ESCATE_ALEXANDER.Models;
using System.Linq;
using System.Collections.Generic;

namespace T2_ESCATE_ALEXANDER.Controllers
{
    [Authorize]
    public class LibroController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LibroController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Acción accesible para todos los usuarios, incluyendo anónimos
        [AllowAnonymous]
        public IActionResult Index()
        {
            IEnumerable<Libro> lista = _db.Libro.ToList();
            if (lista == null)
            {
                lista = new List<Libro>();
            }
            return View(lista);
        }

        // Acción accesible para todos los usuarios, incluyendo anónimos
        [AllowAnonymous]
        public IActionResult Detalles(int id)
        {
            var libro = _db.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // Acción accesible solo para administradores
        [Authorize(Roles = "Admin")]
        public IActionResult Crear()
        {
            return View();
        }

        // Acción accesible solo para administradores
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Crear(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _db.Libro.Add(libro);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // Acción accesible solo para administradores
        [Authorize(Roles = "Admin")]
        public IActionResult Editar(int id)
        {
            var libro = _db.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // Acción accesible solo para administradores
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Editar(int id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _db.Libro.Update(libro);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // Acción accesible solo para administradores
        [Authorize(Roles = "Admin")]
        public IActionResult Eliminar(int id)
        {
            var libro = _db.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // Acción accesible solo para administradores
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult EliminarConfirmed(int id)
        {
            var libro = _db.Libro.Find(id);
            if (libro == null)
            {
                return NotFound();
            }

            _db.Libro.Remove(libro);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
