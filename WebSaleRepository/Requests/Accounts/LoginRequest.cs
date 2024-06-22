using System.ComponentModel.DataAnnotations;

namespace WebSaleRepository.Requests.Accounts
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
