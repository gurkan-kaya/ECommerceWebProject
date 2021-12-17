using BuyTicket.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models.ViewModels
{
    public class SepetVM
    {
        public double ToplamTutar { get; set; }
        public SepetRepository SepetRepo { get; set; }
    }

}
