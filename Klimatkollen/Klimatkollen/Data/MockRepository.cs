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

        public List<Observation> GetObservations(int id)
        {
            var observations = new List<Observation>();
            foreach (var observation in dbContext.Observations)
            {
                
                //Skicka in person-id här
                if (observation.Person != null && observation.Person.Id == id)
                {
                    //var measurement = dbContext.Measurements.Where(m => m.Id.Equals(observation.measurementID)).FirstOrDefault();
                    //observation.Measurement = measurement;
                    //observation.Measurement.ThirdCategory = dbContext.ThirdCategories.Where(x => x.Id.Equals(observation.Measurement.thirdCategoryId)).FirstOrDefault();

                    observations.Add(observation);
                }
            }
            return observations;
        }

        public Observation GetObservation(int id)
        {
            //Här
            //var observation = dbContext.Observations.Include(x => x.Measurement)
            //    .ThenInclude(y => y.ThirdCategory)
            //    .FirstOrDefault(o => o.Id.Equals(id));


            var newObservation = dbContext.Measurements.Include(x => x.Observation)
                .Include(y => y.ThirdCategory)
                .FirstOrDefault(o => o.Id.Equals(id));

            //observation.Measurement = dbContext.Measurements.Where(m => m.Id.Equals(observation.measurementID)).FirstOrDefault();
            //observation.Measurement.ThirdCategory = dbContext.ThirdCategories.Where(x => x.Id.Equals(observation.Measurement.thirdCategoryId)).FirstOrDefault();


            //return observation;
            //return newObservation;
            return null;
        }

        public void PostEditedObservation(Observation observation)
        {
            var oldobservation = GetObservation(observation.Id);

            var updatedObservation = oldobservation;
            updatedObservation.Latitude = observation.Latitude;
            updatedObservation.Longitude = observation.Longitude;
            updatedObservation.Date = observation.Date;
            updatedObservation.Comment = observation.Comment;
            //updatedObservation.Measurement.Value = observation.Measurement.Value;
            updatedObservation.Person = observation.Person;

            dbContext.Update(updatedObservation);
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

        public List<UserFilter> GetUserFilters(Person p)
        {
            return dbContext.UserFilters.Where(x => x.Person.Equals(p)).ToList();
        }
    }
    }
