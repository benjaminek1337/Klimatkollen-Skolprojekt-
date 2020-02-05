﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Klimatkollen.Data;
using Klimatkollen.Models;
using Microsoft.AspNetCore.Http;
using Klimatkollen.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Klimatkollen.Controllers
{
    public class ReportObservationController : Controller
    {
        private readonly IRepository db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserRepository userDb;
        private Task<IdentityUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);

        public ReportObservationController(IRepository repository, IUserRepository userRepository, UserManager<IdentityUser> userManager)
        {
            this.db = repository;
            this.userManager = userManager;
            this.userDb = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReportObservationStep1()
        {
            //Hämtar MainCategories från db
            ViewBag.Categories = db.GetMainCategoriesFromDb();

            return View();
        }
        public IActionResult ReportObservationStep2(MainCategory mainCat)
        {
            if (mainCat.Id == 0)
            {
                //Stannar på samma sida om ingen kategori är vald. Ska inte gå men man vet aldrig
                return RedirectToAction("ReportObservationStep1");
            }

            mainCat = db.GetMainCategoryFromId(mainCat.Id); //Hämtar Namn på MainCat
            ObservationViewModel ob = new ObservationViewModel() //Skapar ViewModel
            {
                mainCategory = db.GetMainCategoryFromId(mainCat.Id)
            };

            ViewBag.newList = db.GetCategoriesFromId(mainCat);

            //Skickar tillbaka en vymodell
            return View(ob);
        }

        public IActionResult ReportObservationStep3(ObservationViewModel model)
        {
            model.category = db.GetCategoryFromId(model.category.Id);
            Observation o = new Observation()
            {
                //Laddar dagens datum som default
                Date = DateTime.Today,
            };
            model.observation = o;

            //Hämtar underkategori baserat på vad som valts
            var list = db.GetThirdCategories(model.category);
            ViewBag.IsValueEnable = CheckList(list);

            ViewBag.thirdCategories = list;

            if (model.category.Unit.Equals("Päls"))
            {
                //filtrerar listan om det gäller päls
                ViewBag.thirdCategories = list.Where(x => x.Unit.Equals("Päls"));
                ViewBag.environment = list.Where(x => x.Unit.Equals("Miljö"));
            }

            return View(model);
        }

        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult AddObservation(ObservationViewModel model)
        {
            Measurement m = new Measurement()
            {
                //Category = model.category
            };
            //Konverterar ViewModel till ett objekt av Observation
            Observation finalObservation = new Observation()
            {
                Comment = model.observation.Comment,
                Date = model.observation.Date,
                Longitude = model.observation.Longitude,
                Latitude = model.observation.Latitude,
                MainCategory = model.mainCategory,
                Measurement = m
            };

            //db.AddObjectToDb(finalOb);          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReportObservationCompleted(ObservationViewModel model)
        {
            if (model.measurement.thirdCategoryId == 0)
            {
                //TODO: Fixa fullösning
                model.measurement.thirdCategoryId = 11;
            }
            Measurement newMeasurement = new Measurement()
            {
                //Category = model.category,
                Value = model.measurement.Value,
                //CategoryId = model.category.Id,
                thirdCategoryId = model.measurement.thirdCategoryId
            };

            var user = await GetCurrentUserAsync();
            string userId = user?.Id;
            var person = userDb.GetPerson(userId);

            //Konverterar ViewModel till ett objekt av Observation
            Observation finalObservation = new Observation()
            {
                Person = person,
                Comment = model.observation.Comment,
                Date = model.observation.Date,
                Longitude = model.observation.Longitude,
                Latitude = model.observation.Latitude,
                Measurement = newMeasurement,
                maincategoryId = model.mainCategory.Id
            };

            //Kod för att spara i DB
            db.AddObjectToDb(newMeasurement);
            db.AddObjectToDb(finalObservation);
            return View();
        }
        private bool CheckList(List<ThirdCategory> list)
        {
            if (list.Any(x => x.Unit.Contains("Päls")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}