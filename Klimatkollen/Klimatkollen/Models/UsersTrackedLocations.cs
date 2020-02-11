using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Models
{
    public class UsersTrackedLocations
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Location { get; set; }

    }
}
