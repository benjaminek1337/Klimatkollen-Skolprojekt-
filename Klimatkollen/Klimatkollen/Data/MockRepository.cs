using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Data
{
    public class MockRepository : IRepository
    {
        public List<string> GetObservationCategories()
        {
            return new List<String>() { "Animal", "Environment", "Other" };
        }
    }
}
