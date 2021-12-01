using BuyTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Data.Repositories.Abstract
{
    public interface IOyuncuRepository
    {
        Oyuncu GetById(int id);
        void Add(Oyuncu oyuncu);
        void Delete(int id);
        Oyuncu Update(int id,Oyuncu oyuncuSon);
        Task<IEnumerable<Oyuncu>> ListAll();

    }
}
