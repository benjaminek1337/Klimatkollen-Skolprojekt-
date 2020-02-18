using Klimatkollen.Data;
using Klimatkollen.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Components
{
    public class UserObservationsViewComponent : ViewComponent
    {
        private readonly IRepository db;
        private readonly IUserRepository userdb;
        private readonly UserManager<IdentityUser> userManager;

        public UserObservationsViewComponent(UserManager<IdentityUser> userManager, IUserRepository userRepo, IRepository repo)
        {
            db = repo;
            userdb = userRepo;
            this.userManager = userManager;
        }
        private Task<IdentityUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await GetCurrentUserAsync();
            string userId = user?.Id;
            var person = userdb.GetPerson(userId);

            //var measurements = db.GetMeasurements(person.Id);
            var list = db.GetAllMeasurementsFromPerson(person);

            return View(list);
        }
    }
}
