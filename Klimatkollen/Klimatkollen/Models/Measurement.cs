using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public String Value { get; set; }
        //[Required]
        public Category Category { get; set; }
        public int CatId { get; set; }
    }
}
