using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.DAL.Interfaces
{
    public interface IEpisodeRepository : IBaseRepository<Episode>
    {
        Task<Episode> GetEpisodeWithSeasonAsync(int id);
    }
}