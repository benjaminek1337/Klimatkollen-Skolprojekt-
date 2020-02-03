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
            //List<String> cats = new List<string>() {"Djur", "Miljö", "Annan"};
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
                mainCategory = mainCat
            };

            List<String> category;
            switch (mainCat.CategoryName)
            {             
                //TODO: Värden ska hämtas från DB
                case "Djur":
                    category = new List<string>() { "Vildsvin", "Groda", "Ripa" };
                    ViewBag.list = category;
                    break;
                case "Miljö":
                    category = new List<string>() { "Väder", "Temperatur", "Vind" };
                    ViewBag.list = category;
                    break;
                case "Annan":
                    category = new List<string>() { "Annan 1", "Annan 2", "Annan 3" };
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
            //Hårdkodar lite data i objektet för att slippa fylla i hela tiden i vyn
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
            Measurement m = new Measurement()
            {
                Category = model.category
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
        public IActionResult ReportObservationCompleted(ObservationViewModel model)
        {
            Measurement m = new Measurement()
            {
                Category = model.category
            };
            Person p = new Person();

            //Konverterar ViewModel till ett objekt av Observation
            Observation finalObservation = new Observation()
            {
                //Inloggad person ska anges här
                Person = p,
                Comment = model.observation.Comment,
                Date = model.observation.Date,
                Longitude = model.observation.Longitude,
                Latitude = model.observation.Latitude,
                //MainCategory = model.mainCategory,
                Measurement = m
            };

            //Kod för att spara i DB
            db.AddObjectToDb(p);
            //db.AddObjectToDb(model.mainCategory);
            db.AddObjectToDb(m);
            db.AddObjectToDb(finalObservation);
            return View();
        }
    }


}