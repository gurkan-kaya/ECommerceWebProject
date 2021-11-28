using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuyTicket.Data;
using BuyTicket.Models;

namespace BuyTicket.Controllers
{
    public class OyuncusController : Controller
    {
        private readonly BiletDbContext _context;

        public OyuncusController(BiletDbContext context)
        {
            _context = context;
        }

        // GET: Oyuncus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oyuncular.ToListAsync());
        }

        // GET: Oyuncus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oyuncu = await _context.Oyuncular
                .FirstOrDefaultAsync(m => m.OyuncuId == id);
            if (oyuncu == null)
            {
                return NotFound();
            }

            return View(oyuncu);
        }

        // GET: Oyuncus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oyuncus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OyuncuId,OyuncuFotografi,OyuncuAdSoyad,OyuncuHakkinda")] Oyuncu oyuncu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oyuncu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oyuncu);
        }

        // GET: Oyuncus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oyuncu = await _context.Oyuncular.FindAsync(id);
            if (oyuncu == null)
            {
                return NotFound();
            }
            return View(oyuncu);
        }

        // POST: Oyuncus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OyuncuId,OyuncuFotografi,OyuncuAdSoyad,OyuncuHakkinda")] Oyuncu oyuncu)
        {
            if (id != oyuncu.OyuncuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oyuncu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OyuncuExists(oyuncu.OyuncuId))
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
            return View(oyuncu);
        }

        // GET: Oyuncus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oyuncu = await _context.Oyuncular
                .FirstOrDefaultAsync(m => m.OyuncuId == id);
            if (oyuncu == null)
            {
                return NotFound();
            }

            return View(oyuncu);
        }

        // POST: Oyuncus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oyuncu = await _context.Oyuncular.FindAsync(id);
            _context.Oyuncular.Remove(oyuncu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OyuncuExists(int id)
        {
            return _context.Oyuncular.Any(e => e.OyuncuId == id);
        }
    }
}
