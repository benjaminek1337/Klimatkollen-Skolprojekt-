using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Models
{
    public class MeasurementCategory
    {
        public int Id { get; set; }
        public String Value { get; set; } 
        public List<MeasurementCategory> measurementCategories { get; set; }
    }
}
