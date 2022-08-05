namespace TvSeriesApi.Data.DAL.Interfaces
{
    public interface ITvSeriesRepository : IBaseRepository<TVSeries>
    {
        Task<IEnumerable<TVSeries>> GetAllSeriesAsync();
        Task<TVSeries> GetSeriesAsync(int id);
    }
}