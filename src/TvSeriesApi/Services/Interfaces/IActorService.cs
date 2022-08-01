namespace TvSeriesApi.Services.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<ActorReadDTO>> GetAllActorsAsync();
        Task<ActorReadDTO> GetActorByIdAsync(int id);
        Task<ActorReadDTO> AddActorAsync(ActorCreateDTO name);
        Task EditActorAsync(int id, ActorUpdateDTO actorDTO);
        Task DeleteActorAsync(int id);
    }
}
