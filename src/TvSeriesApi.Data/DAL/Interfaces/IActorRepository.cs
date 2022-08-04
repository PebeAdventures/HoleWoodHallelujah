namespace TvSeriesApi.Data.DAL.Interfaces
{
    public interface IActorRepository : IBaseRepository<Actor>
    {
        Task<List<Actor>> GetAllActorsAsync();
        Task<Actor> GetActorByIdAsync(int id);
    }
}