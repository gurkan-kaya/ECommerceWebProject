using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class Sinema
    {
        public int SinemaId { get; set; }
        [Display(Name = "Sinema Fotoğrafı")]
        public string SinemaFotografi { get; set; }
        [Display(Name = "Sinema Adı")]
        public string SinemaAdi { get; set; }
        [Display(Name = "Sinema Hakkında")]
        public string SinemaHakkinda { get; set; }

        public ICollection<Film> Filmler { get; set; }
    }
}
