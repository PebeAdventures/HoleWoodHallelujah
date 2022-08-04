namespace TvSeriesApi.Profiles
{
    public class ActorProfile : Profile
    {

        public ActorProfile()
        {
            CreateMap<Actor, ActorReadDTO>()
                .ForMember(tv => tv.TVSeriesName, opt => opt.MapFrom(x => x.TVSeries.Select(x => x.Name)));

            CreateMap<Actor, ActorWithTvSeriesDTO>()
                .ForMember(tv => tv.TvSeriesName, opt => opt.MapFrom(x => x.TVSeries.Select(x => x.Name)));

            CreateMap<ActorCreateDTO, Actor>();
            CreateMap<ActorUpdateDTO, Actor>();
        }
    }
}
