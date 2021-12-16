using BuyTicket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class FilmVM
    {
        //Film mıodelinin create işlemi için bir viewmodel oluşturuldu

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
        /*Film modelimizde alttaki collection FilmOyuncu tipinde idi. Ancak many to many ilişkide ara tabloyla ilgili işlemleri yapabilmek için
         * bu listenin tipini int olarak değiştirdim ve View'de dseçilen ıyunvuların ID'lerinin tutulmasını sağladım.
         */
        public ICollection<int> OyuncuListesi { get; set; }

        public int SinemaId { get; set; }
        public int YonetmenId { get; set; }

    }
    
}
