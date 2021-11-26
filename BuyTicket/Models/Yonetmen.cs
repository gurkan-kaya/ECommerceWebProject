using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class Yonetmen
    {
        public int YonetmenId { get; set; }
        [Display(Name=" Fotoğrafı")]
        public string YonetmenFotografi { get; set; }
        [Display(Name = "Adı Soyadı")]
        public string YonetmenAdSoyad { get; set; }
        [Display(Name = "Hakkında")]
        public string YonetmenHakkinda { get; set; }

        public ICollection<Film> Filmler { get; set; }
    }
}
