﻿using Klimatkollen.Models;
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
        News GetChoosenNews(int newsId);
        List<News> GetNews();

        Measurement GetMeasurement(int id);
        ObservationFilterViewModel GetObservationWithMeasurement(int id);
        List<ObservationFilterViewModel> GetAllMeasurements();
        List<ObservationFilterViewModel> GetAllMeasurementsFromPerson(Person p);
        void DeleteMeasurement(int id);
        void DeleteObservation(int id);
        void PostEditedMeasurement(Measurement measurement);
        void UpdateObservation(Observation observation);
        void UpdateMeasurmentValue(int id, string value);

        Task<IEnumerable<Observation>> TestTableAsync();
        int GetLastObservationIdFromUser(Person p);
        List<Measurement> GetAllMeasurements2();
        Task<IEnumerable<MeasurementDatesViewModel>> GetTemperatureObservationsAsync();
        List<String> GetTopAreas(int num);
        void UpdateMeasurementPhoto(int id, string filePath);
        void DeleteMeasurementPhoto(int id);
    }
}
