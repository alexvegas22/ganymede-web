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
    public class HorairesController : Controller
    {
        private readonly ganymede_webContext _context;

        public HorairesController(ganymede_webContext context)
        {
            _context = context;
        }

        // GET: Horaires
        public async Task<IActionResult> Index()
        {
            var ganymede_webContext = _context.Horaire.Include(h => h.Benevole);
            return View(await ganymede_webContext.ToListAsync());
        }

        // GET: Horaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horaire = await _context.Horaire
                .Include(h => h.Benevole)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horaire == null)
            {
                return NotFound();
            }

            return View(horaire);
        }

        // GET: Horaires/Create
        public IActionResult Create()
        {
            ViewData["BenevoleID"] = new SelectList(_context.Set<Benevole>(), "Id", "Id");
            return View();
        }

        // POST: Horaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BenevoleID,StartTime,EndTime,Role")] Horaire horaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BenevoleID"] = new SelectList(_context.Set<Benevole>(), "Id", "Id", horaire.BenevoleID);
            return View(horaire);
        }

        // GET: Horaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horaire = await _context.Horaire.FindAsync(id);
            if (horaire == null)
            {
                return NotFound();
            }
            ViewData["BenevoleID"] = new SelectList(_context.Set<Benevole>(), "Id", "Id", horaire.BenevoleID);
            return View(horaire);
        }

        // POST: Horaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BenevoleID,StartTime,EndTime,Role")] Horaire horaire)
        {
            if (id != horaire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoraireExists(horaire.Id))
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
            ViewData["BenevoleID"] = new SelectList(_context.Set<Benevole>(), "Id", "Id", horaire.BenevoleID);
            return View(horaire);
        }

        // GET: Horaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horaire = await _context.Horaire
                .Include(h => h.Benevole)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horaire == null)
            {
                return NotFound();
            }

            return View(horaire);
        }

        // POST: Horaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horaire = await _context.Horaire.FindAsync(id);
            if (horaire != null)
            {
                _context.Horaire.Remove(horaire);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoraireExists(int id)
        {
            return _context.Horaire.Any(e => e.Id == id);
        }
    }
}
