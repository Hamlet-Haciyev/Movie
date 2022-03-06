using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Areas.admin.Controllers
{
    [Area("admin")]
    public class CastSocialController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CastSocialController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<CastToSocial> castToSocials = _appDbContext.CastToSocials
                                                                           .Include(cs=>cs.SocialMedia)
                                                                           .Include(c=>c.Cast)
                                                                           .ToList();
            return View(castToSocials);
        }
        public IActionResult Create()
        {
            ViewBag.Casts = _appDbContext.Casts.ToList();
            ViewBag.SocialMedia = _appDbContext.SocialMedias.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Create(CastToSocial castToSocial)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.CastToSocials.Add(castToSocial);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Casts = _appDbContext.Casts.ToList();
            ViewBag.SocialMedia = _appDbContext.SocialMedias.ToList();
            return View(castToSocial);
        }
        public IActionResult Update(int? id)
        {
            CastToSocial castToSocial = null;

            if (id != null)
            {
                castToSocial = _appDbContext.CastToSocials.Find(id);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            return View(castToSocial);
        }
        [HttpPost]
        public IActionResult Update(CastToSocial castToSocial)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.CastToSocials.Update(castToSocial);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(castToSocial);
        }
        public IActionResult Delete(int? id)
        {
            CastToSocial castToSocial = null;

            if (id != null)
            {
                castToSocial = _appDbContext.CastToSocials.Find(id);
            }
            else
            {
                return RedirectToAction("Index","Error");
            }

            if (castToSocial != null)
            {
                _appDbContext.CastToSocials.Remove(castToSocial);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
