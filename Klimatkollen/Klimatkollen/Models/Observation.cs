using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Klimatkollen.Models
{
    public class Observation
    {
        public int Id { get; set; }
        [Required]
        public Person Person { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public String Longitude { get; set; }
        public String Latitude { get; set; }
        public String Place { get; set; }
        public String AdministrativeArea { get; set; }
        public String Country { get; set; }
        public String Comment { get; set; }
        public int maincategoryId { get; set; }
        [ForeignKey("maincategoryId")]
        public MainCategory MainCategory { get; set; }
    }
}
