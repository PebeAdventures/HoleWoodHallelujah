namespace TvSeriesApi.Data.DAL.Interfaces
{
    public interface ITvSeriesRepository : IBaseRepository<TVSeries>
    {
        Task<TVSeries> GetTvSeasonAsync(int id);
    }
}