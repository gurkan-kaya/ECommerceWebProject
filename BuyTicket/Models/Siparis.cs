using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class Siparis
    {
        public int SiparisId { get; set; }
        public string KullaniciEmail { get; set; }
        public string KullaniciId { get; set; }

        [ForeignKey(nameof(KullaniciId))]
        public Kullanici Kullanici { get; set; }
        public ICollection<SiparisFilm> SiparisFilmler { get; set; }
    }
}
