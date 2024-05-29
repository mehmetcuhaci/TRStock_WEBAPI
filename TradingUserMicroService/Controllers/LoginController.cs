using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TradingUserMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public LoginController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(string userName,string password)
        {
            if (string.IsNullOrWhiteSpace(userName)|string.IsNullOrWhiteSpace(password))
            {
                return BadRequest("Kullanıcı adı veya şifre boş olamaz!");

            }

            var user=await _dataContext.user_info
                .FirstOrDefaultAsync(u => u.UserName == userName);

            if (user==null)
            {
                return Unauthorized("Kullanıcı adı veya şifre yanlış.");
            }

            if (user.Password != password)
            {
                return Unauthorized("Kullanıcı adı veya şifre yanlış.");
            }


           
            return Ok("Giriş başarılı");
            //return Redirect("Giriş Başarılı");


        }

    }
}
