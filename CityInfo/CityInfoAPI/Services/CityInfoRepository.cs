using CityInfoAPI.Context;
using CityInfoAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CityInfoAPI.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext context;

        public CityInfoRepository(CityInfoContext context)
        {
            this.context = context;
        }

        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId, false);
            city.PointsOfInterest.Add(pointOfInterest);
        }

        public bool CityExists(int cityId)
        {
            return context.Cities.Any(x => x.Id == cityId);
        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            context.PointsOfInterest.Remove(pointOfInterest);
        }

        public IEnumerable<City> GetCities()
        {
            return context.Cities.OrderBy(c => c.Name).ToList();
        }


        public City GetCity(int cityId, bool includePointOfInterest)
        {
            if (includePointOfInterest)
            {
                return context.Cities.Include(c => c.PointsOfInterest).Where(c => c.Id == cityId).FirstOrDefault();
            }

            return context.Cities.Where(c => c.Id == cityId).FirstOrDefault();
        }

        public PointOfInterest GetPointOfInterestsForCity(int cityId, int pointOfInterestId)
        {
            return context.PointsOfInterest.Where(p => p.CityId == cityId && p.Id == pointOfInterestId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestsForCity(int cityId)
        {
            return context.PointsOfInterest.Where(p => p.CityId == cityId).ToList();
        }

        public bool Save()
        {
            return context.SaveChanges() >= 0;
        }

        public void UpdatePointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {

        }
    }
}
