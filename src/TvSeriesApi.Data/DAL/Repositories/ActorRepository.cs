using TvSeriesApi.Data.Context;
using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.DAL.Repositories
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        private readonly TvSeriesApiContext _context;

        public ActorRepository(TvSeriesApiContext context) : base(context)
        {
            _context = context;
        }
    }
}