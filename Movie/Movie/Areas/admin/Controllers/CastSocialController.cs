using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles ="SuperAdmin, Admin, Moderator")]
        public IActionResult Index()
        {
            List<CastToSocial> castToSocials = _appDbContext.CastToSocials
                                                                           .Include(cs=>cs.SocialMedia)
                                                                           .Include(c=>c.Cast)
                                                                           .ToList();
            return View(castToSocials);
        }
        [Authorize(Roles = "SuperAdmin, Admin")]
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
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Update(int? id)
        {
            CastToSocial castToSocial = null;

            if (id != null)
            {
                ViewBag.Casts = _appDbContext.Casts.ToList();
                ViewBag.SocialMedia = _appDbContext.SocialMedias.ToList();
                castToSocial =  await _appDbContext.CastToSocials
                                                    .Include(cs=>cs.SocialMedia)
                                                    .Include(cs=>cs.Cast)
                                                    .FirstOrDefaultAsync(cs=>cs.Id == id);
                castToSocial.CastId =  _appDbContext.CastToSocials.Where(cs=>cs.Id == id).Select(cs=>cs.CastId).FirstOrDefault();
                castToSocial.SocialMediaId = _appDbContext.CastToSocials.Where(cs => cs.Id == id).Select(cs => cs.SocialMediaId).FirstOrDefault();
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
        [Authorize(Roles = "SuperAdmin")]
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
                try
                {
                    _appDbContext.CastToSocials.Remove(castToSocial);
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
