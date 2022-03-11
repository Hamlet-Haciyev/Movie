using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Movie.Data;
using Movie.Models;
using Movie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Areas.admin.Controllers
{
    [Area("admin")]
    //[Authorize]
    public class AccountController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(AppDbContext appDbContext, RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _appDbContext = appDbContext;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [Authorize(Roles="SuperAdmin")]
        public IActionResult Register()
        {
            ViewBag.Roles = _appDbContext.Roles.Where(r=>r.Name != "User").ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(VmRegister vmRegister)
        {
            ViewBag.Roles = _appDbContext.Roles.Where(r => r.Name != "User").ToList();

            if (ModelState.IsValid)
            {
                CustomUser user = new CustomUser()
                {
                    FirstName = vmRegister.FirstName,
                    LastName = vmRegister.LastName,
                    UserName = vmRegister.Email,
                    Email = vmRegister.Email,
                    CreatedDate = DateTime.Now,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, vmRegister.Password);
               
                if (result.Succeeded)
                {
                    string role = _appDbContext.Roles.FirstOrDefault(r => r.Id == vmRegister.RoleId).ToString();

                    var user1 = await _userManager.FindByNameAsync(vmRegister.Email);

                    await _userManager.AddToRoleAsync(user, role);
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(vmRegister);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(vmRegister);
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("User"))
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(VmLogin user)
        {
            IdentityUser identityUser = _appDbContext.CustomUsers.FirstOrDefault(cu => cu.Email == user.Email);
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);

                if (result.Succeeded)
                {
                    if (identityUser != null)
                    {
                        var checkRole = await _userManager.IsInRoleAsync(identityUser, "User");

                        if (checkRole)
                        {
                            TempData["NotAdmin"] = "This account is not admin or moderator";
                            return RedirectToAction("Logout");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else
                {
                    TempData["wrongPassword"] = "Username or password is not correct";
                    ModelState.AddModelError("", "Username or password is not correct");
                    return View(user);
                }
            }

            return View(user);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
        [Authorize(Roles="SuperAdmin, Admin, Moderator")]
        public IActionResult Users()
        {
            VmUser model = new VmUser();
            model.CustomUsers = _appDbContext.CustomUsers.ToList();
            model.Roles = _appDbContext.Roles.ToList();
            model.UserRoles = _appDbContext.UserRoles.ToList();
            return View(model);
        }
        [Authorize(Roles="SuperAdmin")]
        public IActionResult UpdateUser(string id)
        {
            CustomUser user = _appDbContext.CustomUsers.Find(id);
            user.RoleId = _appDbContext.UserRoles.Where(ur=>ur.UserId == id).Select(d=>d.RoleId).FirstOrDefault().ToString();
            ViewBag.Roles = _appDbContext.Roles.ToList();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(CustomUser model)
        {
            if (ModelState.IsValid)
            {
                CustomUser user = _appDbContext.CustomUsers.Find(model.Id);
                user.Email = model.Email;
                user.UserName = model.Email;

                IdentityUserRole<string> userRole = _appDbContext.UserRoles.FirstOrDefault(u => u.UserId == model.Id);
                if (userRole != null)
                {
                    string oldRole = _appDbContext.Roles.Find(userRole.RoleId).Name;
                    await _userManager.RemoveFromRoleAsync(user, oldRole);
                }

                IdentityRole selectedRole = _appDbContext.Roles.Find(model.RoleId);

                await _userManager.AddToRoleAsync(user, selectedRole.Name);
                _appDbContext.SaveChanges();
                return RedirectToAction("Users");

            }
            return View(model);
        }
        [Authorize(Roles ="SuperAdmin")]
        public IActionResult Roles()
        {
            List<IdentityRole> roles = _appDbContext.Roles.ToList();
            return View(roles);
        }
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(IdentityRole model)
        {
            await _roleManager.CreateAsync(model);
            return RedirectToAction("Roles");
        }
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult RoleUpdate(string id)
        {
            IdentityRole role = null;
            if (id != null)
            {
                role = _appDbContext.Roles.FirstOrDefault(r => r.Id == id);
            }
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> RoleUpdate(IdentityRole model)
        {
            await _roleManager.UpdateAsync(model);
            _appDbContext.SaveChanges();
            return RedirectToAction("Roles");
        }
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult DeleteRole(string id)
        {
            IdentityRole role = null;
            if (id != null)
            {
                role = _appDbContext.Roles.FirstOrDefault(r => r.Id == id);
            }


            if (role != null)
            {
                _appDbContext.Roles.Remove(role);
                _appDbContext.SaveChanges();
                return RedirectToAction("Roles");
            }

            return View();
        }
    }
}
