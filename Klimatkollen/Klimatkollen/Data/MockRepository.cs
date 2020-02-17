using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klimatkollen.Models;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Klimatkollen.ViewModels;

namespace Klimatkollen.Data
{
    public class MockRepository : IRepository
    {
        private readonly ApplicationDbContext dbContext;
        public MockRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<string> GetObservationCategories()
        {
            return new List<String>() { "Animal", "Environment", "Other" };
        }

        public void AddObservation()
        {
            var person = new Person();
            // var measurementCategory = new MeasurementCategory() { measurementCategories = new List<MeasurementCategory> { new MeasurementCategory() {Value = "3" } } };
            var observation = new Observation() { Comment = "En kefefko", Date = DateTime.Now, Latitude = "l 232, 323, 323", Longitude = "1 ,234 ,342", Person = person };
        }

        public List<float> GenerateRandomFloats(int amountToGenerate)
        {
            var floats = new List<float>();
            Random random = new Random();

            for (int i = 0; i < amountToGenerate; i++)
            {
                floats.Add((float)random.NextDouble() * (25 - -20) - 20);
            }

            return floats;
        }


        public String SerializeJsonFromFloats(List<float> floats)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<float>));
            string json;
            using (MemoryStream msObj = new MemoryStream())
            {
                js.WriteObject(msObj, floats);
                msObj.Position = 0;
                using (StreamReader sr = new StreamReader(msObj))
                {
                    json = sr.ReadToEnd();
                }
            }

            return json;
        }

        public void WriteJsonToFile(String jsonString, String filePath)
        {
            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, jsonString);
            }
        }

        public void AddObjectToDb(object objectToAdd)
        {
            dbContext.Add(objectToAdd);
            dbContext.SaveChanges();
        }
        public void RemoveObjectFromDb(object objectToRemove)
        {
            dbContext.Remove(objectToRemove);
            dbContext.SaveChanges();
        }

        public List<Measurement> GetMeasurements(int id)
        {
            var measurements = new List<Measurement>();
            foreach (var measurement in dbContext.Measurements)
            {
                var newMeasurement = GetMeasurement(measurement.Id);
                if(newMeasurement.Observation.Person != null && newMeasurement.Observation.Person.Id == id)
                {
                    //var observation = dbContext.Observations.Where(o => o.Id.Equals(measurement.Id)).FirstOrDefault();
                    //newMeasurement.Observation = observation;
                    newMeasurement.ThirdCategory = dbContext.ThirdCategories.Where(x => x.Id.Equals(measurement.thirdCategoryId)).FirstOrDefault();

                    measurements.Add(newMeasurement);
                }
            }

            return measurements;
        }
        /// <summary>
        /// Gets all the measurments with observation in DB
        /// </summary>
        /// <returns>a list of measurments</returns>
        /// 
        public List<ObservationFilterViewModel> GetAllMeasurements()
        {
            List<ObservationFilterViewModel> observationsList = new List<ObservationFilterViewModel>();
            foreach (var observation in dbContext.Observations)
            {
                ObservationFilterViewModel model = new ObservationFilterViewModel();

                var newObservation = dbContext.Observations.Where(o => o.Id.Equals(observation.Id))
                    .Include(m => m.MainCategory)
                    .Include(p => p.Person)
                    .FirstOrDefault();
                var measurementsList = dbContext.Measurements.Where(m => m.observationId.Equals(observation.Id))
                    .Include(y => y.ThirdCategory)
                    .ToList();

                model.Observation = newObservation;
                model.Measurements = measurementsList;
                model.Category = dbContext.Categories.Where(c => c.Id.Equals(measurementsList[0].categoryId)).FirstOrDefault();

                if (model.Measurements[0].ThirdCategory == null)
                {
                    //Tomt objekt för att slippa få "null reference"
                    model.Measurements[0].ThirdCategory = new ThirdCategory();
                }

                observationsList.Add(model);
            }
            return observationsList;
        }
        public List<ObservationFilterViewModel> GetAllMeasurementsFromPerson(Person person)
        {
            List<ObservationFilterViewModel> observationsList = new List<ObservationFilterViewModel>();
            foreach (var observation in dbContext.Observations)
            {
                if (observation.Person == person)
                {
                    ObservationFilterViewModel model = new ObservationFilterViewModel();

                    var newObservation = dbContext.Observations.Where(o => o.Id.Equals(observation.Id))
                        .Include(m => m.MainCategory)
                        .Include(p => p.Person)
                        .FirstOrDefault();
                    var measurementsList = dbContext.Measurements.Where(m => m.observationId.Equals(observation.Id))
                        .Include(y => y.ThirdCategory)
                        .ToList();

                    model.Observation = newObservation;
                    model.Measurements = measurementsList;
                    model.Category = dbContext.Categories.Where(c => c.Id.Equals(measurementsList[0].categoryId)).FirstOrDefault();

                    if (model.Measurements[0].ThirdCategory == null)
                    {
                        //Tomt objekt för att slippa få "null reference"
                        model.Measurements[0].ThirdCategory = new ThirdCategory();
                    }

                    observationsList.Add(model);
                }
                
            }
            return observationsList;
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

                if (measurement.ThirdCategory == null)
                {
                    //Tomt objekt för att slippa få "null reference"
                    measurement.ThirdCategory = new ThirdCategory()
                    {
                        Category = new Category()
                    };
                }
                measurements.Add(measurement);
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
                .ThenInclude(z => z.MainCategory)
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
            updatedMeasurement.Observation.Country = measurement.Observation.Country;
            updatedMeasurement.Observation.Longitude = measurement.Observation.Longitude;
            updatedMeasurement.Observation.Date = measurement.Observation.Date;
            updatedMeasurement.Observation.Comment = measurement.Observation.Comment;
            updatedMeasurement.Value = measurement.Value;
            updatedMeasurement.Observation.Person = measurement.Observation.Person;

            dbContext.Update(updatedMeasurement);
            dbContext.SaveChanges();
        }
        public void UpdateObservation(Observation observation)
        {
            var newObservation = dbContext.Observations.Where(o => o.Id.Equals(observation.Id))
                .Include(p => p.Person)
                .Include(m => m.MainCategory)
                .FirstOrDefault();

            newObservation.Date = observation.Date;
            if (observation.Latitude != null || observation.Latitude != null)
            {
                newObservation.Longitude = observation.Longitude;
                newObservation.Latitude = observation.Latitude;
                newObservation.Place = observation.Place;
                newObservation.AdministrativeArea = observation.AdministrativeArea;
                newObservation.Country = observation.Country;
            }

            newObservation.Comment = observation.Comment;

            dbContext.Update(newObservation);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Updates the value in a measurement
        /// </summary>
        /// <param name="id">Id of measurement</param>
        /// <param name="value">New value</param>
        public void UpdateMeasurmentValue(int id, string value)
        {
            if (!id.Equals(0) && !string.IsNullOrEmpty(value))
            {
                var measurement = dbContext.Measurements.Where(m => m.Id.Equals(id))
                .Include(o => o.Observation)
                .Include(t => t.ThirdCategory)
                .Include(c => c.Category)
                .FirstOrDefault();

                measurement.Value = value;

                dbContext.Update(measurement);
                dbContext.SaveChanges();
            }
            
        }

        public void DeleteMeasurement(int id)
        {
            var measurement = GetMeasurement(id);
            dbContext.Remove(measurement);
            dbContext.SaveChanges();
        }
        public void DeleteObservation(int id)
        {
            var observation = dbContext.Observations.Where(o => o.Id.Equals(id)).FirstOrDefault();
            var measurements = dbContext.Measurements.Where(o => o.observationId.Equals(observation.Id)).ToList();

            foreach (var item in measurements)
            {
                dbContext.Remove(item);
            }
            dbContext.Remove(observation);
            dbContext.SaveChanges();
        }

        public List<MainCategory> GetMainCategoriesFromDb()
        {
            return dbContext.MainCategories.ToList();
        }
        public MainCategory GetMainCategoryFromId(int id)
        {
            return dbContext.MainCategories.Where(x => x.Id == id).FirstOrDefault();
        }
        public MainCategory GetMainCategoryFromCategoryObject(Category cat)
        {
            return dbContext.MainCategories.Where(x => x.Id.Equals(cat)).FirstOrDefault();
        }
        public List<Category> GetCategoriesFromId(MainCategory cat)
        {
            return dbContext.Categories.Where(x => x.MainCategory.Equals(cat)).ToList();
        }
        public List<Category> GetAllCategories()
        {
            return dbContext.Categories.ToList();
        }
        public Category GetCategoryFromId(int id)
        {
            return dbContext.Categories.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<ThirdCategory> GetThirdCategories(Category cat)
        {
            return dbContext.ThirdCategories.Where(x => x.Category.Id.Equals(cat.Id)).ToList();
        }
        public async Task<IEnumerable<float>> ChartAsync() //TEST CHART
        {
            List<float> testjson = new List<float>();
            foreach (var i in GenerateRandomFloats(50))
            {
                testjson.Add(i);
            };

            return await Task.FromResult(testjson.ToList());

        }
        public List<Observation> ShowObservationsTest()//Test Table OBSERVATION
        {
            List<Observation> AllObservations = new List<Observation>();
            Person p = new Person()
            {
                Id = 1,
                Email = "testc@.com",
                FirstName = "Lotta",
                Lastname = "lottasson",
                IdentityId = "1",
                UserName = "Lottlott"
            };
            Category c = new Category()
            {
                Id = 1,
                Unit = "katt",
                Type = "kat"
            };
            Measurement m = new Measurement()
            {
                Id = 1,
                Value = "13",
                //Category = c,
            };
            MainCategory mc = new MainCategory()
            {
                Id = 1,
                CategoryName = "Djur"
            };

            Observation ob = new Observation()
            {
                Id = 1,
                Date = DateTime.Now,
                Comment = "Jättefin katt",
                Latitude = "12",
                Longitude = "12",
                Person = p,
                //Measurement = m,
                MainCategory = mc
            }; AllObservations.Add(ob);
            ob = new Observation()
            {
                Id = 2,
                Date = DateTime.Now,
                Comment = "Jättefin katt igen",
                Latitude = "12",
                Longitude = "12",
                Person = p,
                //Measurement = m,
                MainCategory = mc
            }; AllObservations.Add(ob);
            ob = new Observation()
            {
                Id = 3,
                Date = DateTime.Now,
                Comment = "Jättefin katt igen",
                Latitude = "13",
                Longitude = "12",
                Person = p,
                //Measurement = m,
                MainCategory = mc
            }; AllObservations.Add(ob);

            return AllObservations;
        }
        public async Task<IEnumerable<Observation>> TestTableAsync() //TEST table observation
        {
            List<Observation> observationTestList = new List<Observation>();
            foreach (var i in ShowObservationsTest())
            {
                observationTestList.Add(i);
            };

            return await Task.FromResult(observationTestList.ToList());

        }

        public int GetLastObservationIdFromUser (Person p)
        {
            var observation = dbContext.Observations.Where(x => x.Person.Equals(p)).LastOrDefault();
            return observation.Id;
        }
        /// <summary>
        /// Gets a list of filters for a user
        /// </summary>
        /// <param name="p">The user</param>
        /// <returns></returns>
        public List<UserFilter> GetUserFilters(Person p)
        {
            return dbContext.UserFilters.Where(x => x.Person.Equals(p)).ToList();
        }

        /// <summary>
        /// Gets at specific User filter based on ID
        /// </summary>
        /// <param name="userFilterId">Id for the filter</param>
        /// <returns>A User filter object</returns>
        public UserFilter GetUserFilter (int userFilterId)
        {
            return dbContext.UserFilters.Where(x => x.Id.Equals(userFilterId)).FirstOrDefault();
        }

        public List<News> GetNews()
        {
            List<News> allNews = new List<News>();
            foreach (var item in dbContext.News)
            {
                allNews.Add(item);
            }

            allNews.Sort((x, y) => DateTime.Compare(y.Date, x.Date));

            return allNews;
        }
        public ObservationFilterViewModel GetObservationWithMeasurement(int id)
        {
            var model = new ObservationFilterViewModel();

            var newObservation = dbContext.Observations.Where(o => o.Id.Equals(id))
                        .Include(m => m.MainCategory)
                        .Include(p => p.Person)
                        .FirstOrDefault();
            var measurementsList = dbContext.Measurements.Where(m => m.observationId.Equals(id))
                        .Include(y => y.ThirdCategory)
                        .ToList();

            model.Observation = newObservation;
            model.Measurements = measurementsList;
            model.Category = dbContext.Categories.Where(c => c.Id.Equals(measurementsList[0].categoryId)).FirstOrDefault();

            if (model.Measurements[0].ThirdCategory == null)
            {
                //Tomt objekt för att slippa få "null reference"
                model.Measurements[0].ThirdCategory = new ThirdCategory();
            }

            return model;
        }

        public List<String> GetTopAreas(int num)
        {
            var test = dbContext.Observations
                   .GroupBy(q => q.AdministrativeArea)
                   .OrderByDescending(gp => gp.Count())
                   .Take(num)
                   .Select(g => g.Key).ToList();
            return test;
        }
        //public List<News> SortNewsByDate()
        //{
        //    List<News> sortNewsByDate = new List<News>();
        //    foreach (var item in dbContext.News)
        //    {
        //        sortNewsByDate.Add(item);
        //    }
        //    sortNewsByDate.Sort((x, y) => DateTime.Compare(x.Date, y.Date));

        //    return sortNewsByDate;
        //}
    }
}
