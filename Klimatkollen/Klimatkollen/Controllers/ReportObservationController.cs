using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Klimatkollen.Data;
using Klimatkollen.Models;

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
            var observationCategories = db.GetObservationCategories();
            db.AddObservation();
            var floats = db.GenerateRandomFloats(100);
            var jsonString =db.SerializeJsonFromFloats(floats);
            db.WriteJsonToFile(jsonString, "C:\\temperatures.json");

            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult AddObservation(Observation model)
        {
            //var aspUsername = User.Identity.Name;
            model.Comment = "Mycket vind idag";
            model.Date = DateTime.Now;
            model.measurement = new Measurement() { Category = new Category() { Unit = "Vind" }, Value = "14" };
            model.person = new Person() { Email = "test", UserName = "Ekiobon" };
            db.AddObjectToDb(model);

            return View(model);
        }
    }
}