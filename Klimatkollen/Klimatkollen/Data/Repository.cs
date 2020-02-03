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
    }
}
