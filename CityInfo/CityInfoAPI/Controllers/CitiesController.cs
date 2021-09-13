using AutoMapper;
using CityInfoAPI.Models;
using CityInfoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfoAPI.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            this._cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cityEntities = _cityInfoRepository.GetCities();

            /*
            var result = new List<CityWithoudPointsOfInterestDto>();

            foreach (var cityEntity in cityEntities)
            {
                result.Add(new CityWithoudPointsOfInterestDto
                {
                    Id = cityEntity.Id,
                    Description = cityEntity.Description,
                    Name = cityEntity.Name
                });
            }
            */
            return Ok(_mapper.Map<IEnumerable<CityWithoudPointsOfInterestDto>>(cityEntities));
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);
            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }

            return Ok(_mapper.Map<CityWithoudPointsOfInterestDto>(city));
        }
    }
}
