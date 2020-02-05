using Klimatkollen.Data;
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
            return View();
        }
    }
}
