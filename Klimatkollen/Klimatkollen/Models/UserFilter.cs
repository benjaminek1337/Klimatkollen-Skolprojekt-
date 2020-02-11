using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Models
{
    public class UserFilter
    {
        public int Id { get; set; }
        
        public Person Person { get; set; }
        //public int mainCategoryId { get; set; }
        //[ForeignKey("mainCategoryId")]
        //public MainCategory MainCategory { get; set; }
        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public Category Category { get; set; }
        public string FilterName { get; set; }
    }
}
