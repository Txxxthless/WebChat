using back_api.DAL.Interfaces;
using back_api.Domain.Entity;

namespace back_api.DAL.Repositories
{
    public class MessageRepository : IRepository<Message>
    {
        private ApplicationDataBaseContext _dataBase;
        public MessageRepository(ApplicationDataBaseContext dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task<Message> CreateAsync(Message entity)
        {
            await _dataBase.AddAsync(entity);
            await _dataBase.SaveChangesAsync();
            return entity;
        }

        public async Task<Message> DeleteAsync(Message entity)
        {
            _dataBase.Remove(entity);
            await _dataBase.SaveChangesAsync();
            return entity;
        }

        public IQueryable<Message> GetAll()
        {
            return _dataBase.Messages;
        }

        public async Task<Message> UpdateAsync(Message entity)
        {
            _dataBase.Update(entity);
            await _dataBase.SaveChangesAsync();
            return entity;
        }
    }
}
