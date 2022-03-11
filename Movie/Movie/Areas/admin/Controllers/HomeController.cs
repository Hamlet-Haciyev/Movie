using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "SuperAdmin, Moderator, Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            VmHomeAdminPanel vmHomeAdminPanel = new VmHomeAdminPanel()
            {
                LastestMovies = _appDbContext.Movies.OrderByDescending(m => m.CreatedDate).Take(5).ToList(),
                CustomUsers = _appDbContext.CustomUsers.OrderByDescending(cu=>cu.CreatedDate).Take(5).ToList()
                
            };
            return View(vmHomeAdminPanel);
        }
    }
}
