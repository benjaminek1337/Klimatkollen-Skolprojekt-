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
        public Measurement Measurement { get; set; }
        //public int mainCategoryId { get; set; }
        //[ForeignKey("mainCategoryId")]
        public MainCategory MainCategory { get; set; }
    }
}
