using Klimatkollen.Models;
using Klimatkollen.ViewModels;
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
        void RemoveObjectFromDb(object objectToRemove);

        List<MainCategory> GetMainCategoriesFromDb();
        MainCategory GetMainCategoryFromId(int id);
        MainCategory GetMainCategoryFromCategoryObject(Category cat);
        List<Category> GetCategoriesFromId(MainCategory cat);
        List<Category> GetAllCategories();
        Category GetCategoryFromId(int id);
        List<ThirdCategory> GetThirdCategories(Category cat);
        List<Measurement> GetMeasurements(int id);
        List<UserFilter> GetUserFilters(Person p);
        UserFilter GetUserFilter(int userFilterId);

        Measurement GetMeasurement(int id);
        List<ObservationFilterViewModel> GetAllMeasurements();
        List<ObservationFilterViewModel> GetAllMeasurementsFromPerson(Person p);
        void DeleteMeasurement(int id);
        void PostEditedMeasurement(Measurement measurement);

        //void GetMainCategoriesFromDb(object objectToAdd);
        Task<IEnumerable<float>> ChartAsync();//TEST Chart

        Task<IEnumerable<Observation>> TestTableAsync();
        int GetLastObservationIdFromUser(Person p);
        List<Measurement> GetAllMeasurements2();
        Task<IEnumerable<Measurement>> GetTemperatureObservationsAsync(MeasurementDatesViewModel viewmodel);
    }
}
