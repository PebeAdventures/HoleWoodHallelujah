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

        public async Task<OperationResult<EpisodeReadDTO>> CreateEpisode(EpisodeCreateDTO episodeDTO)
        {
            if (string.IsNullOrEmpty(episodeDTO.Name))
            {
                return OperationResult<EpisodeReadDTO>.Fail("Name can not be empty");
            } else if (episodeDTO.SeasonId == null)
            {
                return OperationResult<EpisodeReadDTO>.Fail("SeasonId can not be empty");
            }
            var newEpisode = _mapper.Map<Episode>(episodeDTO);
            var insertedEpisode = await _unitOfWork.Episodes.AddAsync(newEpisode);
            return OperationResult<EpisodeReadDTO>.Success(_mapper.Map<EpisodeReadDTO>(insertedEpisode));
        }

        public async Task<OperationResult> DeleteEpisodeAsync(int id)
        {
            var episode = await _unitOfWork.Episodes.GetEpisodeWithSeasonAsync(id);

            if (episode == null)
                return OperationResult.Fail("Episode not exist");

            _unitOfWork.Episodes.DeleteAsync(episode);          

             return OperationResult.Success();
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