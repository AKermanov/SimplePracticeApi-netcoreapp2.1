using CityInfoAPI.Models;
using System.Collections.Generic;

namespace CityInfoAPI
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id= 1,
                    Name = "New Yourk City",
                    Description = "The one with that big park.",
                    PointsOfInterests = new List<PointOfInteresDto>()
                    {
                        new PointOfInteresDto()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "The most visited park in US."
                        },
                          new PointOfInteresDto()
                        {
                            Id = 2,
                            Name = "Empire State Building",
                            Description = "The most visited building in US."
                        },
                    }
                },
                 new CityDto()
                {
                    Id= 2,
                    Name = "Antwerpy",
                    Description = "The one with the cathedral that was never really finished",
                       PointsOfInterests = new List<PointOfInteresDto>()
                    {
                        new PointOfInteresDto()
                        {
                            Id = 3,
                            Name = "Cathedral of Our Lady",
                            Description = "A gothic cathedral."
                        },
                          new PointOfInteresDto()
                        {
                            Id = 4,
                            Name = "Antwerp Central Station",
                            Description = "The finest example of railway"
                        },
                    }
                },
                  new CityDto()
                {
                    Id= 3,
                    Name = "Paris",
                    Description = "The one with that big tower.",
                       PointsOfInterests = new List<PointOfInteresDto>()
                    {
                        new PointOfInteresDto()
                        {
                            Id = 5,
                            Name = "Eifel Tower",
                            Description = "A wrough iron lettuce tower on the camp de mars"
                        },
                          new PointOfInteresDto()
                        {
                            Id = 6,
                            Name = "The Louvre",
                            Description = "The world's largest meseum."
                        },
                    }
                },
            };
        }
    }
}
