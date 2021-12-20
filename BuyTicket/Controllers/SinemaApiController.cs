using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuyTicket.Data;
using BuyTicket.Models;

namespace BuyTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinemaApiController : ControllerBase
    {
        private readonly BiletDbContext _context;

        public SinemaApiController(BiletDbContext context)
        {
            _context = context;
        }

        // GET: api/SinemaApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sinema>>> GetSinemalar()
        {
            return await _context.Sinemalar.ToListAsync();
        }

        // GET: api/SinemaApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sinema>> GetSinema(int id)
        {
            var sinema = await _context.Sinemalar.FindAsync(id);

            if (sinema == null)
            {
                return NotFound();
            }

            return sinema;
        }

        // PUT: api/SinemaApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinema(int id, Sinema sinema)
        {
            if (id != sinema.SinemaId)
            {
                return BadRequest();
            }

            _context.Entry(sinema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinemaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SinemaApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sinema>> PostSinema(Sinema sinema)
        {
            _context.Sinemalar.Add(sinema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSinema", new { id = sinema.SinemaId }, sinema);
        }

        // DELETE: api/SinemaApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinema(int id)
        {
            var sinema = await _context.Sinemalar.FindAsync(id);
            if (sinema == null)
            {
                return NotFound();
            }

            _context.Sinemalar.Remove(sinema);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SinemaExists(int id)
        {
            return _context.Sinemalar.Any(e => e.SinemaId == id);
        }
    }
}
