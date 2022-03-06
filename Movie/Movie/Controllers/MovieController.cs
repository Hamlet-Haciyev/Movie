using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;
using Movie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public MovieController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index(VmSearch vmSearch)
        {
            List<Movies> movies = null;
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("User"))
                {
                    return RedirectToAction("Logout", "Account");
                }
            }
            ViewBag.Page = "Movie";

            if (vmSearch.TitleOrRating == null)
            {
                movies = _appDbContext.Movies
                                           .Where(m => vmSearch.SearchMovie != null ? m.Title.ToLower().Contains(vmSearch.SearchMovie.ToLower()) : true)
                                           .Include(m => m.MovieToDirectors).ThenInclude(md => md.Director)
                                           .Include(m => m.MovieToWriters).ThenInclude(mw => mw.Writer)
                                           .Include(m => m.MovieToCasts).ThenInclude(mc => mc.Cast)
                                           .ToList();
            }
            else
            {
                 movies = _appDbContext.Movies
                                           .Include(m => m.MovieToDirectors).ThenInclude(md => md.Director)
                                           .Include(m => m.MovieToWriters).ThenInclude(mw => mw.Writer)
                                           .Include(m => m.MovieToCasts).ThenInclude(mc => mc.Cast)
                                           .OrderBy(b=> vmSearch.TitleOrRating == "1" ? b.Title : "")
                                           .ToList();
            }

            Setting setting = _appDbContext.Settings.FirstOrDefault();

            VmMovie vmMovie = new VmMovie()
            {
                Setting= setting,
                Movies = movies,
            };
            return View(vmMovie);
        }
        public IActionResult Detail(int? id, string rgsbool,MovieComment movieComment)
        {
            List<int> GenreIds = null;
            List<int> MovieIds = new List<int>();

            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("User"))
                {
                    return RedirectToAction("Logout", "Account");
                }
            }
            Movies movie = null;

            if (rgsbool != null)
            {
                TempData["bool"] = "open";
            }

            if (id != null)
            {
                movie = _appDbContext.Movies
                                            .Include(m => m.MovieToDirectors).ThenInclude(md => md.Director)
                                            .Include(m => m.MovieToWriters).ThenInclude(mw => mw.Writer)
                                            .Include(m => m.MovieToCasts).ThenInclude(mc => mc.Cast)
                                            .Include(m => m.MovieToGenres).ThenInclude(mg => mg.Genre)
                                            .FirstOrDefault(m => m.Id == id);
                GenreIds = _appDbContext.MovieToGenres.Where(mg => mg.MovieId == id).Select(m => m.GenreId).ToList();
            }
            else
            {
                return RedirectToAction("Index", "Error", new { area="admin"});
            }
            Setting setting = _appDbContext.Settings.FirstOrDefault();
            List<MovieComment> movieComments = _appDbContext.MovieComments.Where(mc=>mc.MovieId ==id).ToList();
            List<MovieToGenre> movieToGenres = _appDbContext.MovieToGenres.ToList();

            List<int> moviesIdData = null;

            if (GenreIds != null)
            {
                foreach (var item in GenreIds)
                {
                    moviesIdData = movieToGenres.Where(mg => mg.GenreId == item && mg.MovieId != id).Select(m => m.MovieId).ToList();

                    foreach (var mvId in moviesIdData)
                    {
                        MovieIds.Add(mvId);
                    }
                }
            }
            List<Movies> relatedMovies = new List<Movies>();

            foreach (var mvId in MovieIds)
            {
                relatedMovies.Add(_appDbContext.Movies.Where(m => m.Id == mvId).FirstOrDefault());
            }

            bool hasRating = _appDbContext.MovieComments.Any(mc => mc.MovieId == id);

            if (hasRating)
            {
                ViewBag.AvgRate = Math.Round(_appDbContext.MovieComments.Where(mc => mc.MovieId == id).Average(mc => mc.Rating));
            }

            VmMovie vmMovie = new VmMovie()
            {
                Setting = setting,
                Movie = movie,
                MovieComments = movieComments,
                MovieComment = movieComment,
                RelatedMovies = relatedMovies.Take(3).ToList()
            };

            return View(vmMovie);
        }
        [HttpPost]
        public IActionResult Comment(MovieComment movieComment)
        {
            Movies movie = null;

            if (ModelState.IsValid)
            {
                movieComment.CreatedDate = DateTime.Now;
                _appDbContext.MovieComments.Add(movieComment);
                _appDbContext.SaveChanges();
                return RedirectToAction("Detail", new { id = movieComment.MovieId});
            }

            movie = _appDbContext.Movies
                                          .Include(m => m.MovieToDirectors).ThenInclude(md => md.Director)
                                          .Include(m => m.MovieToWriters).ThenInclude(mw => mw.Writer)
                                          .Include(m => m.MovieToCasts).ThenInclude(mc => mc.Cast)
                                          .Include(m => m.MovieToGenres).ThenInclude(mg => mg.Genre)
                                          .FirstOrDefault(m => m.Id == movieComment.MovieId);
            Setting setting = _appDbContext.Settings.FirstOrDefault();
            List<MovieComment> movieComments = _appDbContext.MovieComments.Where(mc => mc.MovieId == movieComment.MovieId).ToList();

            VmMovie vmMovie = new VmMovie()
            {
                Setting = setting,
                Movie = movie,
                MovieComments = movieComments
            };
            return RedirectToAction("Detail", new { id = movieComment.MovieId , MovieComment = movieComment });
        }
    }
}
