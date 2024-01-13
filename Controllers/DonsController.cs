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
    public class DonsController : Controller
    {
        private readonly ganymede_webContext _context;

        public DonsController(ganymede_webContext context)
        {
            _context = context;
        }

        // GET: Dons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Don.ToListAsync());
        }

        // GET: Dons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var don = await _context.Don
                .FirstOrDefaultAsync(m => m.Id == id);
            if (don == null)
            {
                return NotFound();
            }

            return View(don);
        }

        // GET: Dons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Prenom,Nom,Montant")] Don don)
        {
            if (ModelState.IsValid)
            {
                _context.Add(don);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(don);
        }

        // GET: Dons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var don = await _context.Don.FindAsync(id);
            if (don == null)
            {
                return NotFound();
            }
            return View(don);
        }

        // POST: Dons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Prenom,Nom,Montant")] Don don)
        {
            if (id != don.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(don);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonExists(don.Id))
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
            return View(don);
        }

        // GET: Dons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var don = await _context.Don
                .FirstOrDefaultAsync(m => m.Id == id);
            if (don == null)
            {
                return NotFound();
            }

            return View(don);
        }

        // POST: Dons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var don = await _context.Don.FindAsync(id);
            if (don != null)
            {
                _context.Don.Remove(don);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonExists(int id)
        {
            return _context.Don.Any(e => e.Id == id);
        }
    }
}
