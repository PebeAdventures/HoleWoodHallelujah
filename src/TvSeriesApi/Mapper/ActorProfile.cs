namespace TvSeriesApi.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorReadDTO>();
            CreateMap<Actor, ActorWithTvSeriesDTO>();
            CreateMap<ActorCreateDTO, Actor>();
            CreateMap<ActorUpdateDTO, Actor>();
        }
    }
}
