namespace TvSeriesApi.Services.Interfaces
{
    public interface ITVSeriesService
    {
        Task<IEnumerable<TVSeriesReadDTO>> GetAllSeriesAsync();
        Task<TVSeriesReadDTO> GetSeriesByIdAsync(int id);
        Task<TVSeriesReadDTO> AddSeriesAsync(TVSeriesCreateDTO name);
        Task EditSeriesAsync(int id, TVSeriesUpdateDTO seriesDTO);
        Task DeleteSeriesAsync(int id);
    }
}
