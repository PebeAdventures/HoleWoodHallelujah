namespace TvSeriesApi.Profiles
{
    public class SeasonProfile : Profile
    {
        public SeasonProfile()
        {
            CreateMap<Season, SeasonReadDTO>();
            CreateMap<SeasonCreateDTO, Season>();
            CreateMap<SeasonUpdateDTO, Season>();
        }
    }
}
