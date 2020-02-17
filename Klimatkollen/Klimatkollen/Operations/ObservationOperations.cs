using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Operations
{
    public class ObservationOperations
    {
        public bool CanEditRoles(String Admin)
        {
            return Admin == "Admin";
        }
    }
}
