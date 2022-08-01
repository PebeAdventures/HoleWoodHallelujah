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
            modelBuilder.Entity<TVSeries>().HasKey(t => t.TVSeriesId);
            modelBuilder.Entity<Genre>().HasKey(g => g.GenreId);
            modelBuilder.Entity<Actor>().HasKey(a => a.ActorId);
            modelBuilder.Entity<Season>().HasKey(s => s.SeasonId);
            modelBuilder.Entity<Episode>().HasKey(e => e.EpisodeId);


        }
    }
}
