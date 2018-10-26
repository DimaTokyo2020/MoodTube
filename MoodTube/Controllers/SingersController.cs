using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoodTube.Data;
using MoodTube.Models;

namespace MoodTube.Controllers
{
    public class SingersController : Controller
    {
        private readonly MusicContext _context;

        public SingersController(MusicContext context)
        {
            _context = context;
        }

        // GET: Singers
        public async Task<IActionResult> Index(string sortOrder, string searchSingerString)
        {
            ViewData["SingerSortParm"] = String.IsNullOrEmpty(sortOrder) ? "SingerName_desc" : "";
            ViewData["SingerNameFilter"] = searchSingerString;

            var singers =_context.Singers;

            //Search:
            //Singer
            if (!String.IsNullOrEmpty(searchSingerString))
            {
                var songV = singers.Where(s => s.SingerName.Contains(searchSingerString));
                return View(await songV.AsNoTracking().ToListAsync());
            }


            //Sort
            switch (sortOrder)
            {
                case "SingerName_desc":
                    var song1 = singers.OrderByDescending(s => s.SingerName);
                    return View(await song1.AsNoTracking().ToListAsync());
                default:
                    var song5 = singers.OrderBy(s => s.SingerName);
                    return View(await song5.AsNoTracking().ToListAsync());
            }


            return View(await _context.Singers.ToListAsync());
        }

        // GET: Singers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singer = await _context.Singers
             .Include(s => s.Songs)
            .ThenInclude(e => e.Mood)
            .AsNoTracking()
            .SingleOrDefaultAsync(m => m.SingerID == id);

            if (singer == null)
            {
                return NotFound();
            }

            return View(singer);
        }

        // GET: Singers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Singers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SingerID,SingerName")] Singer singer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(singer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(singer);
        }

        // GET: Singers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singer = await _context.Singers.FindAsync(id);
            if (singer == null)
            {
                return NotFound();
            }
            return View(singer);
        }

        // POST: Singers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SingerID,SingerName")] Singer singer)
        {
            if (id != singer.SingerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(singer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SingerExists(singer.SingerID))
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
            return View(singer);
        }

        // GET: Singers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singer = await _context.Singers
                .FirstOrDefaultAsync(m => m.SingerID == id);
            if (singer == null)
            {
                return NotFound();
            }

            return View(singer);
        }

        // POST: Singers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var singer = await _context.Singers.FindAsync(id);
            _context.Singers.Remove(singer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SingerExists(string id)
        {
            return _context.Singers.Any(e => e.SingerID == id);
        }
    }
}
