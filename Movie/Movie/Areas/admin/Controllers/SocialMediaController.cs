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
    public class SocialMediaController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public SocialMediaController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.SocialMedias.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.SocialMedias.Add(socialMedia);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialMedia);
        }
        public IActionResult Update(int? id)
        {
            SocialMedia socialMedia = null;

            if (id != null)
            {
                socialMedia = _appDbContext.SocialMedias.Find(id);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            return View(socialMedia);
        }
        [HttpPost]
        public IActionResult Update(SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.SocialMedias.Update(socialMedia);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialMedia);
        }
        public IActionResult Delete(int? id)
        {
            SocialMedia socialMedia = null;

            if (id != null)
            {
                socialMedia = _appDbContext.SocialMedias.Find(id);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            if (socialMedia != null)
            {
                _appDbContext.SocialMedias.Remove(socialMedia);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
