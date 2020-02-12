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
    public class UserFilterObservationsViewComponent : ViewComponent
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IRepository db;
        private readonly IUserRepository userdb;

        public UserFilterObservationsViewComponent(UserManager<IdentityUser> userManager, IRepository db, IUserRepository userdb)
        {
            this.db = db;
            this.userManager = userManager;
            this.userdb = userdb;

        }
        private Task<IdentityUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        //private async Task<Person> GetPerson()
        //{
        //    var user = await GetCurrentUserAsync();
        //    string userId = user?.Id;
        //    var person = userdb.GetPerson(userId);
        //    return person;
        //}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await GetCurrentUserAsync();
            string userId = user?.Id;
            var person = userdb.GetPerson(userId);


            var locations = userdb.GetUsersTrackedLocations(person);
            //ViewBag.Locations = locations;

            var filters = db.GetUserFilters(person);
            //ViewBag.Filters = filters;

            db.GetAllObservationsBasedOnFilter(filters[0].categoryId);

            return View();
        }
    }
}
