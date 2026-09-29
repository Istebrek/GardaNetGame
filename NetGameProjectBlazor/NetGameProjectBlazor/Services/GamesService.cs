using AutoMapper;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IMapper _mapper;

        public GamesService(IGamesRepository gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository ?? throw new ArgumentNullException(nameof(gamesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GamesOverviewDto>> GetAllGamesAsync()
        {
            var gamesEntities = await _gamesRepository.GetAllGamesAsync();

            if (gamesEntities == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<GamesOverviewDto>>(gamesEntities);
        }

        public async Task<GameDetailDto> GetGameDetailsAsync(int gameId)
        {
            var gameEntity = await _gamesRepository.GetGameDetailsAsync(gameId);

            if (gameEntity == null)
            {
                return null;
            }

            return _mapper.Map<GameDetailDto>(gameEntity);
        }

        public async Task<IEnumerable<GamesOverviewDto>> GetGamesByAgeRestrictionAsync(int pegiID)
        {
            var gamesEntities = await _gamesRepository.GetGamesByAgeRestrctionAsync(pegiID);

            if (gamesEntities == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<GamesOverviewDto>>(gamesEntities);
        }

        public async Task<IEnumerable<GamesOverviewDto>> GetGamesByGenreAsync(string genre)
        {
            var gamesEntities = await _gamesRepository.GetGamesByGenreAsync(genre);

            if (gamesEntities == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<GamesOverviewDto>>(gamesEntities);
        }

        public async Task<IEnumerable<GamesOverviewDto>> GetGamesByPriceAsync(decimal price)
        {
            var gamesEntities = await _gamesRepository.GetGamesByPriceAsync(price);

            if (gamesEntities == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<GamesOverviewDto>>(gamesEntities);
        }
    }
}
