using back_api.DAL.Interfaces;
using back_api.Domain.Entity;
using back_api.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace back_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public MessageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMessages()
        {
            DataBaseResponse<IQueryable<Message>> response = 
                _unitOfWork.MessageRepository.GetAll();
            if (response.Succeeded)
            {
                return Ok(await response.Data.ToListAsync());
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostMessage(MessageViewModel messageViewModel)
        {
            Message message = new Message()
            {
                Sender = GetCurrentUserName(),
                Text = messageViewModel.Text,
                TimeOfCreation = DateTime.UtcNow
            };

            DataBaseResponse<Message> response = 
                await _unitOfWork.MessageRepository.CreateAsync(message);

            if (response.Succeeded)
            {
                await _unitOfWork.Commit();
                return Ok(); 
            }

            return BadRequest();
        }

        private string GetCurrentUserName()
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                return claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
            }
            throw new Exception("User was not found");
        }
    }
}
