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
    public class WriterController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public WriterController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Writers.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Writer writer)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Writers.Add(writer);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(writer);
        }
        public IActionResult Update(int? id)
        {
            Writer writer = null;

            if (id != null)
            {
                writer = _appDbContext.Writers.Find(id);
            }
            else
            {
                return RedirectToAction("Index","Error");
            }

            return View(writer);
        }
        [HttpPost]
        public IActionResult Update(Writer writer)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Writers.Update(writer);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(writer);
        }
        public IActionResult Delete(int? id)
        {
            Writer writer = null;
            if (id != null)
            {
                writer = _appDbContext.Writers.Find(id);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            if (writer != null)
            {
                _appDbContext.Writers.Remove(writer);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();

        }
    }
}
