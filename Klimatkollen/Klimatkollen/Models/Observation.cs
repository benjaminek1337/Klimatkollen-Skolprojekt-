using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Klimatkollen.Models
{
    public class Observation
    {
        public int Id { get; set; }
        public Person person { get; set; }
        public DateTime Date { get; set; }
        public String Longitude { get; set; }
        public String Latitude { get; set; }
        public String Comment { get; set; }
        public MeasurementCategory measurementCategory { get; set; }
        public String CategoryTemp { get; set; }
    }
}
