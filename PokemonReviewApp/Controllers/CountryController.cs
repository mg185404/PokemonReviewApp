using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<OwnerDto>>(_countryRepository.GetCountries());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("id")]
        public IActionResult GetPokemon(int id)
        {
            if (!_countryRepository.CountryExists(id))
                return NotFound();

            var country = _mapper.Map<OwnerDto>(_countryRepository.GetCountry(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
        }

        [HttpGet("/owners/{ownerId}")]
        public IActionResult GetCountryOfAnOwner(int ownerId) 
        {
            var country = _mapper.Map<OwnerDto>(_countryRepository.GetCountryByOwner(ownerId));

            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
        }
    }
}
