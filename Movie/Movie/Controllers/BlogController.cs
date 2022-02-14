using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Page = "Blog";

            return View();
        }
        public IActionResult Detail()
        {
            ViewBag.Page = "Blog";

            return View();
        }
    }
}
