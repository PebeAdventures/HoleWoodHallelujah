using TvSeriesApi.Data.Context;
using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.DAL.Repositories
{
    public class SeasonRepository : BaseRepository<Season>
    {
        private readonly TvSeriesApiContext _context;

        public SeasonRepository(TvSeriesApiContext context) : base(context)
        {
            _context = context;
        }
    }
}