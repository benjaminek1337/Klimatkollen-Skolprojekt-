using Klimatkollen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.ViewModels
{
    public class ObservationFilterViewModel
    {
        public Observation Observation { get; set; }
        public List<Measurement> Measurements { get; set; }
        public Category Category { get; set; }
    }
}
