using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using Movie.Data;
using Movie.Models;
using Movie.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AccountController(AppDbContext appDbContext, RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager
            ,IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment
            )
        {
            _appDbContext = appDbContext;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Register()
        {
            VmLayout vmLayout = new VmHome()
            {
                Setting = _appDbContext.Settings.FirstOrDefault(),
            };
            return View(vmLayout);
        }
        [HttpPost]
        public async Task<IActionResult> Register(VmLayout vmLayout)
        {
            if (ModelState.IsValid)
            {
                bool isExistsEmail = await _appDbContext.Users.AnyAsync(u => u.Email == vmLayout.VmRegister.Email);

                if (isExistsEmail)
                {
                    TempData["RegisterExistError"] = "This email is already registered!";
                    return RedirectToAction("Index","Home");
                }
                
                CustomUser user = new CustomUser()
                {
                    UserName = vmLayout.VmRegister.Email,
                    FirstName = vmLayout.VmRegister.FirstName,
                    LastName = vmLayout.VmRegister.LastName,
                    Email = vmLayout.VmRegister.Email,
                    CreatedDate = DateTime.Now,
                    EmailConfirmed=true
                };

                var result = await _userManager.CreateAsync(user, vmLayout.VmRegister.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    await _signInManager.SignInAsync(user, false);
                    TempData["SuccessRegister"] = "Your created account";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    TempData["Failed"] = "The password is not in accordance with the terms";
                    TempData["Email"] = vmLayout.VmRegister.Email;
                    TempData["fName"] = vmLayout.VmRegister.FirstName;
                    TempData["lName"] = vmLayout.VmRegister.LastName;

                    return RedirectToAction("Index","Home", vmLayout);
                    //return View("Index", vmRegister);
                }
            }
            return View(vmLayout);
           
        }
        #region Login
        //public IActionResult Login()
        //{
        //    VmLayout vmLayout = new VmLayout()
        //    {
        //        Setting = _appDbContext.Settings.FirstOrDefault(),
        //    };
        //    return View(vmLayout);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Login(VmLayout vmLayout)
        //{
        //    VmHome vmHome = new VmHome()
        //    {
        //        Setting = _appDbContext.Settings.FirstOrDefault(),
        //        VmLogin = vmLayout.VmLogin
        //    };
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(vmLayout.VmLogin.Email, vmLayout.VmLogin.Password, vmLayout.VmLogin.RememberMe, false);

        //        if (result.Succeeded)
        //        {
        //            TempData["SuccessLogin"] = "Success";
        //            return RedirectToAction("Index", "Home");
        //        }
        //        TempData["FailedLogin"] = "Email or password is wrong!!!";
        //        TempData["open"] = "open";
        //        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        //    }
        //    return RedirectToAction("Index", "Home", vmHome.VmLogin.Email);
        //}
        #endregion
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        #region AjaxLogin
        public IActionResult Login()
        {
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public async Task<JsonResult> Login(string email, string password)
        {
            IdentityUser identityUser = null;
            VmLoginStatus vmLoginStatus = new VmLoginStatus();
            bool hasEmail = _appDbContext.CustomUsers.Any(cu => cu.Email == email);

            if (!hasEmail)
            {
                vmLoginStatus.Success = false;
                vmLoginStatus.Message = "Bele bir hesab movcud deyil";
                return Json(vmLoginStatus);
            }
            else
            {
                identityUser = _appDbContext.CustomUsers.FirstOrDefault(cu => cu.Email == email);
            }

            var result = await _signInManager.PasswordSignInAsync(identityUser, password, false, false);

            if (string.IsNullOrEmpty(email))
            {
                vmLoginStatus.Success = false;
                vmLoginStatus.Message = "Subscribtion faild! You must enter your email";
                return Json(vmLoginStatus);
            }

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(email);
                bool isUser = await _userManager.IsInRoleAsync(user, "User");
                if (isUser)
                {
                    vmLoginStatus.Success = true;
                    vmLoginStatus.Message = "Success";
                    await _signInManager.SignInAsync(identityUser, false);

                    return Json(vmLoginStatus);
                }
                else
                {
                    vmLoginStatus.Success = false;
                    vmLoginStatus.Message = "Failed";
                }
            }
            else
            {
                vmLoginStatus.Success = false;
                vmLoginStatus.Message = "Failed";
            }


            return Json(vmLoginStatus);
        }
        #endregion

        #region ForgetPassword
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            VmForgetPasswordStatusForAjax vmForgetPasswordStatusForAjax = new VmForgetPasswordStatusForAjax();

            if (string.IsNullOrWhiteSpace(email))
                return RedirectToAction("Index", "Error", new { area = "admin" });

            CustomUser customUser = _appDbContext.CustomUsers.FirstOrDefault(cu => cu.Email == email);

            if (customUser == null)
            {
                return RedirectToAction("Index", "Error", new { area = "admin" });
            }
            else
            {
                vmForgetPasswordStatusForAjax.Status = true;
                vmForgetPasswordStatusForAjax.Message = "Mail sent successfully";
            }


            string emailbody = string.Empty;

            using (StreamReader stream = new StreamReader(Path.Combine(_webHostEnvironment.WebRootPath, "Email", "ForgetPassword.html")))
            {
                emailbody = stream.ReadToEnd();
            }

            string forgetpasswordtoken = await _userManager.GeneratePasswordResetTokenAsync(customUser);

            string url = Url.Action("changepassword", "account", new { Id = customUser.Id, token = forgetpasswordtoken }, Request.Scheme);

            emailbody = emailbody.Replace("{{UserName}}", $"{customUser.UserName}").Replace("{{url}}", $"{url}");

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("codeAcademy222@gmail.com");
                mail.To.Add(customUser.Email);
                mail.Subject = "Reset Password";
                mail.Body = emailbody;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("codeAcademy222@gmail.com", "!CodeAcademyP222");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

                return Json(vmForgetPasswordStatusForAjax);
            }

        }
        #endregion

        #region ChangePasswordOld
        public async Task<IActionResult> ChangePassword(string Id, string token)
        {
            if (string.IsNullOrWhiteSpace(Id) || string.IsNullOrWhiteSpace(token))
            {
                return NotFound();
            }
            CustomUser customUser = _appDbContext.CustomUsers.FirstOrDefault(cu => cu.Id == Id);

            if (customUser == null)
            {
                return NotFound();
            }

            ResetPasswordVM resetPassword = new ResetPasswordVM
            {
                Id = Id,
                Token = token
            };

            return View(resetPassword);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ResetPasswordVM resetPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordVM);
            }

            if (string.IsNullOrWhiteSpace(resetPasswordVM.Id) || string.IsNullOrWhiteSpace(resetPasswordVM.Token))
            {
                return NotFound();
            }
            CustomUser customUser = _appDbContext.CustomUsers.FirstOrDefault(cu => cu.Id == resetPasswordVM.Id);

            if (customUser == null)
            {
                return NotFound();
            }

            IdentityResult identityResult = await _userManager.ResetPasswordAsync(customUser, resetPasswordVM.Token, resetPasswordVM.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(resetPasswordVM);
            }

            return RedirectToAction("Index","Home");
        }
        #endregion

        #region Access Denied
        // Admin panelde muxtelif sehifelerde role lara gore idarecilik sistemi var , eger bir sehifeye kecmeye hazirki istifadecinin sexsin icazesi yoxdusa access denied sehifesine atir.
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

        #endregion
    }
}
