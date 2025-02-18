﻿using TvSeriesApi.Data.Context;
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
        public async Task<Season> GetSeasonByIdAsync(int idSeason) 
        { 
            return await _context.Seasons
                .Include(e => e.Episodes)
                .FirstOrDefaultAsync(e => e.SeasonId == idSeason);
        }
    }
}