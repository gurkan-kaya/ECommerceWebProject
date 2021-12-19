using BuyTicket.Models;
using BuyTicket.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BuyTicket.Data.Repositories.Abstract
{
    public interface IFilmRepository
    {
        Film GetById(int id);
        void Add(Film film);
        void Delete(int id);
        Film Update(int id, Film filmSon);
        Task<IEnumerable<Film>> ListAll();
        Task<IEnumerable<Film>> ListAll(params Expression<Func<Film, object>>[] i);
        Task<FilmVeriLists> FilmVerileri();
        Task FilmEkle(FilmVM fvm);
        Task FilmGuncelle(FilmVM fvm);
        Film FilmGetir(int id);
    
    }
}
