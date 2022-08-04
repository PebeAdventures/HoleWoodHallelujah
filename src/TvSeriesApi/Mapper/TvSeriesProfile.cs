namespace TvSeriesApi
{
    public class TvSeriesProfile : Profile
    {
        public TvSeriesProfile()
        {
            CreateMap<TVSeries, TVSeriesReadDTO>()
                .ForMember(e => e.Genre, opt => opt.MapFrom(e => e.Genre.Name))
            .ForMember(c => c.Cast, opt => opt.MapFrom(c => c.Cast));

            CreateMap<TVSeries, TVSeriesCreateDTO>();
            CreateMap<TVSeries, TVSeriesUpdateDTO>();
        }
    }

}



