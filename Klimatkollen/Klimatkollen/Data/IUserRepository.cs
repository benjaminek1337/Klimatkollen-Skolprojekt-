using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Data
{
    interface IUserRepository
    {
        private readonly ApplicationDbContext context;
        public IUserRepository(ApplicationDbContext context)
        {
            this context = context;
        }
    }
}
