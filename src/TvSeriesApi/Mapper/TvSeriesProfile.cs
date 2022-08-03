namespace TvSeriesApi.Profiles
{
    public class TvSeriesProfile : Profile
    {
        public TvSeriesProfile()
        {
            CreateMap<TVSeries, TVSeriesReadDTO>();
            CreateMap<TVSeries, TVSeriesCreateDTO>();
            CreateMap<TVSeries, TVSeriesUpdateDTO>();
        }
    }
}


