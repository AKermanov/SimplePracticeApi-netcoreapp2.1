using AutoMapper;
using CityInfoAPI.Models;
using CityInfoAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityInfoAPI.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofinterest")]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly IMailServiceInterface _mailService;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger,
            IMailServiceInterface mailService,
            ICityInfoRepository cityInfoRepository,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(logger));
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
            ;
        }

        [HttpGet]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            try
            {
                if (!_cityInfoRepository.CityExists(cityId))
                {
                    _logger.LogInformation($"City with id {cityId} wasn't found when accessing points of interest.");
                    return NotFound();
                }

                var pointsOfInterestForCity = _cityInfoRepository.GetPointsOfInterestsForCity(cityId);
                return Ok(_mapper.Map<IEnumerable<PointOfInteresDto>>(pointsOfInterestForCity));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting points of interest for city with id {cityId}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }

        }

        [HttpGet("{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointOfInterest = _cityInfoRepository.GetPointOfInterestsForCity(cityId, id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInteresDto>(pointOfInterest));
        }

        [HttpPost]
        public IActionResult CreatePointsOfInterests(int cityId, [FromBody] PointsOfInterestForCreationDto pointsOfInterest)
        {
            // FluentValidation
            if (pointsOfInterest.Description == pointsOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var finalPointsOfInterests = _mapper.Map<Entities.PointOfInterest>(pointsOfInterest);

            _cityInfoRepository.AddPointOfInterestForCity(cityId, finalPointsOfInterests);
            _cityInfoRepository.Save();
            var createPointOfInterestToReturn = _mapper.Map<Models.PointOfInteresDto>(finalPointsOfInterests);

            return CreatedAtRoute("GetPointOfInterest", new { cityId, id = createPointOfInterestToReturn.Id }, createPointOfInterestToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id, [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointsOfIterestEntity = _cityInfoRepository.GetPointOfInterestsForCity(cityId, id);

            if (pointsOfIterestEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(pointOfInterest, pointsOfIterestEntity);
            _cityInfoRepository.UpdatePointOfInterestForCity(cityId, pointsOfIterestEntity);
            _cityInfoRepository.Save();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartlyUpdatePointOfInterest(int cityId, int id,
            [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {

            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointsOfIterestEntity = _cityInfoRepository.GetPointOfInterestsForCity(cityId, id);
            if (pointsOfIterestEntity == null)
            {
                return NotFound();
            }

            var pointsOfInterestToPatch = _mapper.Map<PointOfInterestForUpdateDto>(pointsOfIterestEntity);

            patchDoc.ApplyTo(pointsOfInterestToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (pointsOfInterestToPatch.Description == pointsOfInterestToPatch.Name)
            {
                ModelState.AddModelError("Description", "The provided description should be different from the name!");
            }

            if (!TryValidateModel(pointsOfInterestToPatch))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(pointsOfInterestToPatch, pointsOfIterestEntity);
            _cityInfoRepository.UpdatePointOfInterestForCity(cityId, pointsOfIterestEntity);
            _cityInfoRepository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
    
            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointsOfInterestEntity = _cityInfoRepository.GetPointOfInterestsForCity(cityId, id);

            if (pointsOfInterestEntity == null)
            {
                return NotFound();
            }

            _cityInfoRepository.DeletePointOfInterest(pointsOfInterestEntity);
            _cityInfoRepository.Save();
            _mailService.Send("Point of interest deleted.", $"Point of interest {pointsOfInterestEntity.Name} with id {pointsOfInterestEntity.Id} was deleted. ");
            return NoContent();
        }
    }
}
