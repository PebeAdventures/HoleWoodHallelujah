namespace TvSeriesApi.Services.Interfaces
{
    public interface ITVSeriesService
    {
        Task<OperationResult<IEnumerable<TVSeriesReadDTO>>> GetAllSeriesAsync();
        Task<OperationResult<TVSeriesReadDTO>> GetSeriesByIdAsync(int id);
        Task<OperationResult> AddSeriesAsync(TVSeriesCreateDTO tvSerie);
        Task<OperationResult> EditSeriesAsync(int id, TVSeriesUpdateDTO seriesDTO);
        Task<OperationResult> DeleteSeriesAsync(int id);
    }
}
