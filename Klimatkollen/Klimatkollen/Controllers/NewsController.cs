using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klimatkollen.Data;
using Klimatkollen.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize(Roles = "Admin,grupp1superadmin")]
        public IActionResult AddNews()
        {
            
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,grupp1superadmin")] 
        public IActionResult AddNews(News news)
        {
            news = new News
            {
                Title = news.Title,
                Date = news.Date,
                Content = news.Content
            };
            newsDd.AddObjectToDb(news);
            return View();
        }
        [Authorize(Roles = "Admin,grupp1superadmin")] //måste den ligga här?
        public IActionResult RemoveNews(int newsId)
        {
            if (newsId == 0)
            {
                return RedirectToAction("AddnNews");
            }
            News news = newsDd.GetChoosenNews(newsId);
            newsDd.RemoveObjectFromDb(news);

            return RedirectToAction("AddNews");//Egentligen en bekräftelse på borttagningen
        }
    }
}