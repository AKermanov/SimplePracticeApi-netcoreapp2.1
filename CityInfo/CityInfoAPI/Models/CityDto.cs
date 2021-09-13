using System.Collections.Generic;

namespace CityInfoAPI.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MyProperty => PointsOfInterests.Count;
        public ICollection<PointOfInteresDto> PointsOfInterests { get; set; } = new List<PointOfInteresDto>();
    }
}
