using Klimatkollen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.ViewModels
{
    public class MeasurementDatesViewModel
    {
        DateTime startDate { get; set; }
        DateTime endDate { get; set; }
        Measurement measurement { get; set; }
    }
}
