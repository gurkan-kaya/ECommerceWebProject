using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class Sepet
    {
        public int SepetId { get; set; }
        public int Adet { get; set; }
        public Film Film { get; set; }

        //Alışveriş tamamlandığında sepetin boşaltılması gerekecek, bunun için aşağıdaki şekilde ID'yi tuttum.
        public string SepetNo { get; set; }
    }
}
