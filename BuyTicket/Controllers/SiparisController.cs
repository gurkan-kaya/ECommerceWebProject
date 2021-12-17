using BuyTicket.Data.Repositories;
using BuyTicket.Data.Repositories.Abstract;
using BuyTicket.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Controllers
{
    public class SiparisController : Controller
    {
        private readonly SepetRepository _sepetRepo;
        private readonly IFilmRepository _filmRepo;

        public SiparisController(SepetRepository sepetRepo, IFilmRepository filmRepo)
        {
            _sepetRepo = sepetRepo;
            _filmRepo = filmRepo;
        }

        public IActionResult Index()
        {
            var sepettekiler = _sepetRepo.SepeteEklenenler();
            _sepetRepo.Sepettekiler = sepettekiler;

            var svm = new SepetVM();
            svm.SepetRepo = _sepetRepo;
            svm.ToplamTutar = _sepetRepo.SepetToplamTutar();

            return View(svm);
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
    }
}
