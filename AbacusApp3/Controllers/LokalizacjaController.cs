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
    public class LokalizacjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LokalizacjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lokalizacja
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lokalizacja.ToListAsync());
        }

        // GET: Lokalizacja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokalizacja = await _context.Lokalizacja
                .FirstOrDefaultAsync(m => m.LokalizacjaId == id);
            if (lokalizacja == null)
            {
                return NotFound();
            }

            return View(lokalizacja);
        }

        // GET: Lokalizacja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lokalizacja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LokalizacjaId,NazwaLok,Ulica,NrDomu,NrLokalu,KodPocztowy,Miejscowosc")] Lokalizacja lokalizacja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lokalizacja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lokalizacja);
        }

        // GET: Lokalizacja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokalizacja = await _context.Lokalizacja.FindAsync(id);
            if (lokalizacja == null)
            {
                return NotFound();
            }
            return View(lokalizacja);
        }

        // POST: Lokalizacja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LokalizacjaId,NazwaLok,Ulica,NrDomu,NrLokalu,KodPocztowy,Miejscowosc")] Lokalizacja lokalizacja)
        {
            if (id != lokalizacja.LokalizacjaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lokalizacja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokalizacjaExists(lokalizacja.LokalizacjaId))
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
            return View(lokalizacja);
        }

        // GET: Lokalizacja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokalizacja = await _context.Lokalizacja
                .FirstOrDefaultAsync(m => m.LokalizacjaId == id);
            if (lokalizacja == null)
            {
                return NotFound();
            }

            return View(lokalizacja);
        }

        // POST: Lokalizacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lokalizacja = await _context.Lokalizacja.FindAsync(id);
            _context.Lokalizacja.Remove(lokalizacja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LokalizacjaExists(int id)
        {
            return _context.Lokalizacja.Any(e => e.LokalizacjaId == id);
        }
    }
}
