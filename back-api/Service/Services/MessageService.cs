using back_api.DAL.Interfaces;
using back_api.Domain.Entity;
using back_api.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace back_api.Service.Services
{
    public class MessageService : IMessageService
    {
        private IRepository<Message> _messageRepository;
        public MessageService(IRepository<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<DataBaseResponse<Message>> AddMessage(Message message)
        {
            DataBaseResponse<Message> response = new DataBaseResponse<Message>();
            try
            {
                if (message == null)
                {
                    throw new NullReferenceException("Null message");
                }
                message.TimeOfCreation = DateTime.Now;
                await _messageRepository.CreateAsync(message);
                response.StatusCode = 200;
                response.Data = message;
                return response;
            }
            catch (Exception ex)
            {
                response.Description = ex.Message;
                response.StatusCode = 500;
                return response;
            }
        }
        public async Task<DataBaseResponse<List<Message>>> GetAllMessages()
        {
            DataBaseResponse<List<Message>> response = new DataBaseResponse<List<Message>> ();
            try
            {
                List<Message> messages = await _messageRepository.GetAll().ToListAsync();
                if (messages == null)
                {
                    throw new Exception("Error occured");
                }
                response.StatusCode = 200;
                response.Data = messages;
                return response;
            }
            catch (Exception ex)
            {
                response.Description = ex.Message;
                response.StatusCode = 500;
                return response;
            }
        }
    }
}
