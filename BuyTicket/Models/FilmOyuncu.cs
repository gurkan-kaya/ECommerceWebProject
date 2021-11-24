using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class FilmOyuncu
    {
        /*Bir filmde birçok oyuncu olabilir,
         bir oyuncu birçok filmde oynayabilir,
        many to many ilişkisini gerçekleyebilmek için bu class oluşturuldu.*/


        public int OyuncuId  { get; set; }
        public int FilmId { get; set; }

        public Oyuncu Oyuncu { get; set; }
        public Film Film { get; set; }

    }
}
