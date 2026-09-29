using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GenreForGameDto>> GetGenresForGameAsync(int gameId)
        {
            var genreEntities = await _genreRepository.GetGenresForGameAsync(gameId);

            if (genreEntities == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<GenreForGameDto>>(genreEntities);
        }
    }
}
