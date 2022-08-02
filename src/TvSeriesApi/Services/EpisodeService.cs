

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

        public Task DeleteEpisodeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EpisodeReadDTO> GetEpisodeByIdAsync(int id)
        {
            var episode = await _unitOfWork.Episodes.GetEpisodeWithAlbum(id);
            var episodeDTO = _mapper.Map<EpisodeReadDTO>(episode);

            return episodeDTO;
        }

        public Task UpdateEpisode(EpisodeUpdateDTO episode)
        {
            throw new NotImplementedException();
        }
    }
}
