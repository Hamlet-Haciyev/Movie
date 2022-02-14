using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Areas.admin.Controllers
{
    [Area("admin")]
    public class CastController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CastController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Casts.Include(b => b.CastToSocials).ThenInclude(cs => cs.SocialMedia).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Gender = _appDbContext.Genders.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cast cast)
        {
            if (ModelState.IsValid)
            {
                if (cast.ImageFile != null)
                {
                    if (cast.ImageFile.ContentType == "image/png" || cast.ImageFile.ContentType == "image/jpeg")
                    {
                        if (cast.ImageFile.Length <= 2097152)
                        {

                            string filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + cast.ImageFile.FileName;
                            string pathname = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", filename);
                            using (var fs = new FileStream(pathname, FileMode.Create))
                            {
                                cast.ImageFile.CopyTo(fs);
                            }
                            cast.Image = filename;
                            

                            _appDbContext.Casts.Add(cast);
                            _appDbContext.SaveChanges();

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Gender = _appDbContext.Genders.ToList();
                            ModelState.AddModelError("", "Picture must be then less 2mb");
                            return View(cast);
                        }
                    }
                    else
                    {
                        ViewBag.Gender = _appDbContext.Genders.ToList();
                        ModelState.AddModelError("", "Picture must be png or jpeg format");
                        return View(cast);
                    }
                }
                else
                {
                    _appDbContext.Casts.Add(cast);
                    _appDbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            ViewBag.Gender = _appDbContext.Genders.ToList();
            return View(cast);
        }
        public IActionResult Update(int? id)
        {
            Cast cast = null;

            if (id != null)
            {
                cast = _appDbContext.Casts.Include(b => b.CastToSocials).ThenInclude(bt => bt.SocialMedia).FirstOrDefault(s => s.Id == id);
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", cast.Image);
                if (System.IO.File.Exists(path))
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(path);

                    MemoryStream stream = new MemoryStream(bytes);

                    IFormFile file = new FormFile(stream, 0, bytes.Length, "image", "image.png");

                    cast.ImageFile = file;

                    using (var str = new MemoryStream())
                    {
                        cast.ImageFile.CopyTo(str);
                        var filebytes = str.ToArray();
                        cast.base64 = Convert.ToBase64String(filebytes);
                    }
                }
                ViewBag.SocialMedias = _appDbContext.SocialMedias.ToList();
                cast.SocialMediaIds = _appDbContext.CastToSocials.Where(t => t.CastId == id).Select(r => r.SocialMediaId).ToList();
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            return View(cast);
        }
        [HttpPost]
        public IActionResult Update(Cast cast)
        {
            if (ModelState.IsValid)
            {
                if (cast.ImageFile != null)
                {
                    if (cast.ImageFile.ContentType == "image/png" || cast.ImageFile.ContentType == "image/jpeg")
                    {
                        if (cast.ImageFile.Length <= 2097152)
                        {
                            string oldPathData = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", cast.Image);

                            if (System.IO.File.Exists(oldPathData))
                            {
                                System.IO.File.Delete(oldPathData);
                            }

                            string filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + cast.ImageFile.FileName;
                            string pathname = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", filename);
                            using (var fs = new FileStream(pathname, FileMode.Create))
                            {
                                cast.ImageFile.CopyTo(fs);

                            }
                            cast.Image = filename;

                            _appDbContext.Entry(cast).State = EntityState.Modified;
                            _appDbContext.Entry(cast).Property("BirthDay").IsModified = false;
                            _appDbContext.Entry(cast).Property("GenderId").IsModified = false;

                            _appDbContext.SaveChanges();

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Picture must be then less 2mb");
                            return View(cast);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Picture must be png or jpeg format");
                        return View(cast);
                    }
                }
                else
                {
                    _appDbContext.Entry(cast).State = EntityState.Modified;
                    _appDbContext.Entry(cast).Property("BirthDay").IsModified = false;
                    _appDbContext.Entry(cast).Property("GenderId").IsModified = false;
                    _appDbContext.SaveChanges();

                    return RedirectToAction("Index");
                }

            }

            return View(cast);
        }
        public IActionResult Delete(int? id)
        {
            Cast cast = null;

            if (id != null)
            {
                cast = _appDbContext.Casts.FirstOrDefault(s => s.Id == id);
            }

            if (cast != null)
            {
                if (!string.IsNullOrEmpty(cast.Image))
                {
                    string oldPathFile = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", cast.Image);

                    if (System.IO.File.Exists(oldPathFile))
                    {
                        System.IO.File.Delete(oldPathFile);
                    }
                    _appDbContext.Casts.Remove(cast);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    _appDbContext.Casts.Remove(cast);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Blog is not found");
            return RedirectToAction("Index");
        }
    }
}
