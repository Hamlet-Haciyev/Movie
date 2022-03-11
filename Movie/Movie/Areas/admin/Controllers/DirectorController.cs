using Microsoft.AspNetCore.Authorization;
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
    public class DirectorController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public DirectorController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [Authorize(Roles ="SuperAdmin, Admin, Moderator")]
        public IActionResult Index()
        {
            return View(_appDbContext.Directors.ToList());
        }
        [Authorize(Roles ="SuperAdmin, Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Director director)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Directors.Add(director);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(director);
        }
        [Authorize(Roles ="SuperAdmin, Admin")]
        public IActionResult Update(int? id)
        {
            Director director = null;

            if (id != null)
            {
                director = _appDbContext.Directors.Find(id);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            return View(director);
        }
        [HttpPost]
        public IActionResult Update(Director director)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Directors.Update(director);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(director);
        }
        [Authorize(Roles ="SuperAdmin")]
        public IActionResult Delete(int? id)
        {
            Director director = null;

            if (id != null)
            {
                director = _appDbContext.Directors.Find(id);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            if (director != null)
            {
                _appDbContext.Directors.Remove(director);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
