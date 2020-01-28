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
            var observationCategories = db.GetObservationCategories();
            db.AddObservation();


            return View();
        }
        public IActionResult ReportObservation_step2(Observation model)
        {
            //var observationCategories = db.GetObservationCategories();
            //db.AddObservation();

            //TODO: En check som skickar tillbaka samma sida om kategori inte är vald
            return View(model);
        }
        public IActionResult ReportObservationStep1()
        {
            //Temp för att lista kategorier
            List<String> cats = new List<string>() {"Djur", "Miljö", "Annan"};
            ViewBag.Categories = cats;

            return View();
        }
        //public IActionResult GoToStepTwo(Observation model)
        //{
        //    //Testar att skicka vidare objekt till en annan sida. Objektet ska skickas vidare
        //    //Metoden ska döpas om så den redirectar till korrekt sida
        //    return View();
        //}
        

        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult AddObservation(Observation model)
        {
            
            return View(model);
        }
    }


}