using System.Collections.Generic;
using System.Linq;

namespace BeerCollection.API.Models
{
    public class BeerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }     
        public double Rating { get; set; }
        
        

        public ICollection<BeerRatingDto> BeerRatings { get; set; }
            = new List<BeerRatingDto>();
    }
}
