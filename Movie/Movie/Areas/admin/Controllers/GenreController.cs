using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Areas.admin.Controllers
{
    [Area("admin")]
    public class GenreController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public GenreController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Genres.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Genres.Add(genre);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }
        public IActionResult Update(int? id)
        {
            Genre genre = null;

            if (id != null)
            {
                genre = _appDbContext.Genres.Find(id);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            return View(genre);
        }
        [HttpPost]
        public IActionResult Update(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Genres.Update(genre);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }
        public IActionResult Delete(int? id)
        {
            Genre genre = null;

            if (id != null)
            {
                genre = _appDbContext.Genres.Find(id);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            if (genre != null)
            {
                try
                {
                    _appDbContext.Genres.Remove(genre);
                    _appDbContext.SaveChanges();
                    return Json(new
                    {
                        code = 204,
                        message = "Item has been deleted successfully!"
                    });
                }
                catch (Exception)
                {
                    return Json(new
                    {
                        code = 500,
                        message = "Something went wrong!"
                    });
                }
            }

            return View();

        }
    }
}
