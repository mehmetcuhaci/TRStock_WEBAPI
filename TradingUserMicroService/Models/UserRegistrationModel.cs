using System.ComponentModel.DataAnnotations;

namespace TradingUserMicroService.Models
{
    public class UserRegistrationModel
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Gerçek uygulamada şifreler hash'lenmeli
    }
}
