using Klimatkollen.Data;
using Klimatkollen.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserRepository db;

        public ProfileController(UserManager<IdentityUser> userManager, IUserRepository db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        private Task<IdentityUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        [HttpGet]
        public async Task<IActionResult> UserProfile(Person person)
        {

            var user = await GetCurrentUserAsync();
            string userId = user?.Id;
            person = db.GetPerson(userId);
            if (person == null)
            {  
                return RedirectToAction("Home", "Index");
            }
            if(person.FirstName == null || person.Lastname == null)
            {
                return RedirectToAction("RegisterUserInfo");
            }

            return View(person);
        }
        
        public async Task<IActionResult> RegisterUserInfo(Person person)
        {
            var user = await GetCurrentUserAsync();
            string userId = user?.Id;
            person = db.GetPerson(userId);
            person.Email = user.Email;
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(Person person)
        {
            var user = await GetCurrentUserAsync();
            if(user == null)
            {
                ViewBag.ErrorMessage = $"Användare kan inte hittas.";
                return RedirectToAction("Home", "Index");
            }
            else
            {
                person.IdentityId = user.Id;
                db.EditPerson(person);
                if (person.Email != user.Email)
                {
                    await userManager.SetEmailAsync(user, person.Email);
                    await userManager.SetUserNameAsync(user, person.Email);
                }
                return RedirectToAction("UserProfile");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword(string oldPassword, string newPassword)
        {
            var user = await GetCurrentUserAsync();
            if(user == null)
            {
                ViewBag.ErrorMessage = $"Användare kan inte hittas.";
                return RedirectToAction("Home", "Index");
            }
            else
            {
                await userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            }
            return RedirectToAction("UserProfile");
        }
    }
}
