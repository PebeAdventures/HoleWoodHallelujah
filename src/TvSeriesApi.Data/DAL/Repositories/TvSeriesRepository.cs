using TvSeriesApi.Data.Context;

namespace TvSeriesApi.Data.DAL.Repositories
{
    public class TvSeriesRepository : BaseRepository<TVSeries>, ITvSeriesRepository
    {
        private readonly TvSeriesApiContext _context;

        public TvSeriesRepository(TvSeriesApiContext context, TvSeriesApiContext tvSeriesApiContext) : base(context)
        {
            _context = tvSeriesApiContext;
        }

        public async Task<TVSeries> GetTvSeasonAsync(int id)
        {
            return await _context.TVSeries.FirstOrDefaultAsync(e => e.TVSeriesId == id);
        }

    }
}