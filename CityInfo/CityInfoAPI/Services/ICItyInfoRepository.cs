using CityInfoAPI.Entities;
using System.Collections.Generic;

namespace CityInfoAPI.Services
{
    public interface ICityInfoRepository
    {
        // IQueryable<City> GetCities();
        IEnumerable<City> GetCities();
        City GetCity(int cityId, bool includePointOfInterest);
        IEnumerable<PointOfInterest> GetPointsOfInterestsForCity(int cityId);
        PointOfInterest GetPointOfInterestsForCity(int cityId, int pointOfInterestId);
        bool CityExists(int cityId);
        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);
        bool Save();
        void UpdatePointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
    }
}
