using BuyTicket.Data;
using BuyTicket.Data.Repositories.Abstract;
using BuyTicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Controllers
{
    [Authorize(Roles =Roller.Admin)]
    public class FilmController : Controller
    {
        private readonly IFilmRepository _repo;
        public FilmController(IFilmRepository repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var filmler = await _repo.ListAll(m => m.Sinema);
            return View(filmler);
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {

            var film = _repo.FilmGetir(id);

            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            //film eklenirken seçilmesi gereken sinema,oyuncu,yönetmen listeleri
            var filmVerileri = await _repo.FilmVerileri();
            ViewData["SinemaId"] = new SelectList(filmVerileri.Sinemalar, "SinemaId", "SinemaAdi");
            ViewData["OyuncuId"] = new SelectList(filmVerileri.Oyuncular, "OyuncuId", "OyuncuAdSoyad");
            ViewData["YonetmenId"] = new SelectList(filmVerileri.Yonetmenler, "YonetmenId", "YonetmenAdSoyad");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, FilmVM film)
        {
            var filmVerileri = await _repo.FilmVerileri();
            ViewData["SinemaId"] = new SelectList(filmVerileri.Sinemalar, "SinemaId", "SinemaAdi");
            ViewData["OyuncuId"] = new SelectList(filmVerileri.Oyuncular, "OyuncuId", "OyuncuAdSoyad");
            ViewData["YonetmenId"] = new SelectList(filmVerileri.Yonetmenler, "YonetmenId", "YonetmenAdSoyad");


            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Filmler"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
               film.FilmFotografi = "~/images/Filmler/" + dosyaAdi;
            }

            if (ModelState.IsValid)
            {

                await _repo.FilmEkle(film);

                return RedirectToAction(nameof(Index));
            }
            
            return View(film);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var film =  _repo.FilmGetir(id);

            var filmSon = new FilmVM();
            filmSon.FilmId = film.FilmId;
            filmSon.FilmAdi = film.FilmAdi;
            filmSon.FilmBaslamaSaati1 = film.FilmBaslamaSaati1;
            filmSon.FilmBaslamaSaati2 = film.FilmBaslamaSaati2;
            filmSon.FilmBaslamaSaati3 = film.FilmBaslamaSaati3;
            filmSon.FilmFotografi = film.FilmFotografi;
            filmSon.FilmHakkinda = film.FilmHakkinda;
            filmSon.FilmKategorisi = film.FilmKategorisi;
            filmSon.FilmUcreti = film.FilmUcreti;
            filmSon.OyuncuListesi = film.FilmlerOyuncular.Select(m => m.OyuncuId).ToList();
            filmSon.SinemaId = film.SinemaId;
            filmSon.YonetmenId = film.YonetmenId;


            var filmVerileri = await _repo.FilmVerileri();
            ViewData["SinemaId"] = new SelectList(filmVerileri.Sinemalar, "SinemaId", "SinemaAdi");
            ViewData["OyuncuId"] = new SelectList(filmVerileri.Oyuncular, "OyuncuId", "OyuncuAdSoyad");
            ViewData["YonetmenId"] = new SelectList(filmVerileri.Yonetmenler, "YonetmenId", "YonetmenAdSoyad");
            return View(filmSon);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile file, FilmVM film, int id)
        {
            var filmVerileri = await _repo.FilmVerileri();
            ViewData["SinemaId"] = new SelectList(filmVerileri.Sinemalar, "SinemaId", "SinemaAdi");
            ViewData["OyuncuId"] = new SelectList(filmVerileri.Oyuncular, "OyuncuId", "OyuncuAdSoyad");
            ViewData["YonetmenId"] = new SelectList(filmVerileri.Yonetmenler, "YonetmenId", "YonetmenAdSoyad");


            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Filmler"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                film.FilmFotografi = "~/images/Filmler/" + dosyaAdi;
            }

            if (ModelState.IsValid)
            {

                await _repo.FilmGuncelle(film);

                return RedirectToAction(nameof(Index));
            }

            return View(film);
        }

        public IActionResult Delete(int id)
        {
            var film = _repo.FilmGetir(id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);

        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var film = _repo.GetById(id);
            _repo.Delete(id); //id'ye göre bulunan filmi, filmrepository'deki delete metodunun içindeki remove'a vererek silme işlemi gerçekleştirir. 
            return RedirectToAction(nameof(Index));

        }

        [AllowAnonymous]
        public async Task<IActionResult> AramaSonucu(string arananFilm)
        {
            var filmler = await  _repo.ListAll(m => m.Sinema);
            if (string.IsNullOrEmpty(arananFilm) == true) 
                return View("Index", filmler);


             var sonuc = filmler.Where(m => m.FilmAdi.Contains(arananFilm)).ToList();
            return View("Index", sonuc);
        }

    }




}
