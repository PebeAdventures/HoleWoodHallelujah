using Microsoft.EntityFrameworkCore;
using TvSeriesApi.Data.Context;
using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.DAL.Repositories
{
    public class EpisodeRepository : BaseRepository<Episode>, IEpisodeRepository
    {
        private readonly TvSeriesApiContext _context;

        public EpisodeRepository(TvSeriesApiContext context, TvSeriesApiContext tvSeriesApiContext) : base(context)
        {
            _context = tvSeriesApiContext;
        }

        public async Task<Episode> GetEpisodeWithSeasonAsync(int id)
        {
            return await _context.Episodes
                .Include(e => e.Season)
                .FirstOrDefaultAsync(e => e.EpisodeId == id);
        }

        public async Task<Episode> GetEpisodeByIdAsync(int id)
        {
            return await _context.Episodes
                .FindAsync(id);
        }
    }
}