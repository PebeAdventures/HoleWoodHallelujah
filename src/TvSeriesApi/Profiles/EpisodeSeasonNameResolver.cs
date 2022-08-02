namespace TvSeriesApi
{
    public class EpisodeSeasonNameResolver : IValueResolver<Episode, EpisodeReadDTO, string>
    {
        public string Resolve(Episode source, EpisodeReadDTO destination, string destMember, ResolutionContext context)
        {
            return source.Season.Name;
        }
    }
}
