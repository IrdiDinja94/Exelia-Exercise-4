using System.ComponentModel.DataAnnotations;

namespace BeerCollection.API.Models
{
    public class CreateBeerRateDto
    {
        [Range(1, 5,
         ErrorMessage = "put a rate value from 1 to 5")]
        public int Rate { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
