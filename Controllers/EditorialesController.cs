using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibreriaMVC.Data;
using LibreriaMVC.Models;

namespace LibreriaMVC.Controllers
{
    public class EditorialesController : Controller
    {
        private readonly LibreriaDbContext _context;

        public EditorialesController(LibreriaDbContext context)
        {
            _context = context;
        }

        // GET: Editoriales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Editorial.ToListAsync());
        }

        // GET: Editoriales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoriales = await _context.Editorial
                .FirstOrDefaultAsync(m => m.ID == id);
            if (editoriales == null)
            {
                return NotFound();
            }

            return View(editoriales);
        }

        // GET: Editoriales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editoriales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Ciudad,Estado,Pais")] Editoriales editoriales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editoriales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editoriales);
        }

        // GET: Editoriales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoriales = await _context.Editorial.FindAsync(id);
            if (editoriales == null)
            {
                return NotFound();
            }
            return View(editoriales);
        }

        // POST: Editoriales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Ciudad,Estado,Pais")] Editoriales editoriales)
        {
            if (id != editoriales.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editoriales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialesExists(editoriales.ID))
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
            return View(editoriales);
        }

        // GET: Editoriales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoriales = await _context.Editorial
                .FirstOrDefaultAsync(m => m.ID == id);
            if (editoriales == null)
            {
                return NotFound();
            }

            return View(editoriales);
        }

        // POST: Editoriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editoriales = await _context.Editorial.FindAsync(id);
            _context.Editorial.Remove(editoriales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorialesExists(int id)
        {
            return _context.Editorial.Any(e => e.ID == id);
        }
    }
}
