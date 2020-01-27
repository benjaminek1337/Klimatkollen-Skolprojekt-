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
        [Key]
        [Required(ErrorMessage = "Vänligen fyll i korrekt e-postadress")]
        [Display(Name = "E-postadress")]
        //[DataType(DataType.EmailAddress)]
        public String Email { get; set; }


        [Required(ErrorMessage = "Vänligen fyll i användarnamn")]
        [Display(Name = "Användarnamn")]
        public String UserName { get; set; }


        [Display(Name = "Förnamn")]
        public String FirstName { get; set; }


        [Display(Name = "Efternamn")]
        public String Lastname { get; set; }


    }
}
