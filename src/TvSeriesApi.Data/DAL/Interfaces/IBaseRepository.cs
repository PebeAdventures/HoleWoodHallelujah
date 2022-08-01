namespace TvSeriesApi.Data.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();
    }
}