using BuyTicket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string FilmAdi { get; set; }
        public string FilmHakkinda { get; set; }
        public DateTime FilmBaslamaSaati { get; set; }
        public DateTime FilmBitisSaati { get; set; }
        public string FilmFotografi { get; set; }
        public FilmKategorisi FilmKategorisi { get; set; }
        public string FilmUcreti { get; set; }


    }
    
}
