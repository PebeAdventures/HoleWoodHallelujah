namespace TvSeriesApi
{
    public class EpisodeProfile : Profile
    {
        public EpisodeProfile()
        {
            CreateMap<Episode, EpisodeReadDTO>()
                .ForMember(e => e.Season, opt => opt.MapFrom<EpisodeSeasonNameResolver>());
            CreateMap<EpisodeCreateDTO, Episode>();
            CreateMap<EpisodeUpdateDTO, Episode>();
        }
    }

    public class EpisodeSeasonNameResolver : IValueResolver<Episode, EpisodeReadDTO, string>
    {
        public string Resolve(Episode source, EpisodeReadDTO destination, string destMember, ResolutionContext context)
        {
            return source.Season.Name;
        }
    }
}
