using BuyTicket.Data;
using BuyTicket.Models;
using BuyTicket.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicket.Controllers
{
    public class AccountController : Controller
    {
        private readonly BiletDbContext _context;
        private readonly UserManager<Kullanici> _userman;
        private readonly SignInManager<Kullanici> _signinman;

        public AccountController(BiletDbContext context, UserManager<Kullanici> userman, SignInManager<Kullanici> signinman)
        {
            _context = context;
            _userman = userman;
            _signinman = signinman;
        }

        public IActionResult Login()
        {
            var data = new GirisVM();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Login(GirisVM giris)
        {
            if (ModelState.IsValid)
            {
                var kullanici = await _userman.FindByEmailAsync(giris.Email);
                if (kullanici != null)
                {
                    var sifreKontrol = await _userman.CheckPasswordAsync(kullanici, giris.Sifre);
                    if (sifreKontrol)
                    {
                        var yonlendir = await _signinman.PasswordSignInAsync(kullanici, giris.Sifre, false, false);
                        if (yonlendir.Succeeded)
                        {
                            return RedirectToAction("Index", "Film");
                        }
                    }
                    ViewBag.error = "Bilgilerinizi kontrol edip tekrar deneyiniz!";
                    return View(giris);
                }
                ViewBag.error = "Bilgilerinizi kontrol edip tekrar deneyiniz!";
                return View(giris);
            }

            return View(giris);
        }


        public IActionResult Uyelik()
        {
            var data = new UyelikVM();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Uyelik(UyelikVM uyelik)
        {
            if (ModelState.IsValid)
            {
                var kullanici = await _userman.FindByEmailAsync(uyelik.Email);
                if (kullanici != null)
                {
                    ViewBag.error = "Bu E-Posta Adresi kullanımda!";
                    return View(uyelik);

                }

                var yeniUye = new Kullanici()
                {
                    AdSoyad = uyelik.AdSoyad,
                    // UserName = uyelik.AdSoyad.ToLower().Trim(' ',''),
                    UserName = String.Concat(uyelik.AdSoyad.Where(c => !Char.IsWhiteSpace(c))).ToLower(),
                    Email = uyelik.Email

                };
                var yeniUyeEkle = await _userman.CreateAsync(yeniUye, uyelik.Sifre);
                if (yeniUyeEkle.Succeeded)
                {
                    await _userman.AddToRoleAsync(yeniUye, Roller.Kullanici);
                    return View("UyelikTamamlandi");
                }

            }

            return View(uyelik);
        }

        public async Task<IActionResult> Cikis()
        {
            await _signinman.SignOutAsync();
            return RedirectToAction("Index", "Film");
        }

        public async Task<IActionResult> TumKullanicilar()
        {
            var tumkullanicilar = await _context.Users.ToListAsync();
            return View(tumkullanicilar);
        }

        public IActionResult AccessDenied(string url)
        {
           
            return View();
        }
    }
}
