namespace TvSeriesApi.Services
{
    public class TVSeriesService : ITVSeriesService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TVSeriesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<TVSeriesReadDTO> AddSeriesAsync(TVSeriesCreateDTO tvSerie)
        {
            throw new NotImplementedException();
        }



        public Task DeleteSeriesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditSeriesAsync(int id, TVSeriesUpdateDTO seriesDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<IEnumerable<TVSeriesReadDTO>>> GetAllSeriesAsync()
        {
            var tvSeries = await _unitOfWork.TvSeries.GetAllTvSeasonsAsync();
            if (tvSeries == null)
                return OperationResult<IEnumerable<TVSeriesReadDTO>>.Fail("Tv Series not exist");

            var tvSeriesDTO = _mapper.Map<IEnumerable<TVSeriesReadDTO>>(tvSeries);
            return OperationResult<IEnumerable<TVSeriesReadDTO>>.Success(tvSeriesDTO);
        }

        public async Task<OperationResult<TVSeriesReadDTO>> GetSeriesByIdAsync(int id)
        {
            var tvSerie = await _unitOfWork.TvSeries.GetTvSeasonAsync(id);
            if (tvSerie == null)
                return OperationResult<TVSeriesReadDTO>.Fail("Tv series not exist");

            var tvSerieDTO = _mapper.Map<TVSeriesReadDTO>(tvSerie);
            return OperationResult<TVSeriesReadDTO>.Success(tvSerieDTO);
        }
    }
}
