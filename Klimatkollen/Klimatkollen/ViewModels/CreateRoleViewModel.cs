using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Namn på systemroll")]
        public string Rolename { get; set; }
    }
}
