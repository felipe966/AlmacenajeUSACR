using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlmacenajeUSACR.Data;
using AlmacenajeUSACR.Models;

namespace AlmacenajeUSACR.Controllers
{
    public class TransportistasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportistasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transportistas
        public async Task<IActionResult> Index()
        {
              return _context.Transportista != null ? 
                          View(await _context.Transportista.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Transportista'  is null.");
        }

        // GET: Transportistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transportista == null)
            {
                return NotFound();
            }

            var transportista = await _context.Transportista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportista == null)
            {
                return NotFound();
            }

            return View(transportista);
        }

        // GET: Transportistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transportistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo_transportista,Nombre_empresa")] Transportista transportista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transportista);
        }

        // GET: Transportistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transportista == null)
            {
                return NotFound();
            }

            var transportista = await _context.Transportista.FindAsync(id);
            if (transportista == null)
            {
                return NotFound();
            }
            return View(transportista);
        }

        // POST: Transportistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo_transportista,Nombre_empresa")] Transportista transportista)
        {
            if (id != transportista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportistaExists(transportista.Id))
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
            return View(transportista);
        }

        // GET: Transportistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transportista == null)
            {
                return NotFound();
            }

            var transportista = await _context.Transportista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportista == null)
            {
                return NotFound();
            }

            return View(transportista);
        }

        // POST: Transportistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transportista == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transportista'  is null.");
            }
            var transportista = await _context.Transportista.FindAsync(id);
            if (transportista != null)
            {
                _context.Transportista.Remove(transportista);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportistaExists(int id)
        {
          return (_context.Transportista?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
