using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klimatkollen.Models;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Net.Http;

namespace Klimatkollen.Data
{
    public class MockRepository : IRepository
    {
        private readonly ApplicationDbContext dbContext;
        public List<MainCategory> testList = new List<MainCategory>();//TEST
        public MockRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            MainCategory test = new MainCategory()//TEST
            {
                Id = 1,
                CategoryName = "Vinter"//TEST
            };
            testList.Add(test);
             test = new MainCategory()//TEST
             {
                Id = 2,
                CategoryName = "kulr"//TEST
             };
            testList.Add(test);//TEST
            //Observation ob=new Observation()
            //{

            //}
        }

        public List<string> GetObservationCategories()
        {
            return new List<String>() { "Animal", "Environment", "Other" };
        }

        public void AddObservation()
        {
            var person = new Person();
           // var measurementCategory = new MeasurementCategory() { measurementCategories = new List<MeasurementCategory> { new MeasurementCategory() {Value = "3" } } };
            var observation = new Observation() { Comment = "En kefefko", Date = DateTime.Now, Latitude = "l 232, 323, 323", Longitude = "1 ,234 ,342", Person = person  };
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
                using(StreamReader sr = new StreamReader(msObj))
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

        public List<MainCategory> GetMainCategoriesFromDb()
        {
            var persons = dbContext.Persons.ToList();


            int i = 2;
            return dbContext.MainCategories.ToList();
        }

        public async Task<IEnumerable<MainCategory>> TestAsync() //TEST
        {
            var result = testList;
            return await Task.FromResult(testList.ToList());
            //var result = GetMainCategoriesFromDb();
            //return await Task.FromResult(result.ToList());
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
        public async Task<IEnumerable<float>> TestChartAsync() //TEST CHART
        {
            List<float> testjson = new List<float>();
            foreach (var i in GenerateRandomFloats(50))
            {
                testjson.Add(i);
            };
            
            return await Task.FromResult(testjson.ToList());

        }
        public List<Observation> ShowObservationsTest()
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
                Category =c,
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
                Longitude="12",
                Person=p,
                Measurement=m,
                MainCategory=mc
            };AllObservations.Add(ob);
            ob = new Observation()
            {
                Id = 2,
                Date = DateTime.Now,
                Comment = "Jättefin katt igen",
                Latitude = "12",
                Longitude = "12",
                Person = p,
                Measurement = m,
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
                Measurement = m,
                MainCategory = mc
            }; AllObservations.Add(ob);

            return AllObservations;
        }
    }
}
