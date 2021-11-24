using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class Oyuncu
    {
        public int OyuncuId { get; set; }
        public string OyuncuFotografi { get; set; }
        public string OyuncuAdSoyad { get; set; }
        public string OyuncuHakkinda { get; set; }

        public ICollection<FilmOyuncu> FilmlerOyuncular { get; set; }
    }
}
