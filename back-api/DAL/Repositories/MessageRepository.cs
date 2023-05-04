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

        public async Task<DataBaseResponse<Message>> CreateAsync(Message entity)
        {
            DataBaseResponse<Message> response = new DataBaseResponse<Message>();
            try
            {
                await _dataBase.Messages.AddAsync(entity);
                response.Succeeded = true;
                return response;
            }
            catch(Exception ex)
            {
                response.Succeeded = false;
                response.Description = ex.Message;
                return response;
            }
        }

        public Task<DataBaseResponse<Message>> DeleteAsync(Message entity)
        {
            throw new NotImplementedException();
        }

        public DataBaseResponse<IQueryable<Message>> GetAll()
        {
            DataBaseResponse<IQueryable<Message>> response = new DataBaseResponse<IQueryable<Message>>();
            try
            {
                response.Data = _dataBase.Messages;
                response.Succeeded = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Description = ex.Message;
                return response;
            }
        }

        public Task<DataBaseResponse<Message>> UpdateAsync(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
