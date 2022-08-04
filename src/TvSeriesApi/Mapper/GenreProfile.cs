using TvSeriesApi.Data.Helpers;

namespace TvSeriesApi.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreReadDTO>();
            CreateMap<GenreCreateDTO, Genre>();
            CreateMap<GenreUpdateDTO, Genre>();
            CreateMap<PagedList<Genre>, PagedGenreDto>().ForMember(dest => dest.Genres, act => act.MapFrom(src => src.ToList()));
        }
    }
}