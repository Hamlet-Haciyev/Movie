using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Areas.admin.Controllers
{
    [Area("admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ContactController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [Authorize(Roles ="Admin,Moderator,SuperAdmin")]
        public IActionResult Index()
        {
            return View(_appDbContext.Contacts.ToList());
        }
        public IActionResult Delete(int? id)
        {
            Contact contact = null;
            if (id != null)
            {
                contact = _appDbContext.Contacts.Find(id);
            }
            else
            {
                return RedirectToAction("Index", "Error");
            }

            if (contact != null)
            {
                try
                {
                    _appDbContext.Contacts.Remove(contact);
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

            return View();
        }
    }
}
