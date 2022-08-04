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

        public async Task<OperationResult>CreateEpisode(EpisodeCreateDTO episodeDTO)
        {
            var episode = _mapper.Map<Episode>(episodeDTO);
            await _unitOfWork.Episodes.AddAsync(episode);
            return OperationResult.Success();
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

        public async Task<OperationResult<List<EpisodeReadDTO>>> GetAllEpisodesAsync()
        {
            var episodes = await _unitOfWork.Episodes.GetAllEpisodesAsync();
            if (episodes == null)
                return OperationResult<List<EpisodeReadDTO>>.Fail("Episode not exist");

            var episodesDTO = _mapper.Map<List<Episode>, List<EpisodeReadDTO>>(episodes.ToList());

            return OperationResult<List<EpisodeReadDTO>>.Success(episodesDTO);
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
            var episodeFromDB = await _unitOfWork.Episodes.GetEpisodeByIdAsync(episodeId);

            if (episodeFromDB == null)
            {
                return OperationResult.Fail("Episode no exist");
            }

            episodeFromDB = _mapper.Map(episode, episodeFromDB);
            await _unitOfWork.Episodes.UpdateAsync(episodeFromDB);
            return OperationResult.Success();
        }
    }
}