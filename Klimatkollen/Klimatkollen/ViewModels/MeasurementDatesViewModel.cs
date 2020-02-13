using Klimatkollen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.ViewModels
{
    public class MeasurementDatesViewModel
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Measurement measurement { get; set; }
    }
}
