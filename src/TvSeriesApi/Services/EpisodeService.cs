

namespace TvSeriesApi.Services
{
    public class EpisodeService : IEpisodeService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public EpisodeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task CreateEpisode(EpisodeCreateDTO episode)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteEpisodeAsync(int id)
        {
            var episode = await _unitOfWork.Episodes.GetEpisodeWithSeasonAsync(id);
            _unitOfWork.Episodes.DeleteAsync(episode);
        }

        public async Task<EpisodeReadDTO> GetEpisodeByIdAsync(int id)
        {
            var episode = await _unitOfWork.Episodes.GetEpisodeWithSeasonAsync(id);
            var episodeDTO = _mapper.Map<EpisodeReadDTO>(episode);

            return episodeDTO;
        }

        public async Task UpdateEpisodeAsync(EpisodeUpdateDTO episode)
        {
            throw new NotImplementedException();
        }
    }
}
