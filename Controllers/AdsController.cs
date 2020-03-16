using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ad4You;
using Ad4You.Models;

namespace Ad4You.Controllers
{
    public class AdsController : Controller
    {
        private readonly Ad4YouContext _context;

        public AdsController(Ad4YouContext context)
        {
            _context = context;
        }

        // GET: Ads
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RubricSortParm = sortOrder == "rubric" ? "rubric_desc" : "rubric";
            var ads = from ad in _context.ad.Include(a => a.city).Include(a => a.currency).Include(a => a.rubric) select ad;

            if (!String.IsNullOrEmpty(searchString))
            {
                ads = ads.Where(ad => ad.name.Contains(searchString) || ad.description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    ads = ads.OrderByDescending(ad => ad.name);
                    break;
                case "rubric":
                    ads = ads.OrderBy(ad => ad.rubric.name);
                    break;
                case "rubric_desc":
                    ads = ads.OrderByDescending(ad => ad.rubric.name);
                    break;
                default:
                    ads = ads.OrderBy(ad => ad.name);
                    break;
            }

            return View(await ads.ToListAsync());
        }

        // GET: Ads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.ad
                .Include(a => a.city)
                .Include(a => a.currency)
                .Include(a => a.rubric)
                .FirstOrDefaultAsync(m => m.id == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // GET: Ads/Create
        public IActionResult Create()
        {
            ViewData["cityid"] = new SelectList(_context.city, "id", "name");
            ViewData["currencyid"] = new SelectList(_context.currency, "id", "sign");
            ViewData["rubricid"] = new SelectList(_context.rubric, "id", "name");
            return View();
        }

        // POST: Ads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,phone_number,rubricid,cityid,price,currencyid")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cityid"] = new SelectList(_context.city, "id", "name", ad.cityid);
            ViewData["currencyid"] = new SelectList(_context.currency, "id", "sign", ad.currencyid);
            ViewData["rubricid"] = new SelectList(_context.rubric, "id", "name", ad.rubricid);
            return View(ad);
        }

        // GET: Ads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.ad.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            ViewData["cityid"] = new SelectList(_context.city, "id", "name", ad.cityid);
            ViewData["currencyid"] = new SelectList(_context.currency, "id", "sign", ad.currencyid);
            ViewData["rubricid"] = new SelectList(_context.rubric, "id", "name", ad.rubricid);
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,phone_number,rubricid,cityid,price,currencyid")] Ad ad)
        {
            if (id != ad.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdExists(ad.id))
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
            ViewData["cityid"] = new SelectList(_context.city, "id", "name", ad.cityid);
            ViewData["currencyid"] = new SelectList(_context.currency, "id", "sign", ad.currencyid);
            ViewData["rubricid"] = new SelectList(_context.rubric, "id", "name", ad.rubricid);
            return View(ad);
        }

        // GET: Ads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.ad
                .Include(a => a.city)
                .Include(a => a.currency)
                .Include(a => a.rubric)
                .FirstOrDefaultAsync(m => m.id == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // POST: Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ad = await _context.ad.FindAsync(id);
            _context.ad.Remove(ad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdExists(int id)
        {
            return _context.ad.Any(e => e.id == id);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
