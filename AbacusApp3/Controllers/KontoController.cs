using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbacusApp3.Data;
using AbacusApp3.Models;
using Microsoft.AspNetCore.Authorization;

namespace AbacusApp3.Controllers
{
    public class KontoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KontoController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Konto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Konto.ToListAsync());
        }

        [Authorize]
        // GET: Konto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konto = await _context.Konto
                .FirstOrDefaultAsync(m => m.KontoId == id);
            if (konto == null)
            {
                return NotFound();
            }

            return View(konto);
        }

        [Authorize]
                // GET: Konto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Konto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KontoId,NazwaKonta")] Konto konto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(konto);
        }

        [Authorize]
        // GET: Konto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konto = await _context.Konto.FindAsync(id);
            if (konto == null)
            {
                return NotFound();
            }
            return View(konto);
        }

        // POST: Konto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("KontoId,NazwaKonta")] Konto konto)
        {
            if (id != konto.KontoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KontoExists(konto.KontoId))
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
            return View(konto);
        }

        [Authorize]
        // GET: Konto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konto = await _context.Konto
                .FirstOrDefaultAsync(m => m.KontoId == id);
            if (konto == null)
            {
                return NotFound();
            }

            return View(konto);
        }

        [Authorize]
        // POST: Konto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var konto = await _context.Konto.FindAsync(id);
            _context.Konto.Remove(konto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KontoExists(int id)
        {
            return _context.Konto.Any(e => e.KontoId == id);
        }
    }
}
