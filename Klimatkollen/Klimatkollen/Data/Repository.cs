using Klimatkollen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klimatkollen.Models;

namespace Klimatkollen.Data
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext dbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        public String SerializeJsonFromFloats(List<float> floats)
        {
            throw new NotImplementedException();
        }

        public void WriteJsonToFile(String jsonString, String filePath)
        {
            throw new NotImplementedException();
        }

        public void AddObjectToDb(object objectToAdd)
        {
            throw new NotImplementedException();
        }

        public List<Observation> GetObservations()
        {
            var observations = new List<Observation>();
            foreach (var observation in dbContext.Observations)
            {
                //Skicka in person-id här
                //if(observation.Person.Id == id)
                observations.Add(observation);
            }
            return observations;
        }

        public Observation GetObservation(int id)
        {
            return dbContext.Observations.FirstOrDefault(o => o.Person.Id.Equals(id));
        }

        public void PostEditedObservation(Observation observation)
        {
            dbContext.Update(observation);
            dbContext.SaveChanges();
        }


        public List<MainCategory> GetMainCategoriesFromDb()
        {
            throw new NotImplementedException();
        }

        public MainCategory GetMainCategoryFromId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategoriesFromId(MainCategory cat)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryFromId(int id)
        {
            throw new NotImplementedException();
        }

        public List<ThirdCategory> GetThirdCategories(Category cat)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<float>> ChartAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Observation>> TestTableAsync()
        {
            throw new NotImplementedException();
        }
    }
}
