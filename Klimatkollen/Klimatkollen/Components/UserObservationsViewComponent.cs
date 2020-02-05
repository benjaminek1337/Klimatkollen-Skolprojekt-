using Klimatkollen.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Components
{
    public class UserObservationsViewComponent : ViewComponent
    {
        private readonly IRepository db;

        public UserObservationsViewComponent(IRepository repo)
        {
            db = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var observation = db.GetObservations();
            return View(observation);
        }
    }
}
