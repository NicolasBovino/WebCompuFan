using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBasico.Context;
using WebCompuFan.Models;

namespace WebCompuFan.Controllers
{
    public class OrdenDeCompraController : Controller
    {
        private readonly CompuFanDatabaseContext _context;

        public OrdenDeCompraController(CompuFanDatabaseContext context)
        {
            _context = context;
        }

        // GET: OrdenDeCompra
        public async Task<IActionResult> Index()
        {
            var compuFanDatabaseContext = _context.OrdenDeCompra.Include(o => o.Articulo).Include(o => o.Cliente);
            return View(await compuFanDatabaseContext.ToListAsync());
        }

        // GET: OrdenDeCompra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdenDeCompra == null)
            {
                return NotFound();
            }

            var ordenDeCompra = await _context.OrdenDeCompra
                .Include(o => o.Articulo)
                .Include(o => o.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordenDeCompra == null)
            {
                return NotFound();
            }

            return View(ordenDeCompra);
        }

        // GET: OrdenDeCompra/Create
        public IActionResult Create()
        {
            ViewData["ArticuloId"] = new SelectList(_context.Articulo, "Id", "Id");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id");
            return View();
        }

        // POST: OrdenDeCompra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArticuloId,ClienteId,Cantidad")] OrdenDeCompra ordenDeCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenDeCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticuloId"] = new SelectList(_context.Articulo, "Id", "Id", ordenDeCompra.ArticuloId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", ordenDeCompra.ClienteId);
            return View(ordenDeCompra);
        }

        // GET: OrdenDeCompra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdenDeCompra == null)
            {
                return NotFound();
            }

            var ordenDeCompra = await _context.OrdenDeCompra.FindAsync(id);
            if (ordenDeCompra == null)
            {
                return NotFound();
            }
            ViewData["ArticuloId"] = new SelectList(_context.Articulo, "Id", "Id", ordenDeCompra.ArticuloId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", ordenDeCompra.ClienteId);
            return View(ordenDeCompra);
        }

        // POST: OrdenDeCompra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArticuloId,ClienteId,Cantidad")] OrdenDeCompra ordenDeCompra)
        {
            if (id != ordenDeCompra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenDeCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenDeCompraExists(ordenDeCompra.Id))
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
            ViewData["ArticuloId"] = new SelectList(_context.Articulo, "Id", "Id", ordenDeCompra.ArticuloId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", ordenDeCompra.ClienteId);
            return View(ordenDeCompra);
        }

        // GET: OrdenDeCompra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdenDeCompra == null)
            {
                return NotFound();
            }

            var ordenDeCompra = await _context.OrdenDeCompra
                .Include(o => o.Articulo)
                .Include(o => o.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordenDeCompra == null)
            {
                return NotFound();
            }

            return View(ordenDeCompra);
        }

        // POST: OrdenDeCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdenDeCompra == null)
            {
                return Problem("Entity set 'CompuFanDatabaseContext.OrdenDeCompra'  is null.");
            }
            var ordenDeCompra = await _context.OrdenDeCompra.FindAsync(id);
            if (ordenDeCompra != null)
            {
                _context.OrdenDeCompra.Remove(ordenDeCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenDeCompraExists(int id)
        {
          return (_context.OrdenDeCompra?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
