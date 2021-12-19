using BuyTicket.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Data
{
    public class BiletDbContext:IdentityDbContext<Kullanici>
    {
        public BiletDbContext(DbContextOptions<BiletDbContext> options)
            : base(options)
        {

        }

        //Film ve Oyuncu arasındaki ilişki many to many olduğundan FilmOyuncu adında bir tablomuz daha olacak. Bunun konfigürasyonu ise fluent api kullanılarak aşağıdaki gibi yapılır.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmOyuncu>().HasKey(fo => new { fo.OyuncuId , fo.FilmId });

            modelBuilder.Entity<FilmOyuncu>().HasOne(m => m.Film).WithMany(fo => fo.FilmlerOyuncular).HasForeignKey(m => m.FilmId);
            modelBuilder.Entity<FilmOyuncu>().HasOne(m => m.Oyuncu).WithMany(fo => fo.FilmlerOyuncular).HasForeignKey(m => m.OyuncuId);

            base.OnModelCreating(modelBuilder);
        }

        
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Oyuncu> Oyuncular { get; set; }
        public DbSet<Sinema> Sinemalar { get; set; }
        public DbSet<Yonetmen> Yonetmenler { get; set; }    
        public DbSet<FilmOyuncu> FilmlerOyuncular { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisFilm> SiparisFilmler { get; set; }

        //sepetler->sepettekileri tutuyor
        public DbSet<Sepet> Sepetler { get; set; }

    }
}
