namespace TvSeriesApi.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SeasonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<SeasonReadDTO>> GetSeasonById(int seasonId)
        {
            var seasonFromDB = await _unitOfWork.Seasons.GetSeasonByIdAsync(seasonId);
            if (seasonFromDB == null)
            {
                return OperationResult<SeasonReadDTO>.Fail("Season not exist");
            }
            var seasonDTO = _mapper.Map<SeasonReadDTO>(seasonFromDB);
            return OperationResult<SeasonReadDTO>.Success(seasonDTO);
        }
        public async Task<OperationResult<IEnumerable<EpisodeReadDTO>>> GetAllEpisodesBySeasonIdAsync(int seasonId)
        {
            var seasonFromDB = await _unitOfWork.Seasons.GetSeasonByIdAsync(seasonId);
            if (seasonFromDB == null)
            {
                return OperationResult<IEnumerable<EpisodeReadDTO>>.Fail("Season not exist");
            }
            var episodes = seasonFromDB.Episodes;
            var episodesDTO = _mapper.Map<IEnumerable<EpisodeReadDTO>>(episodes);

            return OperationResult<IEnumerable<EpisodeReadDTO>>.Success(episodesDTO);

        }

        public async Task<OperationResult<EpisodeReadDTO>> GetEpisodeByIdBySeasonIdAsync(int seasonId, int episodeId)
        {
            var seasonFromDB = await _unitOfWork.Seasons.GetSeasonByIdAsync(seasonId);
            if (seasonFromDB == null)
            {
                return OperationResult<EpisodeReadDTO>.Fail("Season not exist");
            }
            else
            {
                var episodeFromDB = seasonFromDB.Episodes.Where(e => e.EpisodeId == episodeId);
                if (episodeFromDB == null)
                {
                    return OperationResult<EpisodeReadDTO>.Fail("Episode not exist");
                }
                var episodeDTO = _mapper.Map<EpisodeReadDTO>(episodeFromDB);
                return OperationResult<EpisodeReadDTO>.Success(episodeDTO);
            }

        }

        public async Task<OperationResult> CreateSeason(SeasonCreateDTO seasonCreateDTO)
        {
            var season = _mapper.Map<Season>(seasonCreateDTO);
            await _unitOfWork.Seasons.AddAsync(season);
            return OperationResult<SeasonCreateDTO>.Success();
        }

        public async Task<OperationResult> EditSeasonAync(int seasonId, SeasonUpdateDTO seasonUpdateDTO)
        {
            var seasonFromDB = await _unitOfWork.Seasons.GetSeasonByIdAsync(seasonId);
            if (seasonFromDB == null)
            {
                return OperationResult<SeasonUpdateDTO>.Fail("Season not exist");
            }
            seasonFromDB = _mapper.Map(seasonUpdateDTO, seasonFromDB);
            _unitOfWork.Seasons.UpdateAsync(seasonFromDB);
            return OperationResult.Success();
        }

        public async Task<OperationResult> DeleteSeasonAsync(int seasonId)
        {
            var seasonFromDB = await _unitOfWork.Seasons.GetSeasonByIdAsync(seasonId);
            if (seasonFromDB == null)
            {
                return OperationResult<SeasonUpdateDTO>.Fail("Season not exist");
            }
            _unitOfWork.Seasons.DeleteAsync(seasonFromDB);
            return OperationResult.Success();
        }

    }
}
