using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.DAL.Interfaces
{
    public interface ISeasonRepository : IBaseRepository<Season>
    {
        Task<Season> GetSeasonByIdAsync(int idSeries);
    }
}