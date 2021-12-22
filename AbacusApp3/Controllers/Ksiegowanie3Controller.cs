using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbacusApp3.Data;
using AbacusApp3.Models;

namespace AbacusApp3.Controllers
{
    public class Ksiegowanie3Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Ksiegowanie3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ksiegowanie3
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ksiegowanie.Include(k => k.Konto).Include(k => k.Lokalizacja);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ksiegowanie3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiegowanie = await _context.Ksiegowanie
                .Include(k => k.Konto)
                .Include(k => k.Lokalizacja)
                .FirstOrDefaultAsync(m => m.KsiegowanieId == id);
            if (ksiegowanie == null)
            {
                return NotFound();
            }

            return View(ksiegowanie);
        }

        // GET: Ksiegowanie3/Create
        public IActionResult Create()
        {
            ViewData["KontoId"] = new SelectList(_context.Konto, "KontoId", "NazwaKonta");
            ViewData["LokalizacjaId"] = new SelectList(_context.Lokalizacja, "LokalizacjaId", "NazwaLok");
            return View();
        }

        // POST: Ksiegowanie3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KsiegowanieId,LokalizacjaId,KontoId,TerminPlatnosci,KwotaWn,KwotaWplaty,KwotaMa")] Ksiegowanie ksiegowanie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ksiegowanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KontoId"] = new SelectList(_context.Konto, "KontoId", "KontoId", ksiegowanie.KontoId);
            ViewData["LokalizacjaId"] = new SelectList(_context.Lokalizacja, "LokalizacjaId", "LokalizacjaId", ksiegowanie.LokalizacjaId);
            return View(ksiegowanie);
        }

        // GET: Ksiegowanie3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiegowanie = await _context.Ksiegowanie.FindAsync(id);
            if (ksiegowanie == null)
            {
                return NotFound();
            }
            ViewData["KontoId"] = new SelectList(_context.Konto, "KontoId", "NazwaKonta", ksiegowanie.KontoId);
            ViewData["LokalizacjaId"] = new SelectList(_context.Lokalizacja, "LokalizacjaId", "NazwaLok", ksiegowanie.LokalizacjaId);
            return View(ksiegowanie);
        }

        // POST: Ksiegowanie3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KsiegowanieId,LokalizacjaId,KontoId,TerminPlatnosci,KwotaWn,KwotaWplaty,KwotaMa")] Ksiegowanie ksiegowanie)
        {
            if (id != ksiegowanie.KsiegowanieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ksiegowanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KsiegowanieExists(ksiegowanie.KsiegowanieId))
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
            ViewData["KontoId"] = new SelectList(_context.Konto, "KontoId", "KontoId", ksiegowanie.KontoId);
            ViewData["LokalizacjaId"] = new SelectList(_context.Lokalizacja, "LokalizacjaId", "LokalizacjaId", ksiegowanie.LokalizacjaId);
            return View(ksiegowanie);
        }

        // GET: Ksiegowanie3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiegowanie = await _context.Ksiegowanie
                .Include(k => k.Konto)
                .Include(k => k.Lokalizacja)
                .FirstOrDefaultAsync(m => m.KsiegowanieId == id);
            if (ksiegowanie == null)
            {
                return NotFound();
            }

            return View(ksiegowanie);
        }

        // POST: Ksiegowanie3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ksiegowanie = await _context.Ksiegowanie.FindAsync(id);
            _context.Ksiegowanie.Remove(ksiegowanie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KsiegowanieExists(int id)
        {
            return _context.Ksiegowanie.Any(e => e.KsiegowanieId == id);
        }
    }
}
