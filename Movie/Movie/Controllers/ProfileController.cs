using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;
using Movie.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    
    public class ProfileController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProfileController(AppDbContext appDbContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("User"))
                {
                    return RedirectToAction("Logout", "Account");
                }
            }

            if (_signInManager.IsSignedIn(User))
            {
                if (_appDbContext.CustomUsers.Find(_userManager.GetUserId(User)) != null)
                {
                    CustomUser customUser = await _appDbContext.CustomUsers.FindAsync(_userManager.GetUserId(User));

                    var token = await _userManager.GeneratePasswordResetTokenAsync(customUser);

                    Setting setting = _appDbContext.Settings.FirstOrDefault();

                    VmProfile vmProfile = new VmProfile()
                    {
                        Setting = setting
                    };

                    vmProfile.CustomUser = _appDbContext.CustomUsers.FirstOrDefault(u => u.Id == _userManager.GetUserId(User));
                    vmProfile.CustomUser.Token = token;

                    return View(vmProfile);
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else
            {
                TempData["bool"] = "open";
                return RedirectToAction("Index","Home");
            }

            //Setting setting = _appDbContext.Settings.FirstOrDefault();

            //VmProfile vmProfile = new VmProfile()
            //{
            //    Setting = setting
            //};
            //return View(vmProfile);
        }

        [HttpPost]
        public async Task<IActionResult> Update(VmProfile vmProfile,string newPassword,string currentPassword)
        {
            if (ModelState.IsValid)
            {

                if (_appDbContext.CustomUsers.Find(vmProfile.CustomUser.Id) != null)
                {
                    CustomUser customUser = _appDbContext.CustomUsers.Find(vmProfile.CustomUser.Id);
                    customUser.FirstName = vmProfile.CustomUser.FirstName;
                    customUser.LastName = vmProfile.CustomUser.LastName;
                    customUser.UserName = vmProfile.CustomUser.Email;
                    //customUser.PasswordHash = _userManager.PasswordHasher.HashPassword(customUser, newPassword);

                    IdentityUser identity = await _userManager.GetUserAsync(User);

                    if (vmProfile.CustomUser.ImageFile != null)
                    {
                        if (vmProfile.CustomUser.ImageFile.ContentType == "image/jpeg" || vmProfile.CustomUser.ImageFile.ContentType == "image/png")
                        {
                            if (vmProfile.CustomUser.ImageFile.Length < 3000000)
                            {


                                if (!string.IsNullOrEmpty(vmProfile.CustomUser.Image))
                                {
                                    string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images", vmProfile.CustomUser.Image);
                                    if (System.IO.File.Exists(oldImagePath))
                                    {
                                        System.IO.File.Delete(oldImagePath);
                                    }
                                }


                                string ImageName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMMMyyyy") + "-" + vmProfile.CustomUser.ImageFile.FileName;
                                string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "assets","images", ImageName);

                                using (var Stream = new FileStream(FilePath, FileMode.Create))
                                {
                                    vmProfile.CustomUser.ImageFile.CopyTo(Stream);
                                }
                                customUser.Image = ImageName;

                                var result = await _userManager.ChangePasswordAsync(customUser, currentPassword, newPassword);

                                if (!result.Succeeded)
                                {
                                    TempData["checkCurrentPswd"] = "Current password is wrong!!!";
                                    return RedirectToAction("Index", vmProfile);
                                }
                                else
                                {
                                    TempData["changeUserInfo"] = "change";
                                    return RedirectToAction("Index", vmProfile);
                                }
                            }
                            else
                            {
                                return RedirectToAction("Index",vmProfile);
                            }
                        }
                        else
                        {
                            return RedirectToAction("Index", vmProfile);
                        }

                    }

                    var check = await _signInManager.PasswordSignInAsync(_appDbContext.CustomUsers.Find(vmProfile.CustomUser.Id).Email, currentPassword, false, false);

                    if (!check.Succeeded)
                    {
                        TempData["checkCurrentPswd"] = "Current password is wrong!!!";
                        return RedirectToAction("Index", vmProfile);
                    }
                    else
                    {
                        IdentityResult identityResult = await _userManager.ResetPasswordAsync(customUser, vmProfile.CustomUser.Token, newPassword);

                        if (identityResult.Succeeded)
                        {
                            _appDbContext.SaveChanges();
                            TempData["changeUserInfo"] = "change";
                            return RedirectToAction("Index", vmProfile);
                        }
                        else
                        {
                            TempData["terms"] = "New password is not match in terms";
                            return RedirectToAction("Index", vmProfile);
                        }
                        
                    }
                }
                else
                {
                    TempData["UserError"] = "Error";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["UserError"] = "ModelisNotValid";
                return RedirectToAction("Index");
            }
        }
    }
}
