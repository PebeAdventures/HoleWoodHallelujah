namespace TvSeriesApi.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorReadDTO>();
            CreateMap<Actor, ActorWithTvSeriesDTO>()
                .ForMember(tv => tv.TvSeriesName, act => act.MapFrom(src => src.TVSeries));
            CreateMap<ActorCreateDTO, Actor>();
            CreateMap<ActorUpdateDTO, Actor>();
        }
    }
}
