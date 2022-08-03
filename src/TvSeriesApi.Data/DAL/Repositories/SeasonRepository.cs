using TvSeriesApi.Data.Context;
using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.DAL.Repositories
{
    public class SeasonRepository : BaseRepository<Season>, ISeasonRepository
    {
        private readonly TvSeriesApiContext _context;

        public SeasonRepository(TvSeriesApiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Season>> GetAllSeasonsBySeriesIdAsync(int idSeries)
        {
            return await _context.Seasons.Include(x=>x.TVSeries.TVSeriesId == idSeries).ToListAsync();
        }

        public async Task<Season> GetSeasonByIdBySeriesIdAsync(int idSeries, int idSeasons)
        {
            return await _context.TVSeries.Where(e => e.TVSeriesId == idSeries)
        }
    }
}