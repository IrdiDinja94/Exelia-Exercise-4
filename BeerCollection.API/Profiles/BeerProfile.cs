using AutoMapper;
using BeerCollection.API.Entities;
using BeerCollection.API.Models;

namespace BeerCollection.API.Profiles
{
    public class BeerProfile:Profile
    {
        public BeerProfile()
        {
            CreateMap<Beer, BeerWithoutRatingsDto>();
            CreateMap<Beer, BeerDto>();
            CreateMap<Beer, CreateBeerDto>().ReverseMap();
        }
    }
}
