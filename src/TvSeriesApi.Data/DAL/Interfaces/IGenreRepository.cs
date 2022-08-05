using TvSeriesApi.Data.Entities;
using TvSeriesApi.Data.Helpers;

namespace TvSeriesApi.Data.DAL.Interfaces
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<Genre> GetGenreByIdAsync(int id);

        IQueryable<Genre> GetGenresPaginated();
    }
}