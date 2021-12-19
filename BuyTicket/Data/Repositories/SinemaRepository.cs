using BuyTicket.Data.Repositories.Abstract;
using BuyTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Data.Repositories
{
    public class SinemaRepository : ISinemaRepository
    {
        private readonly BiletDbContext _context;
        public SinemaRepository(BiletDbContext context)
        {
            _context = context;
        }
        public void Add(Sinema sinema)
        {
            _context.Add(sinema);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var silinecekSinema = _context.Sinemalar.FirstOrDefault(m => m.SinemaId == id);
            _context.Sinemalar.Remove(silinecekSinema);
            _context.SaveChanges();
        }

        public Sinema GetById(int id)
        {
            var s = _context.Sinemalar.FirstOrDefault(m => m.SinemaId == id);
            return s;
        }

        public async Task<IEnumerable<Sinema>> ListAll()
        {
            var liste = await _context.Sinemalar.ToListAsync();
            return liste;
        }

        public Sinema Update(int id, Sinema sinemaSon)
        {
            _context.Update(sinemaSon);
            _context.SaveChanges();
            return sinemaSon;
        }
    }
}
