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
    public class BenevolesController : Controller
    {
        private readonly ganymede_webContext _context;

        public BenevolesController(ganymede_webContext context)
        {
            _context = context;
        }

        // GET: Benevoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Benevole.ToListAsync());
        }

        // GET: Benevoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benevole = await _context.Benevole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (benevole == null)
            {
                return NotFound();
            }

            return View(benevole);
        }

        // GET: Benevoles/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Accepted()
        {
            return View();
        }

        // POST: Benevoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Password,Age,NomEtablissement,rolePreferee,LibreFinDeSemaine,LibreJourFeries,RecuFormationPremierSoins")] Benevole benevole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(benevole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Accepted));
            }
            return View(Accepted);
        }

        private IActionResult View(Func<IActionResult> accepted)
        {
            return RedirectToAction(nameof(Accepted));
        }

        // GET: Benevoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benevole = await _context.Benevole.FindAsync(id);
            if (benevole == null)
            {
                return NotFound();
            }
            return View(benevole);
        }

        // POST: Benevoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Password,Age,NomEtablissement,rolePreferee,LibreFinDeSemaine,LibreJourFeries,RecuFormationPremierSoins")] Benevole benevole)
        {
            if (id != benevole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(benevole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BenevoleExists(benevole.Id))
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
            return View(benevole);
        }

        // GET: Benevoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benevole = await _context.Benevole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (benevole == null)
            {
                return NotFound();
            }

            return View(benevole);
        }

        // POST: Benevoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var benevole = await _context.Benevole.FindAsync(id);
            if (benevole != null)
            {
                _context.Benevole.Remove(benevole);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BenevoleExists(int id)
        {
            return _context.Benevole.Any(e => e.Id == id);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email, MotDePasse")] Benevole benevole)
        {
            var unBenevole = await _context.Benevole.FirstOrDefaultAsync(b => b.Nom == benevole.Nom && b.Password == benevole.Password);

            if (unBenevole != null)
            {
                return RedirectToAction("Index", "Horaires");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email ou mot passe est incorrect!");
                return View();
            }
        }
    }
}
