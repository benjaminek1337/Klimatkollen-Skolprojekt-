using Klimatkollen.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Components
{
    [ViewComponent(Name ="Observation")]
    public class ObservationViewComponent :ViewComponent 
    {
        private readonly IRepository db;

        public ObservationViewComponent(IRepository repository)
        {
            db = repository;
        }

        //KANSKE?
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var test = await db.TestAsync(); //Gör enmetod som returnerar en lista med djurobservationer
            return View(test);
        }
        //Metod som returnerar områden där ett djur synts till?
    }
}
