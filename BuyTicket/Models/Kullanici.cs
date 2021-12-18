using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models
{
    public class Kullanici:IdentityUser
    {
        [Display(Name="Ad Soyad")]
        public string AdSoyad { get; set; }
    }
}
