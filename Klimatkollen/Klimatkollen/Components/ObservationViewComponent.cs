using Klimatkollen.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Components
{
    [ViewComponent(Name = "Observation")]
    public class ObservationViewComponent :ViewComponent 
    {
        private readonly IRepository db;
        public ObservationViewComponent(IRepository repository)
        {
            db = repository;
            //db.GenerateRandomFloats(50);

        }

        //KANSKE?
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var test = await db.TestTableAsync(); 
            return View(test);
        }
    }
}
