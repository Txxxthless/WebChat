using back_api.DAL.Interfaces;
using back_api.Domain.Entity;

namespace back_api.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDataBaseContext _dataBase;
        public IRepository<Message> MessageRepository { get; set; }

        public UnitOfWork(
            ApplicationDataBaseContext dataBase, 
            IRepository<Message> messageRepository
            )
        {
            _dataBase = dataBase;
            MessageRepository = messageRepository;
        }

        public async Task Commit()
        {
            await _dataBase.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataBase.Dispose();
        }
    }
}
