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
    public class TagController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public TagController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [Authorize(Roles ="SuperAdmin, Admin, Moderator")]
        public IActionResult Index()
        {
            return View(_appDbContext.Tags.ToList());
        }
        [Authorize(Roles ="SuperAdmin, Admin")]
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
        [Authorize(Roles ="SuperAdmin, Admin")]
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
        [Authorize(Roles = "SuperAdmin")]
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
                try
                {
                    _appDbContext.Tags.Remove(tag);
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
