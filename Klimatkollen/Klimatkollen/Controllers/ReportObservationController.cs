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
        public IActionResult ReportObservation_step2()
        {
            var observationCategories = db.GetObservationCategories();
            db.AddObservation();


            return View();
        }
        public IActionResult ReportObservationStep1()
        {
            //Temp för att lista kategorier
            List<String> cats = new List<string>() {"Animal", "Environment", "Other"};
            ViewBag.Categories = cats;

            return View();
        }
        public IActionResult GoToStepTwo(Observation model)
        {
            //Testar att skicka vidare objekt till en annan sida. Objektet ska skickas vidare
            return View();
        }
        

        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult AddObservation(Observation model)
        {
            
            return View(model);
        }
    }

    //public IActionResult Index()
    //{
    //    var observationCategories = db.GetObservationCategories();
    //    db.AddObservation();


    //    return View();
    //}
}