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
    public class Articulo_custodiaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Articulo_custodiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articulo_custodia
        public async Task<IActionResult> Index()
        {
              return _context.Articulo_custodia != null ? 
                          View(await _context.Articulo_custodia.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Articulo_custodia'  is null.");
        }

        // GET: Articulo_custodia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Articulo_custodia == null)
            {
                return NotFound();
            }

            var articulo_custodia = await _context.Articulo_custodia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulo_custodia == null)
            {
                return NotFound();
            }

            return View(articulo_custodia);
        }

        // GET: Articulo_custodia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articulo_custodia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo_cliente,Codigo_transportista,TrackingID,Descripcion,Peso,Precio_articulo,Fecha_ingreso,Estado,Fecha_retiro")] Articulo_custodia articulo_custodia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulo_custodia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articulo_custodia);
        }


        // GET
        public IActionResult Retiro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Retiro(int Codigo_cliente)
        {
            if (Codigo_cliente == 0)
            {
                return NotFound();
            }

            var articulos = from c in _context.Articulo_custodia select c;
            articulos = articulos.Where(c => c.Codigo_cliente == Codigo_cliente && c.Estado == "Pendiente retiro").OrderByDescending(c => c.Fecha_ingreso);
            HttpContext.Session.SetInt32("Codigo_cliente", Codigo_cliente);   
            return View("ArticulosCliente", articulos);
        }

        // GET
        public IActionResult ArticulosCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ArticulosCliente(int? Codigo_cliente)
        {
            var articulos = from c in _context.Articulo_custodia select c;
            articulos = articulos.Where(c => c.Codigo_cliente == (int)HttpContext.Session.GetInt32("Codigo_cliente") && c.Estado=="Pendiente retiro");
            foreach (var i in articulos) {
                i.Fecha_retiro = DateTime.Now.Date;
                i.Estado = "Retirado";
                var retirado = new Articulo_retirado();
                retirado.Codigo_cliente = i.Codigo_cliente;
                retirado.Codigo_transportista = i.Codigo_transportista;
                retirado.TrackingID = i.TrackingID;
                retirado.Descripcion = i.Descripcion;
                retirado.Estado = i.Estado;
                retirado.Fecha_retiro = i.Fecha_retiro;
                _context.Add(retirado);
            }
            await _context.SaveChangesAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");   
        }




        // GET: Articulo_custodia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Articulo_custodia == null)
            {
                return NotFound();
            }

            var articulo_custodia = await _context.Articulo_custodia.FindAsync(id);
            if (articulo_custodia == null)
            {
                return NotFound();
            }
            return View(articulo_custodia);
        }

        // POST: Articulo_custodia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo_cliente,Codigo_transportista,TrackingID,Descripcion,Peso,Precio_articulo,Fecha_ingreso,Estado,Fecha_retiro")] Articulo_custodia articulo_custodia)
        {
            if (id != articulo_custodia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulo_custodia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Articulo_custodiaExists(articulo_custodia.Id))
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
            return View(articulo_custodia);
        }

        // GET: Articulo_custodia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Articulo_custodia == null)
            {
                return NotFound();
            }

            var articulo_custodia = await _context.Articulo_custodia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulo_custodia == null)
            {
                return NotFound();
            }

            return View(articulo_custodia);
        }

        // POST: Articulo_custodia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Articulo_custodia == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Articulo_custodia'  is null.");
            }
            var articulo_custodia = await _context.Articulo_custodia.FindAsync(id);
            if (articulo_custodia != null)
            {
                _context.Articulo_custodia.Remove(articulo_custodia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Articulo_custodiaExists(int id)
        {
          return (_context.Articulo_custodia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
