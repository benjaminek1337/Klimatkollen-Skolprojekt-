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
        private readonly IRepository repository;

        public ChartViewComponent(IRepository repository)
        {
            randomFloatGenerator = new RandomFloatGenerator();
            this.repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var temperatures = await repository.GetTemperatureObservationsAsync();
            return View(temperatures);
        }
    }
}
