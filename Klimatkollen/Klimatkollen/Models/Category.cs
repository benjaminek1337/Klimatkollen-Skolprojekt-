using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Klimatkollen.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public String Unit { get; set; } // Eg. Celcius, M/S 
        public String Type { get; set; } // Eg. Vindstyrka
        //public Category Categories { get; set; }
        //public int mainCategoryId { get; set; }
        //[ForeignKey("mainCategoryId")]
        public MainCategory MainCategory { get; set; }
    }
}
