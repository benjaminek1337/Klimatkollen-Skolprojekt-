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
        void DeleteMeasurement(int id);
        void PostEditedMeasurement(Measurement measurement);

        Task<IEnumerable<Observation>> TestTableAsync();
        int GetLastObservationIdFromUser(Person p);
    }
}
