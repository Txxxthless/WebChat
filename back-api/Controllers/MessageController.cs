using back_api.Domain.Entity;
using back_api.Service.Interfaces;
using back_api.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMessages()
        {
            DataBaseResponse<List<Message>> response = await _messageService.GetAllMessages();
            if (response.StatusCode == 200)
            {
                return Ok(response.Data);
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostMessage(Message message)
        {
            DataBaseResponse<Message> response = await _messageService.AddMessage(message);
            if (response.StatusCode == 200)
            {
                return Ok(response.Data);
            }
            return BadRequest();
        }
    }
}
