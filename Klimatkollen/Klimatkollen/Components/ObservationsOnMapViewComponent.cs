using Klimatkollen.Data;
using Klimatkollen.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Components
{
    public class ObservationsOnMapViewComponent : ViewComponent
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IRepository db;

        public ObservationsOnMapViewComponent(UserManager<IdentityUser> userManager, IRepository db)
        {
            this.db = db;
            this.userManager = userManager;

        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var measurements = db.GetAllMeasurements2();
            return View(measurements);
        }
    }
}
