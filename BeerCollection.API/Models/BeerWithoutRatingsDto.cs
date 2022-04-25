namespace BeerCollection.API.Models
{
    public class BeerWithoutRatingsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }
    }
}
