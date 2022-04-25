using AutoMapper;
using BeerCollection.API.Entities;
using BeerCollection.API.Models;

namespace BeerCollection.API.Profiles
{
    public class BeerRatingProfile:Profile
    {
        public BeerRatingProfile()
        {
            CreateMap<BeerRating, BeerRatingDto>();         
            CreateMap<BeerRating,CreateBeerRateDto>().ReverseMap();
        }
       
    }
}
