using BuyTicket.Data;
using BuyTicket.Data.Abstract;
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
    public class YonetmenController : Controller
    {
        private readonly IYonetmenRepository _repo;

        public YonetmenController(IYonetmenRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var yonetmenler = await _repo.ListAll(); ;
            return View(yonetmenler);

        }

        [HttpPost]
        public IActionResult Create(IFormFile file, [Bind("YonetmenId,YonetmenFotografi,YonetmenAdSoyad,YonetmenHakkinda")] Yonetmen y)
        {
            //Yonetmen resmini upload etmek için
            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Yonetmenler"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                y.YonetmenFotografi = "~/images/Yonetmenler/" + dosyaAdi;
            }

            if (ModelState.IsValid)
            {


                _repo.Add(y);
                return RedirectToAction(nameof(Index));

            }

            return View(y);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Details(int id)
        {

            var yonetmen = _repo.GetById(id);

            if (yonetmen == null)
            {
                return NotFound();
            }

            return View(yonetmen);
        }

        public IActionResult Edit(int id)
        {

            var yonetmen = _repo.GetById(id);
            if (yonetmen == null)
            {
                return NotFound();
            }
            return View(yonetmen);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("YonetmenId,YonetmenFotografi,YonetmenAdSoyad,YonetmenHakkinda")] Yonetmen y, IFormFile file)
        {
            //Yonetmen resmini upload etmek için
            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Yonetmenler"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
               y.YonetmenFotografi = "~/images/Yonetmenler/" + dosyaAdi;
            }

            if (id != y.YonetmenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repo.Update(id, y);

                return RedirectToAction(nameof(Index));
            }
            return View(y);
        }

        public IActionResult Delete(int id)
        {

            var yonetmen = _repo.GetById(id);
            if (yonetmen == null)
            {
                return NotFound();
            }

            return View(yonetmen);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var yonetmen = _repo.GetById(id);
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
