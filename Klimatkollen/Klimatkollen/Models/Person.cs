using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Klimatkollen.Models
{
    public class Person
    {
        public int Id { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
}
