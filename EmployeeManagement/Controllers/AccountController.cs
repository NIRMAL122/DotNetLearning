﻿using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInMangaer;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInMangaer)
        {
            this.userManager = userManager;
            this.signInMangaer = signInMangaer;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result= await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInMangaer.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }


                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
    }
}
