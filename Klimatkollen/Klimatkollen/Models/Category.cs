using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Models
{
    public class Category
    {
        public int Id { get; set; }
        public String Unit { get; set; } // Eg. Celcius, M/S 
        public String Type  { get; set; } // Eg. Vindstyrka
        public Category Categories { get; set; }
    }
}
