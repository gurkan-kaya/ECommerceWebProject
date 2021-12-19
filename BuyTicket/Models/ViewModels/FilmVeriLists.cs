using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models.ViewModels
{
    public class FilmVeriLists
    {
        public FilmVeriLists()
        {
            Oyuncular = new List<Oyuncu>();
            Yonetmenler = new List<Yonetmen>();
            Sinemalar = new List<Sinema>();
        }

        public List<Oyuncu> Oyuncular { get; set; }
        public List<Yonetmen> Yonetmenler { get; set; }
        public List<Sinema> Sinemalar { get; set; }
    }
}
