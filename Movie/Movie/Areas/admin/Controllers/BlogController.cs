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
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Blogs.Include(b=>b.BlogToTags).ThenInclude(bt=>bt.Tag).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Tags = _appDbContext.Tags.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                if (blog.ImageFile != null)
                {
                    if (blog.ImageFile.ContentType == "image/png" || blog.ImageFile.ContentType == "image/jpeg")
                    {
                        if (blog.ImageFile.Length <= 2097152)
                        {

                            string filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + blog.ImageFile.FileName;
                            string pathname = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", filename);
                            using (var fs = new FileStream(pathname, FileMode.Create))
                            {
                                blog.ImageFile.CopyTo(fs);
                            }
                            blog.Image = filename;
                            blog.CreatedDate = DateTime.Now;

                            _appDbContext.Blogs.Add(blog);
                            _appDbContext.SaveChanges();

                            foreach (var item in blog.TagId)
                            {
                                BlogToTag blogToTag = new BlogToTag();
                                blogToTag.TagId = item;
                                blogToTag.BlogId = blog.Id;
                                _appDbContext.BlogToTags.Add(blogToTag);
                            }
                            _appDbContext.SaveChanges();

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Tags = _appDbContext.Tags.ToList();
                            ModelState.AddModelError("", "Picture must be then less 2mb");
                            return View(blog);
                        }
                    }
                    else
                    {
                        ViewBag.Tags = _appDbContext.Tags.ToList();
                        ModelState.AddModelError("", "Picture must be png or jpeg format");
                        return View(blog);
                    }
                }
                else
                {
                    _appDbContext.Blogs.Add(blog);
                    _appDbContext.SaveChanges();

                    foreach (var item in blog.TagId)
                    {
                        BlogToTag blogToTag = new BlogToTag();
                        blogToTag.TagId = item;
                        blogToTag.BlogId = blog.Id;
                        _appDbContext.BlogToTags.Add(blogToTag);
                    }
                    _appDbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            ViewBag.Tags = _appDbContext.Tags.ToList();

            return View(blog);
        }
        public IActionResult Update(int? id)
        {
            Blog blog = null;

            if (id != null)
            {
                blog = _appDbContext.Blogs.Include(b=>b.BlogToTags).ThenInclude(bt=>bt.Tag).FirstOrDefault(s => s.Id == id);
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", blog.Image);
                if (System.IO.File.Exists(path))
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(path);

                    MemoryStream stream = new MemoryStream(bytes);

                    IFormFile file = new FormFile(stream, 0, bytes.Length, "image", "image.png");

                    blog.ImageFile = file;

                    using (var str = new MemoryStream())
                    {
                        blog.ImageFile.CopyTo(str);
                        var filebytes = str.ToArray();
                        blog.base64 = Convert.ToBase64String(filebytes);
                    }
                }
                ViewBag.Tags = _appDbContext.Tags.ToList();
                blog.TagId = _appDbContext.BlogToTags.Where(t => t.BlogId == id).Select(r => r.TagId).ToList();
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }
            return View(blog);
        }
        [HttpPost]
        public IActionResult Update(Blog blog)
        {
            if (ModelState.IsValid)
            {
                if (blog.ImageFile != null)
                {
                    if (blog.ImageFile.ContentType == "image/png" || blog.ImageFile.ContentType == "image/jpeg")
                    {
                        if (blog.ImageFile.Length <= 2097152)
                        {
                            string oldPathData = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", blog.Image);

                            if (System.IO.File.Exists(oldPathData))
                            {
                                System.IO.File.Delete(oldPathData);
                            }

                            string filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + blog.ImageFile.FileName;
                            string pathname = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", filename);
                            using (var fs = new FileStream(pathname, FileMode.Create))
                            {
                                blog.ImageFile.CopyTo(fs);
                                
                            }
                            blog.Image = filename;

                            _appDbContext.Entry(blog).State = EntityState.Modified;
                            _appDbContext.Entry(blog).Property("CreatedDate").IsModified = false;

                            _appDbContext.SaveChanges();

                            List<BlogToTag> blogToTags = _appDbContext.BlogToTags.Where(i => i.BlogId == blog.Id).ToList();

                            foreach (var item in blogToTags)
                            {
                                _appDbContext.BlogToTags.Remove(item);
                            }
                            _appDbContext.SaveChanges();

                            foreach (var item in blog.TagId)
                            {
                                BlogToTag blogToTag = new BlogToTag();
                                blogToTag.TagId = item;
                                blogToTag.BlogId = blog.Id;
                                _appDbContext.BlogToTags.Add(blogToTag);
                            }
                            _appDbContext.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Picture must be then less 2mb");
                            return View(blog);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Picture must be png or jpeg format");
                        return View(blog);
                    }
                }
                else
                {
                    _appDbContext.Entry(blog).State = EntityState.Modified;
                    _appDbContext.Entry(blog).Property("CreatedDate").IsModified = false;
                    _appDbContext.SaveChanges();

                    List<BlogToTag> blogToTags = _appDbContext.BlogToTags.Where(i => i.BlogId == blog.Id).ToList();

                    foreach (var item in blogToTags)
                    {
                        _appDbContext.BlogToTags.Remove(item);
                    }
                    _appDbContext.SaveChanges();

                    foreach (var item in blog.TagId)
                    {
                        BlogToTag blogToTag = new BlogToTag();
                        blogToTag.TagId = item;
                        blogToTag.BlogId = blog.Id;
                        _appDbContext.BlogToTags.Add(blogToTag);
                    }

                    _appDbContext.SaveChanges();

                    return RedirectToAction("Index");
                }

            }

            return View(blog);
        }
        public IActionResult Delete(int? id)
        {
            Blog blog = null;

            if (id != null)
            {
                blog = _appDbContext.Blogs.FirstOrDefault(s => s.Id == id);
            }

            if (blog != null)
            {
                if (!string.IsNullOrEmpty(blog.Image))
                {
                    string oldPathFile = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", blog.Image);

                    if (System.IO.File.Exists(oldPathFile))
                    {
                        System.IO.File.Delete(oldPathFile);
                    }
                    _appDbContext.Blogs.Remove(blog);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    _appDbContext.Blogs.Remove(blog);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Blog is not found");
            return RedirectToAction("Index");
        }
        
    }
}
