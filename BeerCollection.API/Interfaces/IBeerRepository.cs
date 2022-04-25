using BeerCollection.API.Entities;
using System.Collections.Generic;

namespace BeerCollection.API.Interfaces
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> GetBeers(string name);
        Beer GetBeer(string name);      
        bool BeerExists(string name);
        void AddRatingForBeer(string name, BeerRating beerRate);
        void AddNewBeer(Beer beer);
        bool Save();
    }
}
