using Klimatkollen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klimatkollen.Data
{
    public interface IRepository
    {
        List<string> GetObservationCategories();

        void AddObservation();

        List<float> GenerateRandomFloats(int amountToGenerate);

        String SerializeJsonFromFloats(List<float> floats);

        void WriteJsonToFile(String jsonString, String filePath);

        void AddObjectToDb(object objectToAdd);

        List<MainCategory> GetMainCategoriesFromDb();
        MainCategory GetMainCategoryFromId(int id);
    }
}
