﻿namespace TvSeriesApi.Data.DAL.Repositories
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        private readonly TvSeriesApiContext _context;

        public ActorRepository(TvSeriesApiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        => await _context.Actors.Include(tv => tv.TVSeries).FirstOrDefaultAsync(e => e.ActorId == id);

        public async Task<List<Actor>> GetAllActorsAsync()

            => await _context.Actors.Include(tv => tv.TVSeries).ToListAsync();

    }
}