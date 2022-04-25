using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerCollection.API.Entities
{
    public class Beer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
        
        public double Rating { get; set; }
      
    
    public ICollection<BeerRating> BeerRatings { get; set; }
                = new List<BeerRating>();
    }
}
