using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerCollection.API.Entities
{
    public class BeerRating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Range(1, 5,
        ErrorMessage = "values from 1 to 5 are allowed")]
        public int Rate { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [ForeignKey("BeerId")]
        public Beer Beer { get; set; }
        public int BeerId { get; set; }
    }
}
