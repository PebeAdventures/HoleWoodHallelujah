namespace TvSeriesApi
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Actor, ActorReadDTO>();
            CreateMap<Actor, ActorWithTvSeriesDTO>();
            CreateMap<ActorCreateDTO, Actor>();
            CreateMap<ActorUpdateDTO, Actor>();

            CreateMap<Episode, EpisodeReadDTO>();
            CreateMap<EpisodeCreateDTO, Episode>();
            CreateMap<EpisodeUpdateDTO, Episode>();

            CreateMap<Genre, GenreReadDTO>();
            CreateMap<GenreCreateDTO, Genre>();
            CreateMap<GenreUpdateDTO, Genre>();

            CreateMap<Season, SeasonReadDTO>();
            CreateMap<SeasonCreateDTO, Season>();
            CreateMap<SeasonUpdateDTO, Season>();

            CreateMap<TVSeries, TVSeriesReadDTO>();
            CreateMap<TVSeriesCreateDTO, TVSeries>();
            CreateMap<TVSeriesUpdateDTO, TVSeries>();
        }
    }
}
