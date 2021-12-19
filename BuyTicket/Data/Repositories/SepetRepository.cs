using BuyTicket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Data.Repositories
{
    public class SepetRepository
    {
        public BiletDbContext _context;
        public SepetRepository(BiletDbContext context)
        {
            _context = context;
        }
        
        //SepetID
        public string SepetNo { get; set; }

        public ICollection<Sepet> Sepettekiler { get; set; }

        public double SepetToplamTutar()
        {
            var toplamTutar = _context.Sepetler.Where(m => m.SepetNo == SepetNo).Select(m => m.Film.FilmUcreti * m.Adet).Sum();
            return toplamTutar;
        }

        public ICollection<Sepet> SepeteEklenenler() 
        {
        // ?? ifadesi Sepettekiler null ise Sepettekiler'e atama yapılmasını sağlıyor.
        return Sepettekiler ?? (Sepettekiler = _context.Sepetler.Where(m => m.SepetNo == SepetNo).Include(m => m.Film).ToList());
        }

        public async Task SepetiBosalt()
        {
            var urunler= Sepettekiler ?? (Sepettekiler = await _context.Sepetler.Where(m => m.SepetNo == SepetNo).ToListAsync());
            _context.Sepetler.RemoveRange(urunler);
            await _context.SaveChangesAsync();
        }


        public void SepeteEkle(Film film)
        {
            var eklenecekUrun = _context.Sepetler.FirstOrDefault(m => m.Film.FilmId == film.FilmId && m.SepetNo == SepetNo);

            if (eklenecekUrun == null)
            {
                eklenecekUrun = new Sepet()
                {
                    SepetNo = SepetNo,
                    Film = film,
                    Adet = 1

                };
                _context.Sepetler.Add(eklenecekUrun);
            }
            else
            {
                eklenecekUrun.Adet++;
            }
            _context.SaveChanges();
        }

        public void SepettenCikar(Film film)
        {
            var cikarilacakUrun = _context.Sepetler.FirstOrDefault(m => m.Film.FilmId == film.FilmId && m.SepetNo == SepetNo);

            if (cikarilacakUrun != null)
            {
                if(cikarilacakUrun.Adet>1)                
                    cikarilacakUrun.Adet--;

                else
                _context.Sepetler.Remove(cikarilacakUrun);
            }

            _context.SaveChanges();
        }

        //Alışveriş sepeti oluşturmak için session kullanımı gerekli. Bu sebeple aşağıdaki servis ayarları yapıldı ve startup.cs'de de ilgili düzenlemeler yapıldı.
        //startup cs'de çağrılacağı için statik olarak tanımlandı
        public static SepetRepository AlisVerisSepetiniGetir(IServiceProvider servisler)
        {
            ISession session = servisler.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; //? -> null değilse demek
            var context = servisler.GetService<BiletDbContext>();

            //Eğer alışveriş sepeti daha önce oluşturulmadıysa guid ile eşsiz bir  isim verilip oluşturuluyor.
            string sepetId = session.GetString("SepetId") ?? Guid.NewGuid().ToString();
            session.SetString("SepetId", sepetId);

            return new SepetRepository(context) { SepetNo = sepetId };
        }






    }
}
