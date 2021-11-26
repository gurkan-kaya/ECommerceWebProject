using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class Oyuncu
    {
        public int OyuncuId { get; set; }
        [Display(Name="Fotoğrafı")]
        public string OyuncuFotografi { get; set; }
        [Display(Name = "Adı Soyadı")]
        public string OyuncuAdSoyad { get; set; }
        [Display(Name = "Hakkında")]
        public string OyuncuHakkinda { get; set; }

        public ICollection<FilmOyuncu> FilmlerOyuncular { get; set; }
    }
}
