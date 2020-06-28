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
    [Authorize]
    public class AutoresController : Controller
    {
        private readonly LibreriaDbContext _context;

        public AutoresController(LibreriaDbContext context)
        {
            _context = context;
        }

        // GET: Autores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autor.ToListAsync());
        }

        // GET: Autores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autores = await _context.Autor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (autores == null)
            {
                return NotFound();
            }

            return View(autores);
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nombre,apellido,nacionalidad,fechaNacimiento")] Autores autores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autores);
        }

        // GET: Autores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autores = await _context.Autor.FindAsync(id);
            if (autores == null)
            {
                return NotFound();
            }
            return View(autores);
        }

        // POST: Autores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nombre,apellido,nacionalidad,fechaNacimiento")] Autores autores)
        {
            if (id != autores.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoresExists(autores.ID))
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
            return View(autores);
        }

        // GET: Autores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autores = await _context.Autor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (autores == null)
            {
                return NotFound();
            }

            return View(autores);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autores = await _context.Autor.FindAsync(id);
            _context.Autor.Remove(autores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoresExists(int id)
        {
            return _context.Autor.Any(e => e.ID == id);
        }
    }
}
