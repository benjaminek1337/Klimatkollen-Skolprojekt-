using Klimatkollen.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Components
{
    public class AddUserFilterViewComponent : ViewComponent 
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserRepository userDb;
        private readonly IRepository observationDb;

        public AddUserFilterViewComponent(IRepository repository, UserManager<IdentityUser> userManager, IUserRepository userRepo)
        {
            observationDb = repository;
            userDb = userRepo;
            this.userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.categories = observationDb.GetAllCategories();
            return View();
        }

    }
}
