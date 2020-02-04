using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public String Value { get; set; }
        //[Required]

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int thirdCategoryId { get; set; }
        [ForeignKey("thirdCategoryId")]
        public ThirdCategory ThirdCategory { get; set; }
    }
}
