using AutoMapper;
using FakeItEasy;
using PokemonReviewApp.Interfaces;

namespace PokemonReviewApp.Tests.Controllers
{
    public class PokemonControllerTests
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public PokemonControllerTests(IReviewRepository reviewRepository, IMapper mapper)
        {
            _pokemonRepository = A.Fake<IPokemonRepository>();
            _reviewRepository = A.Fake<IReviewRepository>();
            _mapper = A.Fake<Mapper>(); 
        }

        [Fact]
        public void PokemonController_GetPokemons_ReturnOK()
        {

        }
    }
}
