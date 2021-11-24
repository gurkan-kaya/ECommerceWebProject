using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class Yonetmen
    {
        public int YonetmenId { get; set; }
        public string YonetmenFotografi { get; set; }
        public string YonetmenAdSoyad { get; set; }
        public string YonetmenHakkinda { get; set; }

        public ICollection<Film> Filmler { get; set; }
    }
}
