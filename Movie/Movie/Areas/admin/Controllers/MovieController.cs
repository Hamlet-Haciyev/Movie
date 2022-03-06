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
                            if (movie.VideoFile.Length <= 50187315)
                            {
                            string filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + movie.ImageFile.FileName;
                            string pathname = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", filename);
                            using (var fs = new FileStream(pathname, FileMode.Create))
                            {
                                movie.ImageFile.CopyTo(fs);
                            }
                            movie.Image = filename;

                            string videofilename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + movie.VideoFile.FileName;
                            string videopathname = Path.Combine(_webHostEnvironment.WebRootPath, "Videos", videofilename);
                            using (var fs = new FileStream(videopathname, FileMode.Create))
                            {
                                movie.VideoFile.CopyTo(fs);
                            }
                            movie.Video = videofilename;
                            
                            string trailerfilename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + movie.TrailerFile.FileName;
                            string trailerpathname = Path.Combine(_webHostEnvironment.WebRootPath, "Trailer", trailerfilename);
                            using (var fs = new FileStream(trailerpathname, FileMode.Create))
                            {
                                movie.TrailerFile.CopyTo(fs);
                            }
                            movie.Trailer = trailerfilename;

                            _appDbContext.Movies.Add(movie);
                            _appDbContext.SaveChanges();

                            foreach (var item in movie.GenresIds)
                            {
                                MovieToGenre movieToGenre = new MovieToGenre();
                                movieToGenre.MovieId = movie.Id;
                                movieToGenre.GenreId = item;
                                _appDbContext.MovieToGenres.Add(movieToGenre);
                            }

                            foreach (var item in movie.CastIds)
                            {
                                MovieToCast movieToCast = new MovieToCast();
                                movieToCast.MovieId = movie.Id;
                                movieToCast.CastId = item;
                                _appDbContext.MovieToCasts.Add(movieToCast);
                            }

                            foreach (var item in movie.WriterIds)
                            {
                                MovieToWriter movieToWriter = new MovieToWriter();
                                movieToWriter.MovieId = movie.Id;
                                movieToWriter.WriterId = item;
                                _appDbContext.MovieToWriters.Add(movieToWriter);
                            }

                            MovieToDirector movieToDirector = new MovieToDirector();
                            movieToDirector.MovieId = movie.Id;
                            movieToDirector.DirectorId = movie.DirectorId;
                            _appDbContext.MovieToDirectors.Add(movieToDirector);

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

                   
                        foreach (var item in movie.GenresIds)
                        {
                            MovieToGenre movieToGenre = new MovieToGenre();
                            movieToGenre.MovieId = movie.Id;
                            movieToGenre.GenreId = item;
                            _appDbContext.MovieToGenres.Add(movieToGenre);
                        }
                    
                        foreach (var item in movie.CastIds)
                        {
                            MovieToCast movieToCast = new MovieToCast();
                            movieToCast.MovieId = movie.Id;
                            movieToCast.CastId = item;
                            _appDbContext.MovieToCasts.Add(movieToCast);
                        }

                   
                       foreach (var item in movie.WriterIds)
                        {
                            MovieToWriter movieToWriter = new MovieToWriter();
                            movieToWriter.MovieId = movie.Id;
                            movieToWriter.WriterId = item;
                            _appDbContext.MovieToWriters.Add(movieToWriter);
                        }

                    MovieToDirector movieToDirector = new MovieToDirector();
                    movieToDirector.MovieId = movie.Id;
                    movieToDirector.DirectorId = movie.DirectorId;
                    _appDbContext.MovieToDirectors.Add(movieToDirector);

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

            ViewBag.Genres = _appDbContext.Genres.ToList();
            ViewBag.Writers = _appDbContext.Writers.ToList();
            ViewBag.Casts = _appDbContext.Casts.ToList();
            ViewBag.Directors = _appDbContext.Directors.ToList();


            if (id != null)
            {
                movie = _appDbContext.Movies.FirstOrDefault(s => s.Id == id);

                movie.GenresIds = _appDbContext.MovieToGenres.Where(mg => mg.MovieId == id).Select(a => a.GenreId).ToList();
                movie.WriterIds = _appDbContext.MovieToWriters.Where(mw => mw.MovieId == id).Select(a => a.WriterId).ToList();
                movie.CastIds = _appDbContext.MovieToCasts.Where(mc => mc.MovieId == id).Select(a => a.CastId).ToList();
                movie.DirectorId = _appDbContext.MovieToDirectors.Where(mc => mc.MovieId == id).Select(a => a.DirectorId).FirstOrDefault();


                string path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", movie.Image);
                string videoFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Videos", movie.Video);

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
                            string oldVideoPathData = Path.Combine(_webHostEnvironment.WebRootPath, "Videos", movie.Video);

                            if (System.IO.File.Exists(oldVideoPathData))
                            {
                                System.IO.File.Delete(oldVideoPathData);
                            }
                            string oldTrailerPathData = Path.Combine(_webHostEnvironment.WebRootPath, "Trailer", movie.Trailer);

                            if (System.IO.File.Exists(oldTrailerPathData))
                            {
                                System.IO.File.Delete(oldTrailerPathData);
                            }

                            string filename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + movie.ImageFile.FileName;
                            string pathname = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", filename);
                            using (var fs = new FileStream(pathname, FileMode.Create))
                            {
                                movie.ImageFile.CopyTo(fs);

                            }
                            movie.Image = filename;

                            string videofilename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + movie.VideoFile.FileName;
                            string videopathname = Path.Combine(_webHostEnvironment.WebRootPath, "Videos", videofilename);
                            using (var fs = new FileStream(videopathname, FileMode.Create))
                            {
                                movie.VideoFile.CopyTo(fs);
                            }
                            movie.Video = videofilename;

                            string trailerfilename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + movie.TrailerFile.FileName;
                            string trailerpathname = Path.Combine(_webHostEnvironment.WebRootPath, "Trailer", trailerfilename);
                            using (var fs = new FileStream(trailerpathname, FileMode.Create))
                            {
                                movie.TrailerFile.CopyTo(fs);
                            }
                            movie.Trailer = trailerfilename;

                            _appDbContext.Entry(movie).State = EntityState.Modified;
                            _appDbContext.Entry(movie).Property("CreatedDate").IsModified = false;

                            _appDbContext.SaveChanges();

                            List<MovieToGenre> movieToGenres = _appDbContext.MovieToGenres.Where(mg => mg.MovieId == movie.Id).ToList();

                            foreach (var item in movieToGenres)
                            {
                                _appDbContext.MovieToGenres.Remove(item);
                            }
                            _appDbContext.SaveChanges();

                            List<MovieToWriter> movieToWriteres = _appDbContext.MovieToWriters.Where(mw => mw.MovieId == movie.Id).ToList();

                            foreach (var item in movieToWriteres)
                            {
                                _appDbContext.MovieToWriters.Remove(item);
                            }
                            _appDbContext.SaveChanges();

                            List<MovieToCast> movieToCasts = _appDbContext.MovieToCasts.Where(mc => mc.MovieId == movie.Id).ToList();

                            foreach (var item in movieToCasts)
                            {
                                _appDbContext.MovieToCasts.Remove(item);
                            }
                            _appDbContext.SaveChanges();

                            MovieToDirector movieToDirector1 = _appDbContext.MovieToDirectors.FirstOrDefault(m=>m.MovieId == movie.Id);

                            _appDbContext.MovieToDirectors.Remove(movieToDirector1);
                            _appDbContext.SaveChanges();


                            foreach (var item in movie.GenresIds)
                            {
                                MovieToGenre movieToGenre = new MovieToGenre();
                                movieToGenre.MovieId = movie.Id;
                                movieToGenre.GenreId = item;
                                _appDbContext.MovieToGenres.Add(movieToGenre);
                            }

                            foreach (var item in movie.CastIds)
                            {
                                MovieToCast movieToCast = new MovieToCast();
                                movieToCast.MovieId = movie.Id;
                                movieToCast.CastId = item;
                                _appDbContext.MovieToCasts.Add(movieToCast);
                            }

                            foreach (var item in movie.WriterIds)
                            {
                                MovieToWriter movieToWriter = new MovieToWriter();
                                movieToWriter.MovieId = movie.Id;
                                movieToWriter.WriterId = item;
                                _appDbContext.MovieToWriters.Add(movieToWriter);
                            }

                            MovieToDirector movieToDirector = new MovieToDirector();
                            movieToDirector.MovieId = movie.Id;
                            movieToDirector.DirectorId = movie.DirectorId;
                            _appDbContext.MovieToDirectors.Add(movieToDirector);

                            _appDbContext.SaveChanges();


                            return RedirectToAction("Index");
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
                    if (movie.VideoFile != null)
                    {
                        string oldVideoPathData = Path.Combine(_webHostEnvironment.WebRootPath, "Videos", movie.Video);

                        if (System.IO.File.Exists(oldVideoPathData))
                        {
                            System.IO.File.Delete(oldVideoPathData);
                        }

                        string videofilename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + movie.VideoFile.FileName;
                        string videopathname = Path.Combine(_webHostEnvironment.WebRootPath, "Videos", videofilename);
                        using (var fs = new FileStream(videopathname, FileMode.Create))
                        {
                            movie.VideoFile.CopyTo(fs);
                        }
                        movie.Video = videofilename;
                    }

                    if (movie.TrailerFile != null)
                    {
                        string oldTrailerPathData = Path.Combine(_webHostEnvironment.WebRootPath, "Trailer", movie.Trailer);

                        if (System.IO.File.Exists(oldTrailerPathData))
                        {
                            System.IO.File.Delete(oldTrailerPathData);
                        }

                        string trailerfilename = Guid.NewGuid() + "-" + DateTime.Now.ToString("yyyyMMddHHmmSS") + "-" + movie.TrailerFile.FileName;
                        string trailerpathname = Path.Combine(_webHostEnvironment.WebRootPath, "Trailer", trailerfilename);
                        using (var fs = new FileStream(trailerpathname, FileMode.Create))
                        {
                            movie.TrailerFile.CopyTo(fs);
                        }
                        movie.Trailer = trailerfilename;
                    }

                    _appDbContext.Entry(movie).State = EntityState.Modified;
                    _appDbContext.Entry(movie).Property("CreatedDate").IsModified = false;
                    
                    _appDbContext.SaveChanges();
                    List<MovieToGenre> movieToGenres = _appDbContext.MovieToGenres.Where(mg => mg.MovieId == movie.Id).ToList();

                    foreach (var item in movieToGenres)
                    {
                        _appDbContext.MovieToGenres.Remove(item);
                    }

                    List<MovieToWriter> movieToWriteres = _appDbContext.MovieToWriters.Where(mw => mw.MovieId == movie.Id).ToList();

                    foreach (var item in movieToWriteres)
                    {
                        _appDbContext.MovieToWriters.Remove(item);
                    }

                    List<MovieToCast> movieToCasts = _appDbContext.MovieToCasts.Where(mc => mc.MovieId == movie.Id).ToList();

                    foreach (var item in movieToCasts)
                    {
                        _appDbContext.MovieToCasts.Remove(item);
                    }

                    MovieToDirector movieToDirector1 = _appDbContext.MovieToDirectors.FirstOrDefault(m => m.MovieId == movie.Id);

                    _appDbContext.MovieToDirectors.Remove(movieToDirector1);
                    _appDbContext.SaveChanges();


                    foreach (var item in movie.GenresIds)
                    {
                        MovieToGenre movieToGenre = new MovieToGenre();
                        movieToGenre.MovieId = movie.Id;
                        movieToGenre.GenreId = item;
                        _appDbContext.MovieToGenres.Add(movieToGenre);
                    }

                    foreach (var item in movie.CastIds)
                    {
                        MovieToCast movieToCast = new MovieToCast();
                        movieToCast.MovieId = movie.Id;
                        movieToCast.CastId = item;
                        _appDbContext.MovieToCasts.Add(movieToCast);
                    }

                    foreach (var item in movie.WriterIds)
                    {
                        MovieToWriter movieToWriter = new MovieToWriter();
                        movieToWriter.MovieId = movie.Id;
                        movieToWriter.WriterId = item;
                        _appDbContext.MovieToWriters.Add(movieToWriter);
                    }

                    MovieToDirector movieToDirector = new MovieToDirector();
                    movieToDirector.MovieId = movie.Id;
                    movieToDirector.DirectorId = movie.DirectorId;
                    _appDbContext.MovieToDirectors.Add(movieToDirector);

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
        public IActionResult Delete(int? id)
        {
            Models.Movies movie = null;

            if (id != null)
            {
                movie = _appDbContext.Movies.FirstOrDefault(s => s.Id == id);
            }

            if (movie != null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(movie.Video))
                    {
                        string oldVideoPathFile = Path.Combine(_webHostEnvironment.WebRootPath, "Videos", movie.Video);
                        if (System.IO.File.Exists(oldVideoPathFile))
                        {
                            System.IO.File.Delete(oldVideoPathFile);
                        }
                    }

                    if (!string.IsNullOrEmpty(movie.Trailer))
                    {
                        string oldTrailerPathFile = Path.Combine(_webHostEnvironment.WebRootPath, "Trailer", movie.Trailer);
                        if (System.IO.File.Exists(oldTrailerPathFile))
                        {
                            System.IO.File.Delete(oldTrailerPathFile);
                        }
                    }

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

                    _appDbContext.Movies.Remove(movie);
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

            ModelState.AddModelError("", "Blog is not found");
            return RedirectToAction("Index");
        }
    }
}
