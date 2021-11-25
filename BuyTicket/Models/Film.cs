using BuyTicket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string FilmAdi { get; set; }
        public string FilmHakkinda { get; set; }
        public DateTime FilmBaslamaSaati1 { get; set; }
        public DateTime FilmBaslamaSaati2 { get; set; }
        public DateTime FilmBaslamaSaati3 { get; set; }
        public string FilmFotografi { get; set; }
        public FilmKategorisi FilmKategorisi { get; set; }
        public float FilmUcreti { get; set; }

        public ICollection<FilmOyuncu> FilmlerOyuncular { get; set; }

        public int SinemaId { get; set; }
        [ForeignKey("SinemaId")]
        public Sinema Sinema { get; set; }

        public int YonetmenId { get; set; }
        [ForeignKey("YonetmenId")]
        public Yonetmen Yonetmen { get; set; }
    }
    
}
