

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
            var episode = _mapper.Map<Episode>(episode);
            _unitOfWork.Episodes.AddAsync(episode);
        }

        public async Task<OperationResult> DeleteEpisodeAsync(int id)
        {
            var episode = await _unitOfWork.Episodes.GetEpisodeWithSeasonAsync(id);
            _unitOfWork.Episodes.DeleteAsync(episode);

            episode = await _unitOfWork.Episodes.GetEpisodeWithSeasonAsync(id);

            if (episode == null)
                return OperationResult.Success();
            
            return OperationResult.Fail("Episode not deleted");
        }

        public async Task<OperationResult<EpisodeReadDTO>> GetEpisodeByIdAsync(int id)
        {
            var episode = await _unitOfWork.Episodes.GetEpisodeWithSeasonAsync(id);
            if (episode == null)
                return OperationResult<EpisodeReadDTO>.Fail("Episode not exist");

            var episodeDTO = _mapper.Map<EpisodeReadDTO>(episode);
            return OperationResult<EpisodeReadDTO>.Success(episodeDTO);
        }

        public async Task UpdateEpisodeAsync(EpisodeUpdateDTO episode)
        {
            throw new NotImplementedException();
        }

        Task IEpisodeService.DeleteEpisodeAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
