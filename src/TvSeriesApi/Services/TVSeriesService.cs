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
        public async Task<OperationResult> AddSeriesAsync(TVSeriesCreateDTO tvSerie)
        {
            var tvSerieToAdd = _mapper.Map<TVSeries>(tvSerie);
            await _unitOfWork.TvSeries.AddAsync(tvSerieToAdd);
            return OperationResult.Success();
        }

        public async Task<OperationResult> DeleteSeriesAsync(int tvSeriesId)
        {
            var tvSeriesFromDB = await _unitOfWork.TvSeries.GetSeriesAsync(tvSeriesId);
            if (tvSeriesFromDB == null)
            {
                return OperationResult<TVSeriesUpdateDTO>.Fail("TV series not exist");
            }
            _unitOfWork.TvSeries.DeleteAsync(tvSeriesFromDB);
            return OperationResult.Success();
        }

        public async Task<OperationResult> EditSeriesAsync(int tvSeriesId, TVSeriesUpdateDTO seriesDTO)
        {
            var tvSeriesFromDB = await _unitOfWork.TvSeries.GetSeriesAsync(tvSeriesId);
            if (tvSeriesFromDB == null)
            {
                return OperationResult.Fail("Season not exist");
            }
            tvSeriesFromDB = _mapper.Map(seriesDTO, tvSeriesFromDB);
            _unitOfWork.TvSeries.UpdateAsync(tvSeriesFromDB);
            return OperationResult.Success();
        }

        public async Task<OperationResult<IEnumerable<TVSeriesReadDTO>>> GetAllSeriesAsync()
        {
            var tvSeries = await _unitOfWork.TvSeries.GetAllSeriesAsync();
            if (tvSeries == null)
                return OperationResult<IEnumerable<TVSeriesReadDTO>>.Fail("Tv Series not exist");

            var tvSeriesDTO = _mapper.Map<IEnumerable<TVSeriesReadDTO>>(tvSeries);
            return OperationResult<IEnumerable<TVSeriesReadDTO>>.Success(tvSeriesDTO);
        }

        public async Task<OperationResult<TVSeriesReadDTO>> GetSeriesByIdAsync(int id)
        {
            var tvSerie = await _unitOfWork.TvSeries.GetSeriesAsync(id);
            if (tvSerie == null)
                return OperationResult<TVSeriesReadDTO>.Fail("Tv series not exist");

            var tvSerieDTO = _mapper.Map<TVSeriesReadDTO>(tvSerie);
            return OperationResult<TVSeriesReadDTO>.Success(tvSerieDTO);
        }
    }
}
