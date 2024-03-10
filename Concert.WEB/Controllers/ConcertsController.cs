using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Concert.WEB.Data;
using Concert.WEB.Models;

namespace Concert.WEB.Controllers
{
    public class ConcertsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConcertsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Concerts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Concerts.ToListAsync());
        }

        // GET: Concerts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concertLab = await _context.Concerts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concertLab == null)
            {
                return NotFound();
            }

            return View(concertLab);
        }

        // GET: Concerts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Concerts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConcertName,ConcertDate,ConcertPrice,ConcertPlace,ImageUrl")] ConcertLab concertLab)
        {
            if (ModelState.IsValid)
            {
                concertLab.Id = Guid.NewGuid();
                _context.Add(concertLab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concertLab);
        }

        // GET: Concerts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concertLab = await _context.Concerts.FindAsync(id);
            if (concertLab == null)
            {
                return NotFound();
            }
            return View(concertLab);
        }

        // POST: Concerts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ConcertName,ConcertDate,ConcertPrice,ConcertPlace,ImageUrl")] ConcertLab concertLab)
        {
            if (id != concertLab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concertLab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcertLabExists(concertLab.Id))
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
            return View(concertLab);
        }

        // GET: Concerts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concertLab = await _context.Concerts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concertLab == null)
            {
                return NotFound();
            }

            return View(concertLab);
        }

        // POST: Concerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var concertLab = await _context.Concerts.FindAsync(id);
            if (concertLab != null)
            {
                _context.Concerts.Remove(concertLab);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcertLabExists(Guid id)
        {
            return _context.Concerts.Any(e => e.Id == id);
        }
    }
}
