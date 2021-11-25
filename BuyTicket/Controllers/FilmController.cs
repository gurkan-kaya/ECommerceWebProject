using BuyTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Controllers
{
    public class FilmController : Controller
    {
        private readonly BiletDbContext _context;
        public FilmController(BiletDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var filmler = await _context.Filmler.ToListAsync();
            return View();
        }
    }
}
