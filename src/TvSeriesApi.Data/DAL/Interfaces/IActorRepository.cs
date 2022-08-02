using TvSeriesApi.Data.Entities;

namespace TvSeriesApi.Data.DAL.Interfaces
{
    public interface IActorRepository : IBaseRepository<Actor>
    {
        Task<Actor> GetActorByIdAsync(int id);
    }
}