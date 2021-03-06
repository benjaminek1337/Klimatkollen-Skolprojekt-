﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Klimatkollen.Data;
using Klimatkollen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Klimatkollen.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IUserRepository userDb;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public LoginModel(SignInManager<IdentityUser> signInManager
            , ILogger<LoginModel> logger
            , IUserRepository userDb
            , UserManager<IdentityUser> userManager
            , RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            this.userDb = userDb;
            this.userManager = userManager;
            this._roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            if(await userManager.FindByNameAsync("grupp1superadmin@cool.se") == null)
            {
                var superadmin = new IdentityUser
                {
                    Email = "grupp1superadmin@cool.se",
                    UserName = "grupp1superadmin@cool.se"
                };
                var result = await userManager.CreateAsync(superadmin, "superadminärcool");
                if(result.Succeeded)
                {
                    
                    if (await _roleManager.FindByNameAsync("grupp1superadmin") == null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole { Name = "grupp1superadmin" });
                        var role = await _roleManager.FindByNameAsync("grupp1superadmin");
                        await userManager.AddToRoleAsync(superadmin, role.Name);
                    }
                    else if(await _roleManager.FindByNameAsync("grupp1superadmin") != null)
                    {
                        var role = await _roleManager.FindByNameAsync("grupp1superadmin");
                        await userManager.AddToRoleAsync(superadmin, role.Name);
                    }

                    Person person = new Person
                    {
                        IdentityId = superadmin.Id,
                        Email = superadmin.Email,
                        FirstName = "Super",
                        Lastname = "Admin"
                    }; userDb.AddPerson(person);
                }
            }

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(Input.Email);

                    if(await _roleManager.FindByNameAsync("Klimatobservatör") == null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole { Name = "Klimatobservatör" });
                    }
                    if (!await userManager.IsInRoleAsync(user, "Klimatobservatör"))
                    {
                        await userManager.AddToRoleAsync(user, "Klimatobservatör");
                    }

                    if (userDb.GetPerson(user.Id) == null)
                    {
                        Person person = new Person
                        {
                            IdentityId = user.Id,
                            Email = user.Email
                        }; userDb.AddPerson(person);
                    }
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction("Index", "Home");
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
