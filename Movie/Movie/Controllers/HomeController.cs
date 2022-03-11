using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movie.Data;

using Movie.Models;
using Movie.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index(VmSearch vmSearch)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("User"))
                {
                    return RedirectToAction("Logout", "Account");
                }
            }

            if (vmSearch == null || vmSearch.page == null)
            {
                vmSearch.page = 1;
            }

            List<string> bgColors = new List<string>()
            {
                "#dd003f","#ec5a1a"
            };
            ViewBag.Page = "Home";
            Setting setting = _appDbContext.Settings.FirstOrDefault();
            List<Movies> movies = _appDbContext.Movies
                        .Where(m => (vmSearch.GenreId != null ? m.MovieToGenres.Any(mg => mg.GenreId == vmSearch.GenreId) : true)
                        || vmSearch.allGenre != null ? true : false
                        )
                        .ToList();
            List<Genre> genres = _appDbContext.Genres.Take(6).ToList();
            List<Movies> moviesOrderDesc = _appDbContext.Movies.OrderByDescending(b => b.Id)
                                                                                .Include(m=>m.MovieToGenres).ThenInclude(mg=>mg.Genre)
                                                                                .Include(m=>m.MovieComments)
                                                                                .Take(5)
                                                                                .ToList();
            List<Blog> blogs = _appDbContext.Blogs.ToList();
            Blog blog = _appDbContext.Blogs.OrderByDescending(b => b.Id).FirstOrDefault();

            List<MovieComment> movieComments = _appDbContext.MovieComments.ToList();

            double itemCount = 4;

            int pageCount = (int)Math.Ceiling(Convert.ToDecimal(movies.Count / itemCount));

            ViewBag.PageCount = pageCount;
            ViewBag.PageField = vmSearch.page;


            VmHome vmHome = new VmHome()
            {
                Setting = setting,
                Movies = movies.Skip(((int)vmSearch.page - 1) * (int)itemCount).Take((int)itemCount).ToList(),
                Genres = genres,
                MoviesDescOrder = moviesOrderDesc,
                BgColors = bgColors,
                Blogs = blogs,
                Blog=blog,
                VmSearch = vmSearch,
                MovieComments = movieComments
            };
            return View(vmHome);
        }
        public IActionResult Subscribe(string email)
        {
            VmSubscribeResponse response = new VmSubscribeResponse();

            if (string.IsNullOrEmpty(email))
            {
                response.Status = false;
                response.Message = "Subscribtion faild! You must enter your email";
                TempData["blankField"] = "error";
                return Json(response);
            }

            bool isExist = _appDbContext.Subscribes.Any(s => s.Mail == email);

            if (isExist)
            {
                response.Status = false;
                response.Message = "Your have already subscribed!";
                TempData["alrdEmail"] = "err";

                return Json(response);
            }

            Subscribe subscribe = new Subscribe();
            subscribe.CreatedDate = DateTime.Now;
            subscribe.Mail = email;
            _appDbContext.Subscribes.Add(subscribe);
            _appDbContext.SaveChanges();
            TempData["succesdedSubscribe"] = "scs";

            response.Status = true;
            response.Message = "You subscribe successfully!";
            return Json(response);
        }
    }
}
