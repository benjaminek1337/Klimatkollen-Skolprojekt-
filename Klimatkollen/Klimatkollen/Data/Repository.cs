using Klimatkollen.Models;
using Klimatkollen.ViewModels;
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
            updatedMeasurement.Observation.Place = measurement.Observation.Place;
            updatedMeasurement.Observation.AdministrativeArea = measurement.Observation.AdministrativeArea;
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

        public int GetLastObservationIdFromUser(Person p)
        {
            throw new NotImplementedException();
        }

        public MainCategory GetMainCategoryFromCategoryObject(Category cat)
        {
            throw new NotImplementedException();
        }

        public UserFilter GetUserFilter(int userFilterId)
        {
            throw new NotImplementedException();
        }

        public void RemoveObjectFromDb(object objectToRemove)
        {
            throw new NotImplementedException();
        }

        public List<ObservationFilterViewModel> GetAllMeasurements()
        {
            throw new NotImplementedException();
        }

        public List<Measurement> GetAllMeasurements2()
        {
            var measurements = new List<Measurement>();
            foreach (var item in dbContext.Measurements)
            {
                var measurement = dbContext.Measurements.Include(x => x.Observation)
                .ThenInclude(z => z.MainCategory)
                .Include(y => y.ThirdCategory)
                .ThenInclude(a => a.Category)
                .FirstOrDefault(m => m.Id.Equals(item.Id));
                measurements.Add(measurement);
            }
            return measurements;
        }

        public List<ObservationFilterViewModel> GetAllMeasurementsFromPerson(Person p)
        {
            throw new NotImplementedException();
        }

        public ObservationFilterViewModel GetObservationWithMeasurement(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateObservation(Observation observation)
        {
            throw new NotImplementedException();
        }

        public void UpdateMeasurmentValue(int id, string value)
        {
            throw new NotImplementedException();
        }

        public void DeleteObservation(int id)
        {
            throw new NotImplementedException();
        }

        public List<string> GetTopAreas(int num)
        {
            throw new NotImplementedException();
        }
    }
}
