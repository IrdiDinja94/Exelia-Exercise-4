using BeerCollection.API.Context;
using BeerCollection.API.Entities;
using BeerCollection.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerCollection.API.Services
{
    public class BeerRepository : IBeerRepository
    {
        private readonly BeerContext _context;

        public BeerRepository(BeerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool BeerExists(string name)
        {
            return _context.Beers.Any(c => c.Name.ToLower()==name.ToLower());
        }

        public Beer GetBeer(string name)
        {
            return _context.Beers
                .Where(b => b.Name.ToLower()==name.ToLower()).FirstOrDefault();            
        }

        public IEnumerable<Beer> GetBeers(string name)
        {
           return _context.Beers
                .Where(n=>n.Name.ToLower().Contains(name)).ToList();           
        }       

        public void AddRatingForBeer(string name, BeerRating beerRate)
        {
            var beer = GetBeer(name.ToLower());
            beer.BeerRatings.Add(beerRate);

            Save();         

            beer.Rating=Math.Round(_context.BeerRatings.Where(r=>r.BeerId==beer.Id).Average(r => r.Rate),1);

            Save();
        }

        public void AddNewBeer(Beer beer)
        {
            _context.Beers.Add(beer);
            Save();
        }

        public bool Save()
        {
            return (_context.SaveChanges()>=0);
        }
    }
}
