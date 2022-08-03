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

        public Task<IEnumerable<EpisodeReadDTO>> GetAllEpisodesBySeasonIdAsync(int seasonId)
        {
            throw new NotImplementedException();
        }

        public Task<EpisodeReadDTO> GetEpisodeByIdBySeasonIdAsync(int seasonId)
        {
            throw new NotImplementedException();
        }

        public Task<SeasonCreateDTO> AddSeasonAsync(SeasonCreateDTO seasonCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<SeasonUpdateDTO> EditSeasonAync(SeasonUpdateDTO seasonUpdateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<SeasonReadDTO> DeleteSeasonAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
