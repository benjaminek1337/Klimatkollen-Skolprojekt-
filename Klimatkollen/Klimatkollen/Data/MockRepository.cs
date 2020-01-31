using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klimatkollen.Models;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

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

        public List<Observation> GetObservations()
        {
            var observations = new List<Observation>();
            MainCategory mc = new MainCategory() 
            {
                CategoryName = "Luft",
                Id = 1,
            };
            Person person = new Person()
            {
                Id = 1,
                FirstName = "Mattias",
                Lastname = "Kenttä",
                Email = "miss_kicki@hotmail.com"
            };
            Measurement measurement = new Measurement()
            {
                Id = 1,
                Value = "Vindhastighet"
            };
            Observation observation = new Observation()
            {
                Id = 1,
                Date = DateTime.Now,
                Latitude = "Norr om Antarktis",
                Longitude = "Väst om Amerikat",
                Comment = "Coolaste observationen i Norge",
                MainCategory = mc,
                Person = person,
                Measurement = measurement                
            }; observations.Add(observation);
            return observations;
        }

        public Observation GetObservation(int id)
        {
            MainCategory mc = new MainCategory()
            {
                CategoryName = "Luft",
                Id = 1,
            };
            Person person = new Person()
            {
                Id = 1,
                FirstName = "Mattias",
                Lastname = "Kenttä",
                Email = "miss_kicki@hotmail.com"
            };
            Measurement measurement = new Measurement()
            {
                Id = 1,
                Value = "Vindhastighet"
            };
            Observation observation = new Observation()
            {
                Id = 1,
                Date = DateTime.Now,
                Latitude = "Norr om Antarktis",
                Longitude = "Väst om Amerikat",
                Comment = "Coolaste observationen i Norge",
                MainCategory = mc,
                Person = person,
                Measurement = measurement
            };
            return observation;
        }
    }
}
