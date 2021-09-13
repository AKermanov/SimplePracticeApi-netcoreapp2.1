using System.ComponentModel.DataAnnotations;

namespace CityInfoAPI.Models
{
    public class PointsOfInterestForCreationDto
    {
        [Required(ErrorMessage = "You should provide a value!")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
