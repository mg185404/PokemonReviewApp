using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public IActionResult GetReviews()
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpGet("id")]
        public IActionResult GetReview(int id)
        {
            if (!_reviewRepository.ReviewExists(id))
                return NotFound();

            var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(id));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(review);
        }
        
        [HttpGet("pokemon/{pokeId}")]
        public IActionResult GetReviewsForAPokemon(int pokeId) 
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewsOfAPokemon(pokeId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }
    }
}
