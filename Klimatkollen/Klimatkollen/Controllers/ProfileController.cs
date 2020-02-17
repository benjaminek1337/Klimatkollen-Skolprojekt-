using Klimatkollen.Data;
using Klimatkollen.Models;
using Klimatkollen.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Klimatkollen.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserRepository db;
        private readonly IRepository observationdb;
        private readonly IHostingEnvironment hostingenv;

        public ProfileController(UserManager<IdentityUser> userManager, IUserRepository db, IRepository repository, IHostingEnvironment hostingenv)
        {
            this.userManager = userManager;
            this.db = db;
            observationdb = repository;
            this.hostingenv = hostingenv;
        }

        private Task<IdentityUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        private async Task<Person> GetPerson()
        {
            var user = await GetCurrentUserAsync();
            string userId = user?.Id;
            var person = db.GetPerson(userId);
            return person;
        }


        [HttpGet]
        public async Task<IActionResult> UserProfile(Person person)
        {
            person = await GetPerson();
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
        [ValidateAntiForgeryToken]
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
        [HttpGet]
        public async Task<IActionResult> EditUserObservation(int id) //Measurement measurement
        {
            var user = await GetCurrentUserAsync();
            string userId = user?.Id;
            //measurement = observationdb.GetMeasurement(measurement.Id);
            //measurement.Observation.Person = db.GetPerson(userId);

            var observation = observationdb.GetObservationWithMeasurement(id);
            //Kod för att hämta vald observation
            return View(observation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostEditUserObservation(ObservationFilterViewModel model, int measurmentValue, int measurmentId) //Measurement model
        {
            string fileName = null;
            if (model.CreateMeasurementViewModel.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingenv.WebRootPath, "pictures");
                fileName = Guid.NewGuid().ToString() + "_" + model.CreateMeasurementViewModel.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                model.CreateMeasurementViewModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                observationdb.UpdateMeasurementPhoto(measurmentId, fileName);
            }

            observationdb.UpdateObservation(model.Observation);

            if (!measurmentValue.Equals(0) && !measurmentId.Equals(0))
            {
                observationdb.UpdateMeasurmentValue(measurmentId, measurmentValue.ToString());
            }

            //var model = observationdb.GetObservationWithMeasurement(id);
            //observationdb.PostEditedMeasurement(model);
            return RedirectToAction("UserProfile");
        }

        public IActionResult DeletePhoto(int measurementid, int observationid, string photoname)
        {
            string uploadsFolder = Path.Combine(hostingenv.WebRootPath, "pictures");
            string filePath = Path.Combine(uploadsFolder, photoname);
            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    System.IO.File.Delete(filePath);
                }
                catch(Exception e)
                {
                    
                }

            }
            observationdb.DeleteMeasurementPhoto(measurementid);
            return RedirectToAction("EditUserObservation", new { id = observationid });
        }

        public IActionResult DeleteUserMeasurement(int id)
        {
            observationdb.DeleteMeasurement(id);
            return RedirectToAction("UserProfile");
        }
        public IActionResult DeleteObservation(int id)
        {
            observationdb.DeleteObservation(id);
            return RedirectToAction("UserProfile");
        }

        public async Task<IActionResult> UsersTrackedLocations()
        {
            var person = await GetPerson();
            ViewBag.Locations = db.GetUsersTrackedLocations(person);
            return View(); 
        }

        public async Task<IActionResult> SaveUsersTrackedLocation(UsersTrackedLocations model)
        {
            var person = await GetPerson();
            model.Person = person;
            db.AddUserTrackedLocation(model);
            
            return RedirectToAction("UsersTrackedLocations");
        }

        public IActionResult DeleteUsersTrackedLocation(int id)
        {
            db.DeleteUsersTrackedLocation(id);
            return RedirectToAction("UsersTrackedLocations");
        }

        public IActionResult EditUserFilters()
        {
            //ViewBag.mainCategories = observationdb.GetMainCategoriesFromDb();
            ViewBag.categories = observationdb.GetAllCategories();

            return View();
        }

        public async Task<IActionResult> AddUserFilter(Category category)
        {
            if (category.Id == 0)
            {
                return RedirectToAction("EditUserFilters");
            }

            var person = await GetPerson();

            category = observationdb.GetCategoryFromId(category.Id);
            UserFilter filter = new UserFilter()
            {
                FilterName = category.Type,
                Person = person,
                categoryId = category.Id,
            };
            
            observationdb.AddObjectToDb(filter);
            return RedirectToAction("EditUserFilters");
        }
        public async Task<IActionResult> RemoveUserFilter(int userFilterId)
        {
            if (userFilterId == 0)
            {
                return RedirectToAction("EditUserFilters");
            }

            var person = await GetPerson();

            UserFilter userFilter = observationdb.GetUserFilter(userFilterId);
            observationdb.RemoveObjectFromDb(userFilter);

            return RedirectToAction("EditUserFilters");
        }

    }
}
