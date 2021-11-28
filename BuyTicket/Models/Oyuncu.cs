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
        //[Required(ErrorMessage ="Lütfen fotoğraf seçiniz")]
        [Display(Name="Fotoğrafı")]
        public string OyuncuFotografi { get; set; }

        [Required(ErrorMessage = "Lütfen isim giriniz")]
        [StringLength(30,MinimumLength = 5,ErrorMessage ="Ad Soyad 5-30 karakter arasında olmalıdır.")]
        [Display(Name = "Adı Soyadı")]
        public string OyuncuAdSoyad { get; set; }

        [Required(ErrorMessage = "Lütfen hakkında alanını doldurunuz")]
        [Display(Name = "Hakkında")]
        [StringLength(1000,MinimumLength = 5,  ErrorMessage = "Hakkında alanı 5-1000 karakter arasında olmalıdır.")]
        public string OyuncuHakkinda { get; set; }

        public ICollection<FilmOyuncu> FilmlerOyuncular { get; set; }
    }
}
