using Klimatkollen.Data;
using Klimatkollen.Models;
using Klimatkollen.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
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


            var all = db.GetAllMeasurements();
            



            var observations = new LandingPageFiltersViewModel();
            //var temp = new List<LandingPageFiltersViewModel>();
            //var x = new List<IEnumerable>();


            var q = db.GetAllObservationsBasedOnFilter(filters);



            ViewBag.Observations = q;
 

            return View();
        }
    }
}
