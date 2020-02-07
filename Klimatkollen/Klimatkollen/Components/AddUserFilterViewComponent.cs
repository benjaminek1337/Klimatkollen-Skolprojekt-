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
        private Task<IdentityUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await GetCurrentUserAsync();
            string userId = user?.Id;
            var person = userDb.GetPerson(userId);

            var allCategories = observationDb.GetAllCategories();
            var userFilters = observationDb.GetUserFilters(person);
            List<Category> filteredList = observationDb.GetAllCategories();

            foreach (var item in allCategories)
            {
                if (userFilters.Any(x => x.categoryId.Equals(item.Id)))
                {
                    filteredList.Remove(item);
                }
                //else
                //{
                //    filteredList.Add(item);
                //}
            }

            ViewBag.categories = filteredList;
            return View();
        }
    }
}
