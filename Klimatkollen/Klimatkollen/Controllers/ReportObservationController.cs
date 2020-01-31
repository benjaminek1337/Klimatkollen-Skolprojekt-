using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Klimatkollen.Data;
using Klimatkollen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Klimatkollen.Controllers
{
    public class ReportObservationController : Controller
    {
        private readonly IUserRepository userRepo;
        private readonly IRepository db;
        private readonly UserManager<IdentityUser> userManager;
        
        public ReportObservationController(IRepository repository, IUserRepository userRepo, UserManager<IdentityUser> userManager)
        {
            db = repository;
            this.userRepo = userRepo;
            this.userManager = userManager; 
        }

        private Task<IdentityUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        public IActionResult Index()
        {
            //var observationCategories = db.GetObservationCategories();
            //db.AddObservation();

            return View();
        }

        public async Task<Person> GetCurrentUser()
        {
            var identity = await GetCurrentUserAsync();
            var user = userRepo.GetPerson(identity.Id);
            Person person = user;
            return person;
        }

        public IActionResult ReportObservation_step2(Observation model)
        {
            if (model.MainCategory == null)
            {
                //Stannar på samma sida om ingen kategori är vald
                return RedirectToAction("ReportObservationStep1");
            }
            ////Kod för att spara observation i databasen
            var observationCategories = db.GetObservationCategories();
            db.AddObservation();
            //var floats = db.GenerateRandomFloats(100);
            //var jsonString =db.SerializeJsonFromFloats(floats);
            //db.WriteJsonToFile(jsonString, "C:\\temperatures.json");

            return View(model);
        }
        public IActionResult ReportObservationStep1()
        {
            //Temp för att lista kategorier i vyn
            List<String> cats = new List<string>() {"Djur", "Miljö", "Annan"};
            ViewBag.Categories = cats;

            return View();
        }

        
        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult AddObservation(Observation model)
        {
            //var aspUsername = User.Identity.Name;
            //var user = GetCurrentUserAsync();
            //string userId = user?.Id;
            //Person person = userRepo.GetPerson(userId);

            //model.Person = person;

            //Kommenterat ut pga dessa metoder för att ta fram person funkar inte för att av någon jävla anledning
            //så blir user.Id en INT!!!!!!!! DET SKA VA EN STRING, FUNKAR I PROFILECONTROLLER HELVETTE

            model.Comment = "Mycket vind idag";
            model.Date = DateTime.Now;
            model.Measurement = new Measurement() { Category = new Category() { Unit = "Vind" }, Value = "14" };
            model.Person = new Person() { Email = "test", UserName = "Ekiobon" };
            db.AddObjectToDb(model);

            return View(model);
        }
    }


}