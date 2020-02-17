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

            //Hämtar vanligaste områden
            ViewBag.Areas = observationDB.GetTopAreas(5);

            var list = observationDB.GetAllMeasurements();
            return View(list);
        }
    }
}