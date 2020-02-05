using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Klimatkollen.Models
{
    public class Observation
    {
        public int Id { get; set; }
        [Required]
        public Person Person { get; set; }
        public DateTime Date { get; set; }
        public String Longitude { get; set; }
        public String Latitude { get; set; }
        public String Comment { get; set; }
        [Required]
        public int measurementID { get; set; }
        [ForeignKey("measurementID")]
        public Measurement Measurement { get; set; }
        public int maincategoryId { get; set; }
        [ForeignKey("maincategoryId")]
        public MainCategory MainCategory { get; set; }
    }
}
