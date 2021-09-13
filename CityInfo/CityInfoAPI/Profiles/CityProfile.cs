using AutoMapper;

namespace CityInfoAPI
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<Entities.City, Models.CityWithoudPointsOfInterestDto>();
            CreateMap<Entities.City, Models.CityDto>();
        }
    }
}
