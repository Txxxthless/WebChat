using back_api.DAL.Interfaces;
using back_api.Domain.Entity;

namespace back_api.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationDataBaseContext _dataBase;
        public UserRepository(ApplicationDataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task<User> CreateAsync(User entity)
        {
            await _dataBase.AddAsync(entity);
            await _dataBase.SaveChangesAsync();
            return entity;
        }

        public async Task<User> DeleteAsync(User entity)
        {
            _dataBase.Remove(entity);
            await _dataBase.SaveChangesAsync();
            return entity;
        }

        public IQueryable<User> GetAll()
        {
            return _dataBase.Users;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            _dataBase.Update(entity);
            await _dataBase.SaveChangesAsync();
            return entity;
        }
    }
}
