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
    public class OyuncuController : Controller
    {

        private readonly IOyuncuRepository _repo;

        public OyuncuController(IOyuncuRepository repo)
        {
            _repo = repo;
        }
        public async  Task<IActionResult> Index()
        {
            var oyuncular = await _repo.ListAll();
            return View(oyuncular);
        }

        [HttpPost]
        public  IActionResult Create(IFormFile file,[Bind("OyuncuId,OyuncuFotografi,OyuncuAdSoyad,OyuncuHakkinda")] Oyuncu o)
        { 
            //Oyuncu resmini upload etmek için
            if (file!=null&&file.Length > 0)
            {
                    string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Oyuncular"));
                    using(var fileStream=new FileStream(Path.Combine(path,dosyaAdi),FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    o.OyuncuFotografi = "~/images/Oyuncular/"+ dosyaAdi;
            }

            if (ModelState.IsValid)
            {     
               
                
                    _repo.Add(o);
                    return RedirectToAction(nameof(Index));
                
            }

            return View(o);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Details(int id)
        {

            var oyuncu =  _repo.GetById(id);
                
            if (oyuncu == null)
            {
                return NotFound();
            }

            return View(oyuncu);
        }

        public  IActionResult Edit(int id)
        {

            var oyuncu = _repo.GetById(id);
            if (oyuncu == null)
            {
                return NotFound();
            }
            return View(oyuncu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("OyuncuId,OyuncuFotografi,OyuncuAdSoyad,OyuncuHakkinda")] Oyuncu o, IFormFile file)
        {
            //Oyuncu resmini upload etmek için
            if (file != null && file.Length > 0)
            {
                string dosyaAdi = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Oyuncular"));
                using (var fileStream = new FileStream(Path.Combine(path, dosyaAdi), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                o.OyuncuFotografi = "~/images/Oyuncular/" + dosyaAdi;
            }

            if (id != o.OyuncuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {               
                _repo.Update(id, o);
                
                return RedirectToAction(nameof(Index));
            }
            return View(o);
        }


        
        public IActionResult Delete(int id)
        {

            var oyuncu = _repo.GetById(id);
            if (oyuncu == null)
            {
                return NotFound();
            }

            return View(oyuncu);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            var oyuncu = _repo.GetById(id);
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
