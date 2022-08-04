namespace TvSeriesApi
{
    public class EpisodeProfile : Profile
    {
        public EpisodeProfile()
        {
            CreateMap<Episode, EpisodeReadDTO>()
                .ForMember(e => e.Season, opt => opt.MapFrom(e => e.Season.Name));
            CreateMap<EpisodeCreateDTO, Episode>();
            CreateMap<EpisodeUpdateDTO, Episode>();
        }
    }
}
