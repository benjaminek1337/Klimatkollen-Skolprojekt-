using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Klimatkollen.Models;
using Nancy.Json;
using Newtonsoft.Json;


namespace Klimatkollen.Data
{
    public class MockRepository : IRepository
    {
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

        public List<float> GenerateRandomFloats(int amount)
        {
            List<float> list = new List<float>();
            Random random = new Random();

            for (int i = 0; i < amount; i++)
            {              
                list.Add(random.Next(-2000, 2500)/100);
            }
            return list;
        }
        
        //private async Task SerializeFloatsAsync(List<float> list)
        //{
        //    var json = new JavaScriptSerializer().Serialize(list);


        //    File f = new File(json);
        //    Stream s = f.Open(FileMode.Create);
        //    BinaryFormatter b = new BinaryFormatter();
        //    b.Serialize(s, c);
        //    s.Close();
        //}
    }
}
