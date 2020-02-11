using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Klimatkollen.Models;
using Klimatkollen.Data;
using Microsoft.AspNetCore.Authorization;


namespace Klimatkollen.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository db;
        public HomeController(IRepository repository)
        {
            db = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpGet]
        //public async Task<IActionResult> GetObservationByLonLat(string longitud, string latitud)
        //{

        //    return View();
        //}
    }
}
