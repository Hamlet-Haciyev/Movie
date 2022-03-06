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
    public class CelebritieController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CelebritieController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("User"))
                {
                    return RedirectToAction("Logout", "Account");
                }
            }
            Setting setting = _appDbContext.Settings.FirstOrDefault();
            List<Cast> casts = _appDbContext.Casts
                                                .Include(c=>c.CastToSocials).ThenInclude(cs=>cs.SocialMedia)
                                                .ToList();

            VmCelebritie vmCelebritie = new VmCelebritie()
            {
                Setting = setting,
                Casts= casts
            };
            ViewBag.Page = "Celebritie";

            return View(vmCelebritie);
        }
        public IActionResult Detail(int? id)
        {
            List<int> CelebritieIds = null;
            List<int> MovieIds = new List<int>();
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("User"))
                {
                    return RedirectToAction("Logout", "Account");
                }
            }

            Cast cast = null;
            Setting setting = _appDbContext.Settings.FirstOrDefault();

            if (id != null)
            {
                cast = _appDbContext.Casts
                                         .Include(c=>c.Gender)
                                         .Include(c => c.CastToSocials).ThenInclude(cs => cs.SocialMedia)
                                         .FirstOrDefault(c => c.Id == id);
                CelebritieIds = _appDbContext.MovieToCasts.Where(mc => mc.MovieId == id).Select(m => m.CastId).ToList();
            }
            else
            {
                return RedirectToAction("Index","Error", new { area = "admin" });
            }


            List<MovieToCast> movieToCasts = _appDbContext.MovieToCasts.ToList();

            List<int> moviesIdData = null;

            if (CelebritieIds != null)
            {
                foreach (var item in CelebritieIds)
                {
                    moviesIdData = movieToCasts.Where(mc => mc.CastId == item && mc.MovieId != id).Select(m => m.MovieId).ToList();

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


            VmCelebritie vmCelebritie = new VmCelebritie()
            {
                Setting = setting,
                Cast = cast,
                PlayListMovie = relatedMovies
            };

            return View(vmCelebritie);
        }
    }
}
