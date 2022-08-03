using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.DAL.Interfaces
{
    public interface ISeasonRepository : IBaseRepository<Season>
    {
        Task<IEnumerable<Season>> GetAllSeasonsBySeriesIdAsync(int idSeries);
        Task<Season> GetSeasonByIdBySeriesIdAsync(int idSeries, int idSeasons);
    }
}