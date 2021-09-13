using AutoMapper;
using CityInfoAPI.Entities;
using CityInfoAPI.Models;

namespace CityInfoAPI.Profiles
{
    public class PointOfInterestProfile : Profile
    {
        public PointOfInterestProfile()
        {
            CreateMap<PointOfInterest, PointOfInteresDto>();
            CreateMap<PointsOfInterestForCreationDto, PointOfInterest>();
            CreateMap<PointOfInterestForUpdateDto, PointOfInterest>().ReverseMap();
            //CreateMap<PointOfInterest, PointOfInterestForUpdateDto>();
        }
    }
}
