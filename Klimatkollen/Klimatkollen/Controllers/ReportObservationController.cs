using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Klimatkollen.Data;

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

            return View(observationCategories);
        }
    }
}