using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Data
{
    public interface IRepository
    {
        List<string> GetObservationCategories();

        void AddObservation();
        Task<IEnumerable<string>> TestAsync();//TEST
    }
}
