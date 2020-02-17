using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klimatkollen.Data;
using Microsoft.AspNetCore.Mvc;

namespace Klimatkollen.Controllers
{
    public class NewsController : Controller
    {
        public readonly IRepository newsDd;

        public NewsController(IRepository repository)
        {
            newsDd = repository;
        }
        public IActionResult Index()
        {
            ViewBag.News = newsDd.GetNews();
            var list = newsDd.GetNews();
            return View(list);
        }
    }
}