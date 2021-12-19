using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Models.ViewModels
{
    public class UyelikVM
    {
        [Required]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; }

        [Required]
        [Display(Name = "E-posta Adresi")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]       
        public string Sifre { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Sifre",ErrorMessage ="Şifreler eşleşmiyor!")]
        public string SifreTekrar { get; set; }
    }
}
