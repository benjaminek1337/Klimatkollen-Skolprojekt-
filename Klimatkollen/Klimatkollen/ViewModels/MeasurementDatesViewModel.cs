using Klimatkollen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.ViewModels
{
    public class MeasurementDatesViewModel
    {
        public DateTime Date { get; set; }
        public float AvgTemp { get; set; }
    }
}
