using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Klimatkollen.Data;
using Klimatkollen.Models;
using Microsoft.AspNetCore.Http;

namespace Klimatkollen.Controllers
{
    public class ReportObservationController : Controller
    {
        private readonly IRepository db;
        
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
        public IActionResult ReportObservation_step2(MainCategory mainCat)
        {
            if (mainCat.CategoryName == null)
            {
                //Stannar på samma sida om ingen kategori är vald
                return RedirectToAction("ReportObservationStep1");
            }
            
            //var floats = db.GenerateRandomFloats(100);
            //var jsonString =db.SerializeJsonFromFloats(floats);
            //db.WriteJsonToFile(jsonString, "C:\\temperatures.json");

            Observation observation = new Observation()
            {
                MainCategory = mainCat
                //TODO: Id måste sättas också
            };


            return View(observation);
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
            //testKod för att spara observation i db
            model.Comment = "Mycket vind idag";
            model.Date = DateTime.Now;
            model.Measurement = new Measurement() { Category = new Category() { Unit = "Vind" }, Value = "14" };
            model.Person = new Person() { Email = "test", UserName = "Ekiobon" };
            db.AddObjectToDb(model);
           
            return View(model);
        }
    }


}