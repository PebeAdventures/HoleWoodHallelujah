using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.DAL.Interfaces
{
    public interface IEpisodeRepository : IBaseRepository<Episode>
    {
        Task<IEnumerable<Episode>> GetAllEpisodesAsync();
        Task<Episode> GetEpisodeByIdAsync(int id);
        Task<Episode> GetEpisodeWithSeasonAsync(int id);
    }
}