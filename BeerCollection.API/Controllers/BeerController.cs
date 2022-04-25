using AutoMapper;
using BeerCollection.API.Interfaces;
using BeerCollection.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BeerCollection.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BeerController: ControllerBase
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IMapper _mapper;

        public BeerController(IBeerRepository beerRepository,
                                IMapper mapper)
        {
            _beerRepository = beerRepository ??
                throw new ArgumentNullException(nameof(beerRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetAll(string name)
        {
            var beerEntities = _beerRepository.GetBeers(name);        

            return Ok(_mapper.Map<IEnumerable<BeerWithoutRatingsDto>>(beerEntities));
        }
        

        [HttpPost]
        public IActionResult AddBeer([FromBody] CreateBeerDto beer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_beerRepository.BeerExists(beer.Name))
            {
                var finalBeer = _mapper.
              Map<Entities.Beer>(beer);

                _beerRepository.AddNewBeer(finalBeer);               
                return Ok();
            }
          return BadRequest("The Beer exists");

        }

        [HttpPost]
        public IActionResult AddRate(string name,
            [FromBody] CreateBeerRateDto beerRate)
        {            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_beerRepository.BeerExists(name))
            {
                return NotFound();
            }

            var finalRate = _mapper.
                Map<Entities.BeerRating>(beerRate);

            _beerRepository.AddRatingForBeer(name, finalRate);           

            var createdRateToReturn = _mapper
                .Map<Models.BeerRatingDto>(finalRate);

            return Ok(createdRateToReturn);
        }

    }
}
