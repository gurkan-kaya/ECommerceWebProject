using BuyTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Data.Repositories.Abstract
{
    public interface IYonetmenRepository
    {
        Yonetmen GetById(int id);
        void Add(Yonetmen yonetmen);
        void Delete(int id);
        Yonetmen Update(int id, Yonetmen yonetmenSon);
        Task<IEnumerable<Yonetmen>> ListAll();
    }
}
