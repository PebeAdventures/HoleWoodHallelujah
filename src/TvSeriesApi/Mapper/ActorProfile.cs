namespace TvSeriesApi.Profiles
{
    public class ActorProfile : Profile
    {//        public List<string> TVSeriesName { get; set; }

        public ActorProfile()
        {
            CreateMap<Actor, ActorReadDTO>()
                .ForMember(tv => tv.TVSeriesName, opt => opt.MapFrom(x => x.TVSeries.Select(x => x.Name)));
            //  CreateMap<Actor, ActorWithTvSeriesDTO>()
            //      .ForMember(tv => tv.TvSeriesName, act => act.MapFrom(src => src.TVSeries));
            CreateMap<ActorCreateDTO, Actor>();
            CreateMap<ActorUpdateDTO, Actor>();
        }
    }
}
