using Microsoft.EntityFrameworkCore;
using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.Context
{
    public class TvSeriesApiContex : DbContext
    {
        public DbSet<TVSeries> TVSeries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
