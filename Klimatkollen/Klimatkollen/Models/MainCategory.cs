using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Models
{
    public class MainCategory
    {
        [Key]
        public int Id { get; set; }
        public String CategoryName { get; set; }
    }
}
