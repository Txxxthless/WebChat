using back_api.Domain.Entity;

namespace back_api.Service.Interfaces
{
    public interface IMessageService
    {
        Task<DataBaseResponse<List<Message>>> GetAllMessages();
        Task<DataBaseResponse<Message>> AddMessage(Message message);
    }
}
