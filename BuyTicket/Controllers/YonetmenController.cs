using BuyTicket.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Controllers
{
    public class YonetmenController : Controller
    {
        private readonly BiletDbContext _context;
        public YonetmenController(BiletDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var yonetmenler = await _context.Yonetmenler.ToListAsync();
            return View(yonetmenler);
        }
    }
}
