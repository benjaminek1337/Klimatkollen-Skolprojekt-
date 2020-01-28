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
        [Required]
        public Person person { get; set; }
        public DateTime Date { get; set; }
        public String Longitude { get; set; }
        public String Latitude { get; set; }
        public String Comment { get; set; }
        [Required]
        public Measurement measurement { get; set; }
    }
}
