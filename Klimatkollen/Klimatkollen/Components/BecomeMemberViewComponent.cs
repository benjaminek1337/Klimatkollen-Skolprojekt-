using Klimatkollen.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Components
{
    public class BecomeMemberViewComponent : ViewComponent
    {
        private readonly IRepository db;

        public BecomeMemberViewComponent(IRepository repository)
        {
            db = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(); 
        }
    }
}
