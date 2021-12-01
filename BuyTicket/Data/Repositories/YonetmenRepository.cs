using BuyTicket.Data.Repositories.Abstract;
using BuyTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Data.Repositories
{
    public class YonetmenRepository : IYonetmenRepository
    {
        private readonly BiletDbContext _context;
        public YonetmenRepository(BiletDbContext context)
        {
            _context = context;
        }
        public void Add(Yonetmen yonetmen)
        {
            _context.Add(yonetmen);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var silinecekYonetmen = _context.Yonetmenler.FirstOrDefault(m => m.YonetmenId == id);
            _context.Yonetmenler.Remove(silinecekYonetmen);
            _context.SaveChanges();
        }

        public Yonetmen GetById(int id)
        {
            var y = _context.Yonetmenler.FirstOrDefault(m => m.YonetmenId == id);
            return y;
        }

        public async Task<IEnumerable<Yonetmen>> ListAll()
        {
            var liste = await _context.Yonetmenler.ToListAsync();
            return liste;
        }

        public Yonetmen Update(int id, Yonetmen yonetmenSon)
        {
            _context.Update(yonetmenSon);
            _context.SaveChanges();
            return yonetmenSon;
        }
    }
}
