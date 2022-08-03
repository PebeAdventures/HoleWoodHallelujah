using TvSeriesApi.Data.Context;
using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.DAL.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly TvSeriesApiContext _context;

        public GenreRepository(TvSeriesApiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Genre> GetGenreByIdAsync(int id) => await _context.Genres.Where(g => g.GenreId == id).FirstOrDefaultAsync();
    }
}