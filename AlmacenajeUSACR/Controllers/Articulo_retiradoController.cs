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
    public class Articulo_retiradoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Articulo_retiradoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articulo_retirado
        public async Task<IActionResult> Index(DateTime? start, DateTime? end)

        {

            ViewBag.start = start;
            ViewBag.end = end;
            var articulos = from s in _context.Articulo_retirado
                            select s;
            if (end !=null || start != null)
            {
                articulos = articulos.Where(c => c.Fecha_retiro >= start && c.Fecha_retiro <= end).OrderByDescending(a => a.Fecha_retiro).ThenByDescending(a => a.Codigo_cliente);
            }
            
           
            
            return View(articulos);


           // return _context.Articulo_retirado != null ? 
             //             View(await _context.Articulo_retirado.ToListAsync()) :
               //           Problem("Entity set 'ApplicationDbContext.Articulo_retirado'  is null.");
        }

        // GET: Articulo_retirado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Articulo_retirado == null)
            {
                return NotFound();
            }

            var articulo_retirado = await _context.Articulo_retirado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulo_retirado == null)
            {
                return NotFound();
            }

            return View(articulo_retirado);
        }

        // GET: Articulo_retirado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articulo_retirado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo_cliente,Codigo_transportista,TrackingID,Descripcion,Estado,Fecha_retiro")] Articulo_retirado articulo_retirado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulo_retirado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articulo_retirado);
        }

        

        // GET: Articulo_retirado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Articulo_retirado == null)
            {
                return NotFound();
            }

            var articulo_retirado = await _context.Articulo_retirado.FindAsync(id);
            if (articulo_retirado == null)
            {
                return NotFound();
            }
            return View(articulo_retirado);
        }

        // POST: Articulo_retirado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo_cliente,Codigo_transportista,TrackingID,Descripcion,Estado,Fecha_retiro")] Articulo_retirado articulo_retirado)
        {
            if (id != articulo_retirado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulo_retirado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Articulo_retiradoExists(articulo_retirado.Id))
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
            return View(articulo_retirado);
        }

        // GET: Articulo_retirado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Articulo_retirado == null)
            {
                return NotFound();
            }

            var articulo_retirado = await _context.Articulo_retirado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulo_retirado == null)
            {
                return NotFound();
            }

            return View(articulo_retirado);
        }

        // POST: Articulo_retirado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Articulo_retirado == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Articulo_retirado'  is null.");
            }
            var articulo_retirado = await _context.Articulo_retirado.FindAsync(id);
            if (articulo_retirado != null)
            {
                _context.Articulo_retirado.Remove(articulo_retirado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Articulo_retiradoExists(int id)
        {
          return (_context.Articulo_retirado?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
