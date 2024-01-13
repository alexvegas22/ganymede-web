using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ganymede_web.Data;
using ganymede_web.Models;

namespace ganymede_web.Controllers
{
    public class ItinerairesController : Controller
    {
        private readonly ganymede_webContext _context;

        public ItinerairesController(ganymede_webContext context)
        {
            _context = context;
        }

        // GET: Itineraires
        public async Task<IActionResult> Index()
        {
            var ganymede_webContext = _context.Itineraire.Include(i => i.Horaire);
            return View(await ganymede_webContext.ToListAsync());
        }

        // GET: Itineraires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itineraire = await _context.Itineraire
                .Include(i => i.Horaire)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itineraire == null)
            {
                return NotFound();
            }

            return View(itineraire);
        }

        // GET: Itineraires/Create
        public IActionResult Create()
        {
            ViewData["HoraireID"] = new SelectList(_context.Horaire, "Id", "Id");
            return View();
        }

        // POST: Itineraires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HoraireID,StartLocation,EndLocation")] Itineraire itineraire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itineraire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoraireID"] = new SelectList(_context.Horaire, "Id", "Id", itineraire.HoraireID);
            return View(itineraire);
        }

        // GET: Itineraires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itineraire = await _context.Itineraire.FindAsync(id);
            if (itineraire == null)
            {
                return NotFound();
            }
            ViewData["HoraireID"] = new SelectList(_context.Horaire, "Id", "Id", itineraire.HoraireID);
            return View(itineraire);
        }

        // POST: Itineraires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HoraireID,StartLocation,EndLocation")] Itineraire itineraire)
        {
            if (id != itineraire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itineraire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItineraireExists(itineraire.Id))
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
            ViewData["HoraireID"] = new SelectList(_context.Horaire, "Id", "Id", itineraire.HoraireID);
            return View(itineraire);
        }

        // GET: Itineraires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itineraire = await _context.Itineraire
                .Include(i => i.Horaire)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itineraire == null)
            {
                return NotFound();
            }

            return View(itineraire);
        }

        // POST: Itineraires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itineraire = await _context.Itineraire.FindAsync(id);
            if (itineraire != null)
            {
                _context.Itineraire.Remove(itineraire);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItineraireExists(int id)
        {
            return _context.Itineraire.Any(e => e.Id == id);
        }
    }
}
