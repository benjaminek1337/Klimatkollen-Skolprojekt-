using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klimatkollen.Data;
using Microsoft.AspNetCore.Mvc;

namespace Klimatkollen.Controllers
{
    
    public class ObservationsController : Controller
    {
        private readonly IRepository observationDB;
        public ObservationsController(IRepository repository)
        {
            observationDB = repository;
        }
        public IActionResult Index()
        {
            ViewBag.MainCategories = observationDB.GetMainCategoriesFromDb();
            ViewBag.Categories = observationDB.GetAllCategories();

            //TODO: Hämta vanliga områdena ell liknande från DB
            ViewBag.Areas = new List<string>(){"Västernorrlands län", "Jämtlands län", "Lapplands län"};

            var list = observationDB.GetAllMeasurements();
            return View(list);
        }
    }
}