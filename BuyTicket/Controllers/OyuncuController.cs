using BuyTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Controllers
{
    public class OyuncuController : Controller
    {

        private readonly BiletDbContext _context;
        public OyuncuController(BiletDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var oyuncular = await _context.Oyuncular.ToListAsync();
            return View();
        }
    }
}
