using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Models
{
    public class ThirdCategory
    {
        [Key]
        public int Id { get; set; }
        public String Unit { get; set; } // Eg. Celcius, M/S 
        public String Type { get; set; } // Eg. Vindstyrka
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
