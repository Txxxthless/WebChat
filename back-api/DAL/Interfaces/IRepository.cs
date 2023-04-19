namespace back_api.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        IQueryable<T> GetAll();
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
