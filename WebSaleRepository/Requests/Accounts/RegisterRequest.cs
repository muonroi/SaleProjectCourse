using System.ComponentModel.DataAnnotations;

namespace WebSaleRepository.Requests.Accounts
{
    public class RegisterRequest : LoginRequest
    {
        [Required]
        public string Fullname { get; set; }

        [Required]
        [MinLength(8)]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(10), MaxLength(20)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone number invalid")]
        public string Phone { get; set; }
        [Required]
        [MinLength(10), MaxLength(255)]
        public string Address { get; set; }

    }
}
