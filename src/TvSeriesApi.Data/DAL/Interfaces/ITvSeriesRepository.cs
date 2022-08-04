namespace TvSeriesApi.Data.DAL.Interfaces
{
    public interface ITvSeriesRepository : IBaseRepository<TVSeries>
    {
        Task<IEnumerable<TVSeries>> GetAllTvSeasonsAsync();
        Task<TVSeries> GetTvSeasonAsync(int id);
    }
}