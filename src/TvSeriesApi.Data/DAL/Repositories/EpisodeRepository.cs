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

        public async Task<IEnumerable<Episode>> GetAllEpisodesAsync()
        {
            return await _context.Episodes.Include(e => e.Season).ToListAsync();
        }

        public override async Task<Episode> AddAsync(Episode entity)
        {
            var addedElement = await _context.Set<Episode>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return await _context.Episodes
                .Include(e => e.Season)
                .Where(e => e.EpisodeId == addedElement.Entity.EpisodeId)
                .FirstOrDefaultAsync();
        }

    }
}