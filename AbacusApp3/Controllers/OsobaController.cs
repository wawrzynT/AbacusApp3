﻿using System;
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
    public class OsobaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OsobaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Osoba
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Osoba.Include(o => o.Lokalizacja);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Osoba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osoba
                .Include(o => o.Lokalizacja)
                .FirstOrDefaultAsync(m => m.OsobaId == id);
            if (osoba == null)
            {
                return NotFound();
            }

            return View(osoba);
        }

        // GET: Osoba/Create
        public IActionResult Create()
        {
            ViewData["LokalizacjaId"] = new SelectList(_context.Lokalizacja, "LokalizacjaId", "LokalizacjaId");
            return View();
        }

        // POST: Osoba/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OsobaId,Imie,Nazwisko,Pesel,DokumentTozsamosci,LokalizacjaId")] Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(osoba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LokalizacjaId"] = new SelectList(_context.Lokalizacja, "LokalizacjaId", "LokalizacjaId", osoba.LokalizacjaId);
            return View(osoba);
        }

        // GET: Osoba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osoba.FindAsync(id);
            if (osoba == null)
            {
                return NotFound();
            }
            ViewData["LokalizacjaId"] = new SelectList(_context.Lokalizacja, "LokalizacjaId", "LokalizacjaId", osoba.LokalizacjaId);
            return View(osoba);
        }

        // POST: Osoba/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OsobaId,Imie,Nazwisko,Pesel,DokumentTozsamosci,LokalizacjaId")] Osoba osoba)
        {
            if (id != osoba.OsobaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(osoba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OsobaExists(osoba.OsobaId))
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
            ViewData["LokalizacjaId"] = new SelectList(_context.Lokalizacja, "LokalizacjaId", "LokalizacjaId", osoba.LokalizacjaId);
            return View(osoba);
        }

        // GET: Osoba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osoba
                .Include(o => o.Lokalizacja)
                .FirstOrDefaultAsync(m => m.OsobaId == id);
            if (osoba == null)
            {
                return NotFound();
            }

            return View(osoba);
        }

        // POST: Osoba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var osoba = await _context.Osoba.FindAsync(id);
            _context.Osoba.Remove(osoba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OsobaExists(int id)
        {
            return _context.Osoba.Any(e => e.OsobaId == id);
        }
    }
}
