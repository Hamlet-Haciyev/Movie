using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.Page = "Home";
            return View();
        }
    }
}
