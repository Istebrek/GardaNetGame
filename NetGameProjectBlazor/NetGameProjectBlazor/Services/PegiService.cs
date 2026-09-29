using AutoMapper;
using NetGameProjectBlazor.Interfaces;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Services
{
    public class PegiService : IPegiService
    {
        private readonly IMapper _mapper;
        private readonly IPegiRepository _pegiRepository;

        public PegiService(IMapper mapper, IPegiRepository pegiRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _pegiRepository = pegiRepository ?? throw new ArgumentNullException(nameof(pegiRepository));
        }
        public async Task<IEnumerable<PegiNameDto>> GetAllAgeRestrictionsAsync()
        {
            var pegiEntities = await _pegiRepository.GetAllAgeRestrictionsAsync();

            if (pegiEntities == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<PegiNameDto>>(pegiEntities);
        }
    }
}
