using BuyTicket.Data;
using BuyTicket.Data.Abstract;
using BuyTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Repositories
{
    public class OyuncuRepository : IOyuncuRepository
    {
        private readonly BiletDbContext _context;
        public OyuncuRepository(BiletDbContext context)
        {
            _context = context;
        }
        public void Add(Oyuncu oyuncu)
        {
            
            _context.Add(oyuncu);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var silinecekOyuncu = _context.Oyuncular.FirstOrDefault(m => m.OyuncuId == id);
            _context.Oyuncular.Remove(silinecekOyuncu);
            _context.SaveChanges();
        }

        public Oyuncu GetById(int id)
        {
            var o = _context.Oyuncular.FirstOrDefault(m => m.OyuncuId == id);
            return o;
        }

        public async Task<IEnumerable<Oyuncu>> ListAll()
        {
            var liste = await _context.Oyuncular.ToListAsync();
            return liste;
        }

        public Oyuncu Update(int id, Oyuncu oyuncuSon)
        {
            _context.Update(oyuncuSon);
            _context.SaveChanges();
            return oyuncuSon;
        }

    }
}
