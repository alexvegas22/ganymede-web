using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ganymede_web.Data;
using ganymede_web.Models;
using System.Text.Json;

namespace ganymede_web.Controllers
{
    public class ItinerairesController : Controller
    {
        private readonly ganymede_webContext _context;
        private static readonly HttpClient client = new HttpClient();

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
                /*
                var myAPIKey = "AIzaSyAt-d1ZtDhE0s0robvrvjbsNj_rtdwd_lU";
                var responseStringStart = await client.GetStringAsync("https://maps.googleapis.com/maps/api/geocode/json?address=" +System.Web.HttpUtility.UrlEncode(itineraire.StartLocation)+"&key=" + myAPIKey);

                Rootobject mapdataStart =  JsonSerializer.Deserialize<Rootobject>(responseStringStart);

                itineraire.StartLocation = mapdataStart.results[0].geometry.location.lat.ToString() + mapdataStart.results[0].geometry.location.lng.ToString();

                var responseStringEnd = await client.GetStringAsync("https://maps.googleapis.com/maps/api/geocode/json?address=" +System.Web.HttpUtility.UrlEncode(itineraire.EndLocation)+"&key=" + myAPIKey);

                Rootobject mapdataEnd =  JsonSerializer.Deserialize<Rootobject>(responseStringEnd);

                itineraire.EndLocation = mapdataEnd.results[0].geometry.location.lat.ToString() + mapdataEnd.results[0].geometry.location.lng.ToString();
*/
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

    public class Rootobject
{
    public Result[] results { get; set; }
    public string status { get; set; }
}

public class Result
{
    public Address_Components[] address_components { get; set; }
    public string formatted_address { get; set; }
    public Geometry geometry { get; set; }
    public string place_id { get; set; }
    public string[] types { get; set; }
}

public class Geometry
{
    public Location location { get; set; }
    public string location_type { get; set; }
    public Viewport viewport { get; set; }
}

public class Location
{
    public float lat { get; set; }
    public float lng { get; set; }
}

public class Viewport
{
    public Northeast northeast { get; set; }
    public Southwest southwest { get; set; }
}

public class Northeast
{
    public float lat { get; set; }
    public float lng { get; set; }
}

public class Southwest
{
    public float lat { get; set; }
    public float lng { get; set; }
}

public class Address_Components
{
    public string long_name { get; set; }
    public string short_name { get; set; }
    public string[] types { get; set; }
}
}
