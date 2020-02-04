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
                testjson.Add(i);//Hur gör jag för att använda json-grejjen?!
            };

            return await Task.FromResult(testjson.ToList());

        }
        public async Task<IEnumerable<float>> TestChartAsync() //TEST CHART
        {
            List<float> testjson = new List<float>();
            foreach (var i in GenerateRandomFloats(50))
            {
                testjson.Add(i);//Hur gör jag för att använda json-grejjen?!
            };
            string hej = SerializeJsonFromFloats(testjson);
            WriteJsonToFile(hej, "~/Properties/jsondata.txt");//DETTa bör vara filen

            return await Task.FromResult(testjson.ToList());
            //using (var client = new HttpClient())
            //{
            //    var endPoint = "~/Properties/jsondata.txt";
            //    var json = await client.GetStringAsync(endPoint);
            //    return JsonConvert.DeserializeObject<List<float>>(json);
            //}

        }
        //public async Task<IEnumerable<Observation>> GetAllObservationsAsync() //Kanske skickain id för category
        //{
        //    var result = testList;
        //    return await Task.FromResult(testList.ToList());
        //    //var result = GetMainCategoriesFromDb();
        //    //return await Task.FromResult(result.ToList());
        //}
    }
}
