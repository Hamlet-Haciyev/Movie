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
    public class TagController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public TagController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Tags.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Tags.Add(tag);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tag);
        }
        public IActionResult Update(int? id)
        {
            Tag tag = null;

            if (id != null)
            {
                tag = _appDbContext.Tags.Find(id);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            return View(tag);
        }
        [HttpPost]
        public IActionResult Update(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Tags.Update(tag);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tag);
        }
        public IActionResult Delete(int? id)
        {
            Tag tag = null;

            if (id != null)
            {
                tag = _appDbContext.Tags.Find(id);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            if (tag != null)
            {
                _appDbContext.Tags.Remove(tag);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
