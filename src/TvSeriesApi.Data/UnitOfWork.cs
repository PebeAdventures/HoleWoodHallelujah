namespace TvSeriesApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IActorRepository actors, IEpisodeRepository episodes, IGenreRepository genres, ISeasonRepository seasons, ITvSeriesRepository tvSeries)
        {
            Actors = actors;
            Episodes = episodes;
            Genres = genres;
            Seasons = seasons;
            TvSeries = tvSeries;
        }

        public IActorRepository Actors { get; }
        public IEpisodeRepository Episodes { get; }
        public IGenreRepository Genres { get; }
        public ISeasonRepository Seasons { get; }
        public ITvSeriesRepository TvSeries { get; }
    }
}