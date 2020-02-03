using Klimatkollen.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Components
{
    public class ChartViewComponent : ViewComponent 
    {
        private readonly IRepository db;
        public ChartViewComponent(IRepository repository)
        {
            db = repository;
            //db.GenerateRandomFloats(50);

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var test = await db.ChartAsync();
            return View(test);
        }
    }
}
