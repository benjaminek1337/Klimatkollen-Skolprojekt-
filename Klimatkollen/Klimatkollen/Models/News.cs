using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Models
{
    public class News
    {
        public int NewsID { get; set; }
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Content { get; set; }

    }
}
