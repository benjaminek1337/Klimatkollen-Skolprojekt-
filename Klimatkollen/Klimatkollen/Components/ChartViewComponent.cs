using Klimatkollen.Data;
using Klimatkollen.ViewModels;
using Klimatkollen.Operations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Components
{
    public class ChartViewComponent : ViewComponent 
    {
        private readonly RandomFloatGenerator randomFloatGenerator;
        public ChartViewComponent(IRepository repository)
        {
            randomFloatGenerator = new RandomFloatGenerator();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var temperatures = await db.GetTemperatureObservationsAsync();
            return View(temperatures);
        }
    }
}
