using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klimatkollen.Models;

namespace Klimatkollen.Data
{
    public class Repository : IRepository //
    {
        private readonly ApplicationDbContext dbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddObjectToDb(Observation model)
        {
            throw new NotImplementedException();
        }

        public void AddObservation()
        {
            throw new NotImplementedException();
        }

        public List<float> GenerateRandomFloats(int amountToGenerate)
        {
            throw new NotImplementedException();
        }

        public List<string> GetObservationCategories() 
        {
            return new List<String>() { "Animal", "Environment", "Other" };
        }
            
            
    }
}
