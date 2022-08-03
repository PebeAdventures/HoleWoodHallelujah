

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

        public async Task CreateEpisode(EpisodeCreateDTO episodeDTO)
        {
            var episode = _mapper.Map<Episode>(episodeDTO);
            await _unitOfWork.Episodes.AddAsync(episode);
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

        public async Task<OperationResult> UpdateEpisodeAsync(int episodeId, EpisodeUpdateDTO episode)
        {
            if (await _unitOfWork.Episodes.GetEpisodeByIdAsync(episodeId) == null)
            {
                return OperationResult.Fail("Episode no exist");
            }
            var episodeToUpdate = _mapper.Map<Episode>(episode);
            episodeToUpdate.EpisodeId = episodeId;
            _unitOfWork.Episodes.UpdateAsync(episodeToUpdate);
            return OperationResult.Success();
        }

        Task IEpisodeService.DeleteEpisodeAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
