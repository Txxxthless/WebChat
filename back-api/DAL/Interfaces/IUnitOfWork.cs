using back_api.Domain.Entity;

namespace back_api.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Message> MessageRepository { get; set; }
        public Task Commit();
    }
}
