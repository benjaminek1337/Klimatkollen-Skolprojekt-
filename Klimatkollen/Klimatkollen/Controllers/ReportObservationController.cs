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
        public IActionResult ReportObservation_step2()
        {
            var observationCategories = db.GetObservationCategories();
            db.AddObservation();


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
}