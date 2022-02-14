using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    public class CelebritieController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Page = "Celebritie";

            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
