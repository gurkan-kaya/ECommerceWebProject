using BuyTicket.Data;
using BuyTicket.Data.Repositories.Abstract;
using BuyTicket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Controllers
{
    public class SinemaController : Controller
    {
        private readonly ISinemaRepository _repo;
        public SinemaController(ISinemaRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var sinemalar = await _repo.ListAll();
            return View(sinemalar);
        }


        [HttpPost]
        public IActionResult Create(IFormFile file, [Bind("SinemaId,SinemaFotografi,SinemaAdi,SinemaHakkinda")] Sinema s)
        {
            //Sinema resmini upload etmek için
            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Sinemalar"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                s.SinemaFotografi = "~/images/Sinemalar/" + dosyaAdi;
            }

            if (ModelState.IsValid)
            {


                _repo.Add(s);
                return RedirectToAction(nameof(Index));

            }

            return View(s);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Details(int id)
        {

            var sinema = _repo.GetById(id);

            if (sinema == null)
            {
                return NotFound();
            }

            return View(sinema);
        }


        public IActionResult Edit(int id)
        {

            var sinema = _repo.GetById(id);
            if (sinema == null)
            {
                return NotFound();
            }
            return View(sinema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("SinemaId,SinemaFotografi,SinemaAdi,SinemaHakkinda")] Sinema s, IFormFile file)
        {
            //Sinema resmini upload etmek için
            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Sinemalar"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                s.SinemaFotografi = "~/images/Sinemalar/" + dosyaAdi;
            }

            if (id != s.SinemaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repo.Update(id, s);

                return RedirectToAction(nameof(Index));
            }
            return View(s);
        }


        public IActionResult Delete(int id)
        {

            var sinema = _repo.GetById(id);
            if (sinema == null)
            {
                return NotFound();
            }

            return View(sinema);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sinema = _repo.GetById(id);
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
