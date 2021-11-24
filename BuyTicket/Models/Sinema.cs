using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class Sinema
    {
        public int SinemaId { get; set; }
        public string SinemaFotografi { get; set; }
        public string SinemaAdi { get; set; }
        public string SinemaHakkinda { get; set; }

        public ICollection<Film> Filmler { get; set; }
    }
}
