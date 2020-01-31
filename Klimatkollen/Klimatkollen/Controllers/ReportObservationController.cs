using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Klimatkollen.Data;
using Klimatkollen.Models;
using Microsoft.AspNetCore.Http;
using Klimatkollen.ViewModels;

namespace Klimatkollen.Controllers
{
    public class ReportObservationController : Controller
    {
        private readonly IRepository db;
       // ObservationViewModel newModel = new ObservationViewModel();
        
        public ReportObservationController(IRepository repository)
        {
            db = repository;          
        }
        public IActionResult Index()
        {
            //var observationCategories = db.GetObservationCategories();
            //db.AddObservation();

            return View();
        }
 
        public IActionResult ReportObservationStep1()
        {
            //Temp för att lista kategorier i vyn
            List<String> cats = new List<string>() {"Djur", "Miljö", "Annan"};
            ViewBag.Categories = cats;


            //Här hanteras MainCategory
            return View();
        }
        public IActionResult ReportObservationStep2(MainCategory mainCat)
        {
            if (mainCat.CategoryName == null)
            {
                //Stannar på samma sida om ingen kategori är vald
                return RedirectToAction("ReportObservationStep1");
            }

           

            ObservationViewModel ob = new ObservationViewModel()
            {
                mainCategory = mainCat
                //TODO: Id måste sättas också
            };
            List<String> category;
            switch (mainCat.CategoryName)
            {
                case "Djur":
                    category = new List<string>() { "Vildsvin", "Groda", "Ripa" };
                    ViewBag.list = category;
                    break;
                case "Miljö":
                    category = new List<string>() { "Väder", "Temperatur", "Vind" };
                    ViewBag.list = category;
                    break;
                case "Annan":
                    category = new List<string>() { "Annan 1", "annan 2", "Annan 3" };
                    ViewBag.list = category;
                    break;
                default:
                    break;
            }
            
            //Skickar tillbaka en vymodell
            return View(ob);
        }

        public IActionResult ReportObservationStep3(ObservationViewModel model)
        {
            //Hårdkodar lite data för vyn för att slippa fylla i hela tiden
            //DateTime date = new DateTime();
            //date = DateTime.Today;

            Observation o = new Observation() {
                Date = DateTime.Today,
                Latitude = "12.112.3113",
                Longitude = "12757.113",
                Comment = "Det här är en kommentar"
            };
            model.observation = o;


            return View(model);
        }



        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult AddObservation(ObservationViewModel model)
        {
            Measurement tempMeasurement = new Measurement()
            {
                Category = model.category
            };
            //testKod för att spara observation i db
            Observation finalOb = new Observation()
            {
                Comment = model.observation.Comment,
                Date = model.observation.Date,
                Longitude = model.observation.Longitude,
                Latitude = model.observation.Latitude,
                MainCategory = model.mainCategory,
                Measurement = tempMeasurement
            };
            //model.Comment = "Mycket vind idag";
            //model.Date = DateTime.Now;
            //model.Measurement = new Measurement() { Category = new Category() { Unit = "Vind" }, Value = "14" };
            //model.Person = new Person() { Email = "test", UserName = "Ekiobon" };


            //db.AddObjectToDb(finalOb);
           
            return View();
        }
        public IActionResult ReportObservationCompleted()
        {
          
            return View();
        }
    }


}