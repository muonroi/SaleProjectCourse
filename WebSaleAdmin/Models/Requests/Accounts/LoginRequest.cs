using System.ComponentModel.DataAnnotations;

namespace WebSaleAdmin.Models.Requests.Accounts
{
    public class LoginRequest
    {
        [Required]
        [MinLength(3)]
        public string Username { get; set; }
        [MinLength(8)]
        [Required]
        public string Password { get; set; }
    }
}
