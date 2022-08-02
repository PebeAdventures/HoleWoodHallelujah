using Microsoft.EntityFrameworkCore;
using TvSeriesApi.Data.Context.Seeder;
using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.Context
{
    public class TvSeriesApiContext : DbContext
    {
        public DbSet<TVSeries> TVSeries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        public TvSeriesApiContext(DbContextOptions<TvSeriesApiContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TVSeries>().HasKey(t => t.TVSeriesId);
            modelBuilder.Entity<Genre>().HasKey(g => g.GenreId);
            modelBuilder.Entity<Actor>().HasKey(a => a.ActorId);
            modelBuilder.Entity<Season>().HasKey(s => s.SeasonId);
            modelBuilder.Entity<Episode>().HasKey(e => e.EpisodeId);

            modelBuilder.Entity<TVSeries>()
                .HasMany(t => t.Seasons)
                .WithOne(s => s.TVSeries);

            modelBuilder.Entity<TVSeries>()
                .HasMany(t => t.Cast)
                .WithMany(s => s.TVSeries);

            modelBuilder.Entity<TVSeries>()
                .HasOne(t => t.Genre)
                .WithMany(s => s.TVSeries);

            modelBuilder.Entity<Season>()
                .HasMany(s => s.Episodes)
                .WithOne(e => e.Season);
            modelBuilder.SeedDatabase();
        }
    }
}

