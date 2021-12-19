using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class SiparisFilm
    {
        public int SiparisFilmId { get; set; }
        public float Fiyat { get; set; }
        public int Adet { get; set; }

        public int FilmId { get; set; }
        [ForeignKey("FilmId")]
        public Film Film { get; set; }

        public int SiparisId { get; set; }
        [ForeignKey("SiparisId")]
        public Siparis Siparis { get; set; }
    }
}
