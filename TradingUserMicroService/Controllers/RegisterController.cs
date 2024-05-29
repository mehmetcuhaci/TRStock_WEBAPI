using Microsoft.AspNetCore.Mvc;
using TradingUserMicroService.Models;

namespace TradingUserMicroService.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class RegisterController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public RegisterController(DataContext dataContext) {
        
        _dataContext=dataContext;
        
        }


        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationModel user)
        {
            await _dataContext.user_info.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return Ok(new { message = "Kullanıcı kaydedildi", user = user });
        }
    }
}
