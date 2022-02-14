using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Areas.admin.Controllers
{

    [Area("admin")]
    public class MovieController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Models.Movies> movies = _appDbContext.Movies
                                                            .Include(m => m.MovieToDirectors).ThenInclude(md => md.Director)
                                                            .Include(m => m.MovieToGenres).ThenInclude(mg => mg.Genre)
                                                            .Include(m => m.MovieToWriters).ThenInclude(mw => mw.Writer)
                                                            .Include(m => m.MovieToCasts).ThenInclude(mc => mc.Cast)
                                                            .ToList();

            return View(movies);
        }

        public IActionResult Create()
        {
            ViewBag.Genres = _appDbContext.Genres.ToList();
            ViewBag.Writers = _appDbContext.Writers.ToList();
            ViewBag.Casts = _appDbContext.Casts.ToList();
            ViewBag.Directors = _appDbContext.Directors.ToList();
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Models.Movies movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.ImageFile != null)
                {
                    if ((movie.ImageFile.ContentType == "image/png" || movie.ImageFile.ContentType == "image/jpeg" ) 
                        && (movie.VideoFile.ContentType == "video/mp4" || movie.VideoFile.ContentType == "image/mp3")
                        && (movie.TrailerFile.ContentType == "video/mp4" || movie.TrailerFile.ContentType == "video/mp3")
                        )
                    {
                        if (movie.ImageFile.Length <= 2097152)
                        {
                            if (movie.VideoFile.Length <= 10187315)
                            {

                            string filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + movie.ImageFile.FileName;
                            string pathname = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", filename);
                            using (var fs = new FileStream(pathname, FileMode.Create))
                            {
                                movie.ImageFile.CopyTo(fs);
                            }
                            movie.Image = filename;

                            string videofilename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + movie.VideoFile.FileName;
                            string videopathname = Path.Combine(_webHostEnvironment.WebRootPath, "Videos", filename);
                            using (var fs = new FileStream(videopathname, FileMode.Create))
                            {
                                movie.VideoFile.CopyTo(fs);
                            }
                            movie.Video = videofilename;

                            string trailerfilename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + movie.TrailerFile.FileName;
                            string trailerpathname = Path.Combine(_webHostEnvironment.WebRootPath, "Trailer", filename);
                            using (var fs = new FileStream(trailerpathname, FileMode.Create))
                            {
                                movie.TrailerFile.CopyTo(fs);
                            }
                            movie.Trailer = trailerfilename;

                            _appDbContext.Movies.Add(movie);
                            _appDbContext.SaveChanges();

                            return RedirectToAction("Index");
                            }
                        }
                        else
                        {
                            ViewBag.Genres = _appDbContext.Genres.ToList();
                            ViewBag.Writers = _appDbContext.Writers.ToList();
                            ViewBag.Casts = _appDbContext.Casts.ToList();
                            ViewBag.Directors = _appDbContext.Directors.ToList();
                            ModelState.AddModelError("", "Picture must be then less 2mb");
                            return View(movie);
                        }
                    }
                    else
                    {
                        ViewBag.Genres = _appDbContext.Genres.ToList();
                        ViewBag.Writers = _appDbContext.Writers.ToList();
                        ViewBag.Casts = _appDbContext.Casts.ToList();
                        ViewBag.Directors = _appDbContext.Directors.ToList();
                        ModelState.AddModelError("", "Picture must be png or jpeg format");
                        return View(movie);
                    }
                }
                else
                {
                    _appDbContext.Movies.Add(movie);
                    _appDbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            ViewBag.Genres = _appDbContext.Genres.ToList();
            ViewBag.Writers = _appDbContext.Writers.ToList();
            ViewBag.Casts = _appDbContext.Casts.ToList();
            ViewBag.Directors = _appDbContext.Directors.ToList();
            return View(movie);
        }
        public IActionResult Update(int? id)
        {
            Models.Movies movie = null;

            if (id != null)
            {
                movie = _appDbContext.Movies.FirstOrDefault(s => s.Id == id);
                string path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", movie.Image);
                if (System.IO.File.Exists(path))
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(path);

                    MemoryStream stream = new MemoryStream(bytes);

                    IFormFile file = new FormFile(stream, 0, bytes.Length, "image", "image.png");

                    movie.ImageFile = file;

                    using (var str = new MemoryStream())
                    {
                        movie.ImageFile.CopyTo(str);
                        var filebytes = str.ToArray();
                        movie.ImageBase64 = Convert.ToBase64String(filebytes);
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            return View(movie);
        }
        [HttpPost]
        public IActionResult Update(Models.Movies movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.ImageFile != null)
                {
                    if (movie.ImageFile.ContentType == "image/png" || movie.ImageFile.ContentType == "image/jpeg")
                    {
                        if (movie.ImageFile.Length <= 2097152)
                        {
                            string oldPathData = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", movie.Image);

                            if (System.IO.File.Exists(oldPathData))
                            {
                                System.IO.File.Delete(oldPathData);
                            }

                            string filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + movie.ImageFile.FileName;
                            string pathname = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", filename);
                            using (var fs = new FileStream(pathname, FileMode.Create))
                            {
                                movie.ImageFile.CopyTo(fs);

                            }
                            movie.Image = filename;

                            _appDbContext.Entry(movie).State = EntityState.Modified;
                            _appDbContext.Entry(movie).Property("BirthDay").IsModified = false;
                            _appDbContext.Entry(movie).Property("GenderId").IsModified = false;

                            _appDbContext.SaveChanges();

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Picture must be then less 2mb");
                            return View(movie);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Picture must be png or jpeg format");
                        return View(movie);
                    }
                }
                else
                {
                    _appDbContext.Entry(movie).State = EntityState.Modified;
                    _appDbContext.Entry(movie).Property("BirthDay").IsModified = false;
                    _appDbContext.Entry(movie).Property("GenderId").IsModified = false;
                    _appDbContext.SaveChanges();

                    return RedirectToAction("Index");
                }

            }

            return View(movie);
        }
        public IActionResult Delete(int? id)
        {
            Models.Movies movie = null;

            if (id != null)
            {
                movie = _appDbContext.Movies.FirstOrDefault(s => s.Id == id);
            }

            if (movie != null)
            {
                if (!string.IsNullOrEmpty(movie.Image))
                {
                    string oldPathFile = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", movie.Image);

                    if (System.IO.File.Exists(oldPathFile))
                    {
                        System.IO.File.Delete(oldPathFile);
                    }
                    _appDbContext.Movies.Remove(movie);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    _appDbContext.Movies.Remove(movie);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Blog is not found");
            return RedirectToAction("Index");
        }
    }
}
