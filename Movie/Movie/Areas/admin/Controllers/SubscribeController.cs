﻿using Microsoft.AspNetCore.Mvc;
using Movie.Data;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Movie.Areas.admin.Controllers
{
    [Area("admin")]
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public SubscribeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<Subscribe> subscribes = _appDbContext.Subscribes.ToList();
            return View(subscribes);
        }
        public IActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Send(string MailText)
        {
            List<Subscribe> subscribes = _appDbContext.Subscribes.ToList();

            foreach (var item in subscribes)
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("codeAcademy222@gmail.com", "Code academy p222");
                mail.To.Add(item.Mail);
                mail.Body = MailText;
                mail.IsBodyHtml = true;
                mail.Subject = "Reklam";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("codeAcademy222@gmail.com", "!CodeAcademyP222");

                smtpClient.Send(mail);
            }

            return RedirectToAction("Index");
        }
    }
}