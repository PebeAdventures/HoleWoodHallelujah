using TvSeriesApi.Data.Context;
using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.DAL.Repositories
{
    public class TvSeriesRepository : BaseRepository<TVSeries>, ITvSeriesRepository
    {
        private readonly TvSeriesApiContext _context;

        public TvSeriesRepository(TvSeriesApiContext context) : base(context)
        {
            _context = context;
        }
    }
}