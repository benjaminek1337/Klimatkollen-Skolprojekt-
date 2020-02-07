using Klimatkollen.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Data
{
    public class Repository : IRepository
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

        public List<Measurement> GetMeasurements(int id)
        {
            var measurements = new List<Measurement>();
            foreach (var measurement in dbContext.Measurements)
            {
                if (measurement.Observation.Person != null && measurement.Observation.Person.Id == id)
                {
                    var observation = dbContext.Observations.Where(o => o.Id.Equals(measurement.Id)).FirstOrDefault();
                    measurement.Observation = observation;
                    measurement.ThirdCategory = dbContext.ThirdCategories.Where(x => x.Id.Equals(measurement.thirdCategoryId)).FirstOrDefault();

                    measurements.Add(measurement);
                }
            }

            return measurements;
        }

        public Measurement GetMeasurement(int id)
        {
            //Här
            //var observation = dbContext.Observations.Include(x => x.Measurement)
            //    .ThenInclude(y => y.ThirdCategory)
            //    .FirstOrDefault(o => o.Id.Equals(id));

            var measurement = dbContext.Measurements.Include(x => x.Observation)
                .Include(y => y.ThirdCategory)
                .FirstOrDefault(m => m.Id.Equals(id));

            return measurement;
        }

        public void PostEditedMeasurement(Measurement measurement)
        {
            var updatedMeasurement = GetMeasurement(measurement.Id);

            updatedMeasurement.Observation.Latitude = measurement.Observation.Latitude;
            updatedMeasurement.Observation.Longitude = measurement.Observation.Longitude;
            updatedMeasurement.Observation.Date = measurement.Observation.Date;
            updatedMeasurement.Observation.Comment = measurement.Observation.Comment;
            updatedMeasurement.Value = measurement.Value;
            updatedMeasurement.Observation.Person = measurement.Observation.Person;

            dbContext.Update(updatedMeasurement);
            dbContext.SaveChanges();
        }

        public void DeleteMeasurement(int id)
        {
            var measurement = GetMeasurement(id);
            dbContext.Remove(measurement);
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

        public List<UserFilter> GetUserFilters(Person p)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }


    }
}
