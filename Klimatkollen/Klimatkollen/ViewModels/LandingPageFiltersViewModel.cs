using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.ViewModels
{
    public class LandingPageFiltersViewModel
    {
        public List<ObservationFilterViewModel> observations { get; set; }

        public LandingPageFiltersViewModel()
        {
            observations = new List<ObservationFilterViewModel>();
        }
    }
}
