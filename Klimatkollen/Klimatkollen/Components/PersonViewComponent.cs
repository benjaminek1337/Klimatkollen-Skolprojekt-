using Klimatkollen.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Components
{
    public class PersonViewComponent: ViewComponent 
    {
        private readonly IRepository db;

        public PersonViewComponent(IRepository repository)
        {
            db = repository;
        }
        //public async Task<IViewComponentResult> Invoke()
        //{
        //    var persons= db.
        //}
    }
}
