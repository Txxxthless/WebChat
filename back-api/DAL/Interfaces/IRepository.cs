using back_api.Domain.Entity;

namespace back_api.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<DataBaseResponse<T>> CreateAsync(T entity);
        DataBaseResponse<IQueryable<T>> GetAll();
        Task<DataBaseResponse<T>> UpdateAsync(T entity);
        Task<DataBaseResponse<T>> DeleteAsync(T entity);
    }
}
