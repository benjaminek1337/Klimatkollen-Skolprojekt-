using Klimatkollen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.ViewModels
{
    public class ObservationViewModel
    {
        public Observation observation { get; set; }
        public Measurement measurement { get; set; }
        public MainCategory mainCategory { get; set; }
        public Category category { get; set; }
    }
}
