using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibreriaMVC.Data;
using LibreriaMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibreriaMVC.Controllers
{
    [Authorize(Roles="admin")]
    public class LibrosController : Controller
    {
        private readonly LibreriaDbContext _context;
        private readonly string viewPath = "../Catalogos/Libros";

        public LibrosController(LibreriaDbContext context)
        {
            _context = context;
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            var libreriaDbContext = _context.Libro.Include(l => l.autor).Include(l => l.editorial);
            return View($"{viewPath}/Index", await libreriaDbContext.ToListAsync());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libros = await _context.Libro
                .Include(l => l.autor)
                .Include(l => l.editorial)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (libros == null)
            {
                return NotFound();
            }

            return View($"{viewPath}/Details", libros);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            ViewData["AutoresID"] = new SelectList(_context.Autor, "ID", "ID");
            ViewData["EditorialesID"] = new SelectList(_context.Editorial, "ID", "ID");
            return View($"{viewPath}/Create");
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AutoresID,EditorialesID,Titulo,Precio,FechaPublicacion")] Libros libros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoresID"] = new SelectList(_context.Autor, "ID", "ID", libros.AutoresID);
            ViewData["EditorialesID"] = new SelectList(_context.Editorial, "ID", "ID", libros.EditorialesID);
            return View($"{viewPath}/Create", libros);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libros = await _context.Libro.FindAsync(id);
            if (libros == null)
            {
                return NotFound();
            }
            ViewData["AutoresID"] = new SelectList(_context.Autor, "ID", "ID", libros.AutoresID);
            ViewData["EditorialesID"] = new SelectList(_context.Editorial, "ID", "ID", libros.EditorialesID);
            return View($"{viewPath}/Edit", libros);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AutoresID,EditorialesID,Titulo,Precio,FechaPublicacion")] Libros libros)
        {
            if (id != libros.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibrosExists(libros.ID))
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
            ViewData["AutoresID"] = new SelectList(_context.Autor, "ID", "ID", libros.AutoresID);
            ViewData["EditorialesID"] = new SelectList(_context.Editorial, "ID", "ID", libros.EditorialesID);
            return View($"{viewPath}/Edit", libros);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libros = await _context.Libro
                .Include(l => l.autor)
                .Include(l => l.editorial)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (libros == null)
            {
                return NotFound();
            }

            return View($"{viewPath}/Delete", libros);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libros = await _context.Libro.FindAsync(id);
            _context.Libro.Remove(libros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibrosExists(int id)
        {
            return _context.Libro.Any(e => e.ID == id);
        }
    }
}
