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
    public class FilmsController : Controller
    {
        private readonly BiletDbContext _context;

        public FilmsController(BiletDbContext context)
        {
            _context = context;
        }

        // GET: Films
        public async Task<IActionResult> Index()
        {
            var biletDbContext = _context.Filmler.Include(f => f.Sinema).Include(f => f.Yonetmen);
            return View(await biletDbContext.ToListAsync());
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Filmler
                .Include(f => f.Sinema)
                .Include(f => f.Yonetmen)
                .FirstOrDefaultAsync(m => m.FilmId == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            ViewData["SinemaId"] = new SelectList(_context.Sinemalar, "SinemaId", "SinemaAdi");
            ViewData["YonetmenId"] = new SelectList(_context.Yonetmenler, "YonetmenId", "YonetmenAdSoyad");
           // ViewData["FilmlerOyuncular"] = new SelectList(_context.Oyuncular, "OyuncuId", "OyuncuAdSoyad");
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmId,FilmAdi,FilmHakkinda,FilmBaslamaSaati1,FilmBaslamaSaati2,FilmBaslamaSaati3,FilmFotografi,FilmKategorisi,FilmUcreti,SinemaId,YonetmenId,FilmlerOyuncular")] Film film)
        {
            if (ModelState.IsValid)
            {
                _context.Add(film);
                await _context.SaveChangesAsync();
              
                foreach (var oyuncuid in film.FilmlerOyuncular)
                {
                    var filmoyuncu = new FilmOyuncu()
                    {
                        FilmId = film.FilmId,
                        OyuncuId = oyuncuid.OyuncuId
                    };
                   await _context.FilmlerOyuncular.AddAsync(filmoyuncu);
                }
               await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
            }
            ViewData["SinemaId"] = new SelectList(_context.Sinemalar, "SinemaId", "SinemaAdi", film.SinemaId);
            ViewData["YonetmenId"] = new SelectList(_context.Yonetmenler, "YonetmenId", "YonetmenAdSoyad", film.YonetmenId);
         //   ViewData["FilmlerOyuncular"] = new SelectList(_context.Oyuncular, "OyuncuId", "OyuncuAdSoyad",film.FilmlerOyuncular);
            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Filmler.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            ViewData["SinemaId"] = new SelectList(_context.Sinemalar, "SinemaId", "SinemaAdi", film.SinemaId);
            ViewData["YonetmenId"] = new SelectList(_context.Yonetmenler, "YonetmenId", "YonetmenAdSoyad", film.YonetmenId);
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmId,FilmAdi,FilmHakkinda,FilmBaslamaSaati1,FilmBaslamaSaati2,FilmBaslamaSaati3,FilmFotografi,FilmKategorisi,FilmUcreti,SinemaId,YonetmenId")] Film film)
        {
            if (id != film.FilmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.FilmId))
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
            ViewData["SinemaId"] = new SelectList(_context.Sinemalar, "SinemaId", "SinemaAdi", film.SinemaId);
            ViewData["YonetmenId"] = new SelectList(_context.Yonetmenler, "YonetmenId", "YonetmenAdSoyad", film.YonetmenId);
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Filmler
                .Include(f => f.Sinema)
                .Include(f => f.Yonetmen)
                .FirstOrDefaultAsync(m => m.FilmId == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Filmler.FindAsync(id);
            _context.Filmler.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Filmler.Any(e => e.FilmId == id);
        }
    }
}
