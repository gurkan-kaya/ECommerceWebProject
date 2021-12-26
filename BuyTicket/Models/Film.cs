using BuyTicket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class Film
    {
        public int FilmId { get; set; }

        [Display(Name = "Film Adı")]
        public string FilmAdi { get; set; }

        [Display(Name = "Film Hakkında")]
        [StringLength(10000,MinimumLength =100,ErrorMessage ="Film Açıklaması 100-10000 karakter arasında olmalıdır")]
        public string FilmHakkinda { get; set; }

        [Display(Name ="Film Seans Saatleri")]
        public string FilmBaslamaSaati1 { get; set; }
        public string FilmBaslamaSaati2 { get; set; }
        public string FilmBaslamaSaati3 { get; set; }

        [Display(Name = "Film Fotoğrafı")]
        public string FilmFotografi { get; set; }

        [Display(Name = "Film Türü")]
        public FilmKategorisi FilmKategorisi { get; set; }

        [Display(Name = "Film Ücreti")]
        public float FilmUcreti { get; set; }

        [Display(Name = "Film Oyuncuları")]
        public ICollection<FilmOyuncu> FilmlerOyuncular { get; set; }

        public int SinemaId { get; set; }
        [ForeignKey("SinemaId")]
        [Display(Name = "Sinema Adı")]
        public Sinema Sinema { get; set; }

        public int YonetmenId { get; set; }

        [Display(Name = "Yönetmen Adı")]
        [ForeignKey("YonetmenId")]
        public Yonetmen Yonetmen { get; set; }
    }
    
}
