using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Roles = new List<string>();
        }

        public string Id { get; set; }
        [Required]
        [Display (Name = "Användarnamn")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "E-postadress")]
        public string Email { get; set; }
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }
        public IList<string> Roles { get; set; }
    }
}
