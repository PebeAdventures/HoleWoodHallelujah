namespace TvSeriesApi.Profiles
{
    public class SeasonProfile : Profile
    {
        public SeasonProfile()
        {
            CreateMap<Season, SeasonReadDTO>()
                .ForMember(e => e.Name, opt => opt.MapFrom(s => s.Name));
            CreateMap<SeasonCreateDTO, Season>();
            CreateMap<SeasonUpdateDTO, Season>();
        }
    }
}
