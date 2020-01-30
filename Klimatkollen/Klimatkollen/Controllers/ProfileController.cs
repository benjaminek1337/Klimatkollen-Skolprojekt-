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

            IdentityUser user = await GetCurrentUserAsync();
            string userId = user?.Id;
            person = db.GetPerson(userId);
            if (person == null)
            {  
                return RedirectToAction("Home", "Index");
            }

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(Person person)
        {
            IdentityUser user = await GetCurrentUserAsync();
            if(user == null)
            {
                ViewBag.ErrorMessage = $"Användare kan inte hittas.";
                return RedirectToAction("Home", "Index");
            }
            else
            {
                db.EditPerson(person);
                if (person.Email != user.Email)
                {
                    await userManager.SetEmailAsync(user, person.Email);                    
                }
                else if (person.UserName != user.UserName)
                {
                    await userManager.SetUserNameAsync(user, person.UserName);
                }
                return RedirectToAction("UserProfile");
            }
            
        }
    }
}
