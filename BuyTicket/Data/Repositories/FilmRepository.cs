using BuyTicket.Data.Repositories.Abstract;
using BuyTicket.Models;
using BuyTicket.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BuyTicket.Data.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly BiletDbContext _context;
        public FilmRepository(BiletDbContext context)
        {
            _context = context;
        }

        public void Add(Film film)
        {
            _context.Add(film);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var silinecekFilm = _context.Filmler.FirstOrDefault(m => m.FilmId == id);
            var ilgilisepet = _context.Sepetler.Where(b => b.Film.FilmId == silinecekFilm.FilmId).AsEnumerable();
            foreach (var sp in ilgilisepet)
            {
                var s = sp;
                _context.Sepetler.Remove(s);
            }
  
            _context.Filmler.Remove(silinecekFilm);
            _context.SaveChanges();

            //var silinecekFilm = _context.Filmler.FirstOrDefault(m => m.FilmId == id);
            // _context.Filmler.Remove(silinecekFilm);
            //_context.SaveChanges();
        }

        public async Task FilmEkle(FilmVM fvm)
        {
            var film = new Film();
            film.FilmAdi = fvm.FilmAdi;
            film.FilmBaslamaSaati1 = fvm.FilmBaslamaSaati1;
            film.FilmBaslamaSaati2 = fvm.FilmBaslamaSaati2;
            film.FilmBaslamaSaati3 = fvm.FilmBaslamaSaati3;
            film.FilmFotografi = fvm.FilmFotografi;
            film.FilmHakkinda = fvm.FilmHakkinda;
            film.FilmKategorisi = fvm.FilmKategorisi;
            film.FilmUcreti=fvm.FilmUcreti;
            film.SinemaId = fvm.SinemaId;
            film.YonetmenId = fvm.YonetmenId;
            await _context.Filmler.AddAsync(film);
            await _context.SaveChangesAsync();

            //yukdarıdaki işlemlerle viewmodelimizdeki verileri bir film nesnesi oluşturarak ona atadık ve veritabanına kaydettik.
            //Şimdi de veritabanına kaydedilen yeni filmin id'sini kullanarak oyuncuları ekleyeceğiz.

            foreach(var oyuncu in fvm.OyuncuListesi) //oyunculistesi oyuncu id'lerini tutuyor
            {
                var filmoyuncu = new FilmOyuncu();
                filmoyuncu.FilmId = film.FilmId;
                filmoyuncu.OyuncuId = oyuncu;
                await _context.FilmlerOyuncular.AddAsync(filmoyuncu);
            }
            await _context.SaveChangesAsync();
            
        }

        public  Film FilmGetir(int id)
        {
            var filmGetir =  _context.Filmler
                .Include(fo => fo.FilmlerOyuncular).ThenInclude(o => o.Oyuncu)
                .Include(s => s.Sinema)
                .Include(y => y.Yonetmen)
                .FirstOrDefault(m => m.FilmId == id);
            return   filmGetir;
        }

        public async Task FilmGuncelle(FilmVM fvm)
        {
            var filmiBul = await _context.Filmler.FirstOrDefaultAsync(m => m.FilmId == fvm.FilmId);


            if (filmiBul != null)
            {
                filmiBul.FilmAdi = fvm.FilmAdi;
                filmiBul.FilmBaslamaSaati1 = fvm.FilmBaslamaSaati1;
                filmiBul.FilmBaslamaSaati2 = fvm.FilmBaslamaSaati2;
                filmiBul.FilmBaslamaSaati3 = fvm.FilmBaslamaSaati3;
                filmiBul.FilmFotografi = fvm.FilmFotografi;
                filmiBul.FilmHakkinda = fvm.FilmHakkinda;
                filmiBul.FilmKategorisi = fvm.FilmKategorisi;
                filmiBul.FilmUcreti = fvm.FilmUcreti;
                filmiBul.SinemaId = fvm.SinemaId;
                filmiBul.YonetmenId = fvm.YonetmenId;
                await _context.SaveChangesAsync();
            }
                //Güncelleme işlemi sonrası değişen oyuncular olabilir, bu sebeple önceki eklenen oyuncular veritabanından silinip yenileri eklenmeli.

                var oncekiOyunvcular = _context.FilmlerOyuncular.Where(m => m.FilmId == fvm.FilmId).ToList();
                _context.FilmlerOyuncular.RemoveRange(oncekiOyunvcular);
                await _context.SaveChangesAsync();

            foreach (var oyuncu in fvm.OyuncuListesi) //oyunculistesi oyuncu id'lerini tutuyor
            {
                var filmoyuncu = new FilmOyuncu();
                filmoyuncu.FilmId = fvm.FilmId;
                filmoyuncu.OyuncuId = oyuncu;
                await _context.FilmlerOyuncular.AddAsync(filmoyuncu);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<FilmVeriLists> FilmVerileri()
        {
            var veriler = new FilmVeriLists();
            veriler.Sinemalar = await _context.Sinemalar.ToListAsync();
            veriler.Yonetmenler = await _context.Yonetmenler.ToListAsync();
            veriler.Oyuncular = await _context.Oyuncular.ToListAsync();
            return veriler;
        }

        public Film GetById(int id)
        {
            var f = _context.Filmler.FirstOrDefault(m => m.FilmId == id);
            return f;
        }
        
        public async Task<IEnumerable<Film>> ListAll()
        {
            var liste = await _context.Filmler.ToListAsync();
            return liste;
        }

        public async Task<IEnumerable<Film>> ListAll(params Expression<Func<Film, object>>[] i)
        {
            IQueryable<Film> sorgu = _context.Set<Film>();
            sorgu= i.Aggregate(sorgu,(current,prop)=>current.Include(prop));
            return await sorgu.ToListAsync();

        }

        public Film Update(int id, Film filmSon)
        {
            _context.Update(filmSon);
            _context.SaveChanges();
            return filmSon;
        }
    }
}
