using Klimatkollen.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Components
{
    public class UserFilterViewComponent : ViewComponent
    {
        private readonly IRepository db;
        private readonly IUserRepository userdb;
        private readonly UserManager<IdentityUser> userManager;
        public UserFilterViewComponent(IRepository repository, UserManager<IdentityUser> userManager, IUserRepository userRepo)
        {
            db = repository;
            userdb = userRepo;
            this.userManager = userManager;
        }

        private Task<IdentityUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await GetCurrentUserAsync();
            string userId = user?.Id;
            var person = userdb.GetPerson(userId);

            if (person != null)
            {
                var filterList = db.GetUserFilters(person);
                return View(filterList);
            }
            return null;           
        }
    }
}
