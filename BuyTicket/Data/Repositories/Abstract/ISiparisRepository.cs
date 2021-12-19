using BuyTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Data.Repositories.Abstract
{
    public interface ISiparisRepository
    {
        Task<ICollection<Siparis>> SiparisleriGetir(string kullaniciId);
        Task SiparisiKaydet(ICollection<Sepet> urunler, string kullaniciId, string kullaniciEmail);
    }
}
