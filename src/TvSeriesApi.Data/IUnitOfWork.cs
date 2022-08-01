namespace TvSeriesApi.Data
{
    public interface IUnitOfWork
    {
        IActorRepository Actors { get; }
        IEpisodeRepository Episodes { get; }
        IGenreRepository Genres { get; }
        ISeasonRepository Seasons { get; }
        ITvSeriesRepository TvSeries { get; }
    }
}