namespace TvSeriesApi.Services.Interfaces
{
    public interface IActorService
    {
        Task<IEnumerable<ActorReadDTO>> GetAllActorsAsync();
        Task<ActorReadDTO> GetActorByIdAsync(int id);
        Task<ActorReadDTO> AddActorAsync(ActorCreateDTO actorDTO);
        Task DeleteActorAsync(int id);
        Task EditActorAsync(int id, ActorUpdateDTO actorDTO);
        Task<ActorWithTvSeriesDTO> GetActorWithTvSeries(int id);
    }
}
