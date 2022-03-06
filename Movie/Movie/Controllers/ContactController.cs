using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models;
using Movie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ContactController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            Setting setting = _appDbContext.Settings.FirstOrDefault();

            VmContact vmContact = new VmContact()
            {
                Setting = setting
            };

            return View(vmContact);
        }
        [HttpPost]
        public IActionResult SendMessage(Contact contact)
        {
            Setting setting = _appDbContext.Settings.FirstOrDefault();
            VmContact vmContact = new VmContact()
            {
                Setting = setting,
                Contact = contact
            };

            if (ModelState.IsValid)
            {
                contact.CreatedDate = DateTime.Now;
                _appDbContext.Contacts.Add(contact);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index", vmContact);
        }

    }
}
