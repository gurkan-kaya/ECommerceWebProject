using BuyTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Data.Repositories.Abstract
{
    public interface ISinemaRepository
    {
        Sinema GetById(int id);
        void Add(Sinema sinema);
        void Delete(int id);
        Sinema Update(int id, Sinema sinemaSon);
        Task<IEnumerable<Sinema>> ListAll();
    }
}
