using BuyTicket.Data;
using BuyTicket.Data.Repositories;
using BuyTicket.Data.Repositories.Abstract;
using BuyTicket.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BuyTicket.Controllers
{
    [Authorize]
    public class SiparisController : Controller
    {
        private readonly ISiparisRepository _siparisRepo;
        private readonly SepetRepository _sepetRepo;
        private readonly IFilmRepository _filmRepo;

        public SiparisController(ISiparisRepository siparisRepo,SepetRepository sepetRepo, IFilmRepository filmRepo)
        {
            _siparisRepo = siparisRepo;
            _sepetRepo = sepetRepo;
            _filmRepo = filmRepo;
        }


        public IActionResult Index()
        {
            //Alışveriş Sepeti Actionı
            var sepettekiler = _sepetRepo.SepeteEklenenler();
            _sepetRepo.Sepettekiler = sepettekiler;

            var svm = new SepetVM();
            svm.SepetRepo = _sepetRepo;
            svm.ToplamTutar = _sepetRepo.SepetToplamTutar();

            return View(svm);
        }

        public async Task< IActionResult> TumSiparisler()
        {
            //claim based, role based'ten farklı olarak talep bazlı bir yöntemdir.
            string kullaniciId = User.FindFirstValue(ClaimTypes.NameIdentifier); //claim type nameidentifier ile id bulunabilir
            string rol = User.FindFirstValue(ClaimTypes.Role);
            var siparisler = await _siparisRepo.SiparisleriGetir(kullaniciId,rol);
            return View(siparisler);
        }

        public RedirectToActionResult SepeteEkleArtir(int id)
        {
            var film = _filmRepo.FilmGetir(id);
            if (film != null)
            {               
                _sepetRepo.SepeteEkle(film);
            }
            return RedirectToAction(nameof(Index));
        }

        public RedirectToActionResult SepettenCikarAzalt(int id)
        {
            var film = _filmRepo.FilmGetir(id);
            if (film != null)
            {
                _sepetRepo.SepettenCikar(film);
            }
            return RedirectToAction(nameof(Index));
        }

       public async Task<IActionResult> SiparisiTamamla()
        {
            var urunler = _sepetRepo.SepeteEklenenler();
            //claim based, role based'ten farklı olarak talep bazlı bir yöntemdir.
            string kullaniciId = User.FindFirstValue(ClaimTypes.NameIdentifier); //claim type nameidentifier ile id bulunabilir
            string kullaniciEmail = User.FindFirstValue(ClaimTypes.Email);

           await _siparisRepo.SiparisiKaydet(urunler, kullaniciId, kullaniciEmail);
           await _sepetRepo.SepetiBosalt();
            return View("SiparisTamamlandi");
        }
    }
}
