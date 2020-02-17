using Klimatkollen.Data;
using Klimatkollen.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Components
{
    public class SeeObservationsViewComponent : ViewComponent
    {
        
        private readonly IRepository db;

        public SeeObservationsViewComponent(IRepository repository)
        {
            db = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = db.GetNews();
            List<News> sorted = new List<News>();

            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0 || i == 1 || i == 2)
                {
                    sorted.Add(list[i]);
                }
                else
                {
                    break;
                }
            }

            return View(sorted);
        }
    }
}
