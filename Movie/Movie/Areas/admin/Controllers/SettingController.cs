using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models;
using Movie.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Areas.admin.Controllers
{
    [Area("admin")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SettingController(AppDbContext appDbContext,IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Index()
        {
            return View(_appDbContext.Settings.FirstOrDefault());
        }
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Setting setting)
        {
            if (ModelState.IsValid)
            {
                if (setting.LogoFile != null)
                {
                    if (setting.LogoFile.ContentType == "image/png" || setting.LogoFile.ContentType == "image/jpeg")
                    {
                        if (setting.LogoFile.Length <= 2097152)
                        {

                            string filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + setting.LogoFile.FileName;
                            string pathname = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", filename);
                            using (var fs = new FileStream(pathname, FileMode.Create))
                            {
                                setting.LogoFile.CopyTo(fs);
                            }
                            setting.Logo = filename;

                            _appDbContext.Settings.Add(setting);
                            _appDbContext.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Picture must be then less 2mb");
                            return View(setting);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Picture must be png or jpeg format");
                        return View(setting);
                    }
                }
                else
                {
                    _appDbContext.Settings.Add(setting);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(setting);
        }
        [Authorize(Roles ="SuperAdmin")]
        public IActionResult Update(int? id)
        {
            Setting setting = null;

            if (id != null)
            {
                setting = _appDbContext.Settings.FirstOrDefault(s => s.Id == id);
                if (!string.IsNullOrEmpty(setting.Logo))
                {
                    string path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", setting.Logo);
                    if (System.IO.File.Exists(path))
                    {
                        byte[] bytes = System.IO.File.ReadAllBytes(path);

                        MemoryStream stream = new MemoryStream(bytes);

                        IFormFile file = new FormFile(stream, 0, bytes.Length, "image", "image.png");

                        setting.LogoFile = file;

                        using (var str = new MemoryStream())
                        {
                            setting.LogoFile.CopyTo(str);
                            var filebytes = str.ToArray();
                            setting.base64 = Convert.ToBase64String(filebytes);
                        }
                    }
                }
            }

            return View(setting);
        }
        [HttpPost]
        public IActionResult Update(Setting setting)
        {
            if (ModelState.IsValid)
            {
                if (setting.LogoFile != null)
                {
                    if (setting.LogoFile.ContentType == "image/png" || setting.LogoFile.ContentType == "image/jpeg")
                    {
                        if (setting.LogoFile.Length <= 2097152)
                        {
                            string oldPathData = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", setting.Logo);

                            if (System.IO.File.Exists(oldPathData))
                            {
                                System.IO.File.Delete(oldPathData);
                            }

                            string filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + setting.LogoFile.FileName;
                            string pathname = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", filename);
                            using (var fs = new FileStream(pathname, FileMode.Create))
                            {
                                setting.LogoFile.CopyTo(fs);
                            }
                            setting.Logo = filename;

                            _appDbContext.Settings.Update(setting);
                            _appDbContext.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Picture must be then less 2mb");
                            return View(setting);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Picture must be png or jpeg format");
                        return View(setting);
                    }
                }
                else
                {
                    _appDbContext.Settings.Update(setting);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

            }

            return View(setting);
        }
        [Authorize(Roles ="SuperAdmin")]
        public IActionResult Delete(int? id)
        {
            Setting setting = null;

            if (id != null)
            {
                setting = _appDbContext.Settings.FirstOrDefault(s => s.Id == id);
            }

            if (setting != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(setting.Logo))
                    {
                        string oldPathFile = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", setting.Logo);

                        if (System.IO.File.Exists(oldPathFile))
                        {
                            System.IO.File.Delete(oldPathFile);
                        }
                    }

                    _appDbContext.Settings.Remove(setting);
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

            ModelState.AddModelError("", "Setting is not found");
            return RedirectToAction("Index");
        }
    }
}
