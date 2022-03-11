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
    public class GenderController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public GenderController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [Authorize(Roles ="SuperAdmin, Admin, Moderator")]
        public IActionResult Index()
        {
            return View(_appDbContext.Genders.ToList());
        }
        [Authorize(Roles ="SuperAdmin, Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Gender gender)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Genders.Add(gender);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gender);
        }
        [Authorize(Roles ="SuperAdmin, Admin")]
        public IActionResult Update(int? id)
        {
            Gender gender = null;

            if (id != null)
            {
                gender = _appDbContext.Genders.Find(id);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            return View(gender);
        }
        [HttpPost]
        public IActionResult Update(Gender gender)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Genders.Update(gender);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gender);
        }
        [Authorize(Roles ="SuperAdmin")]
        public IActionResult Delete(int? id)
        {
            Gender gender = null;

            if (id != null)
            {
                gender = _appDbContext.Genders.Find(id);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            if (gender != null)
            {
                try
                {
                    _appDbContext.Genders.Remove(gender);
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
